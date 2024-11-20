using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lanes { Left, Middle, Right };
public enum Height { Roll, Ground, Air, Jump};

public class Player : MonoBehaviour
{
    public Animator animator;
    public float laneSwitchTime = .2f;
    private Lanes lane;
    public float speed = 1f;
    public float gravity;
    [Header("Jump")]
    public float jumpHeight;
    public float jumpTime;
    private float verticalVelocity = 0f;
    public Height heightInternal;
    public LayerMask obstacleLayers;
    public bool isAlive;
    public Height height
    {
        get => heightInternal;
        set
        {
            if (heightInternal != value)
            {

                heightInternal = value;
                switch (heightInternal)
                {
                    case Height.Roll:
                        animator.SetTrigger("Roll");
                        break;
                    case Height.Ground:
                        animator.SetTrigger("Run");
                        break;
                    case Height.Air:
                        animator.SetTrigger("Falling");
                        break;
                    case Height.Jump:
                        animator.SetTrigger("Jump");
                        LeanTween.moveY(model, model.transform.position.y + jumpHeight, jumpTime).setEaseOutQuad().setOnComplete(() =>
                        {
                            if (height == Height.Jump)
                            {
                                height = Height.Air;
                            }
                        });
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public GameObject model;
    RaycastHit groundHit;
    public LayerMask groundLayers;

    public Lanes Lane {
        get => lane;
        set {
            lane = value;
            switch (lane)
            {
                case Lanes.Left:
                    LeanTween.moveX(gameObject, -2, laneSwitchTime).setEaseInOutSine();
                    break;
                case Lanes.Middle:
                    LeanTween.moveX(gameObject, 0, laneSwitchTime).setEaseInOutSine();
                    break;
                case Lanes.Right:
                        LeanTween.moveX(gameObject, 2, laneSwitchTime).setEaseInOutSine();
                    break;
                default:
                    break;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Section")
        {
            return;
        }

        Game.instance.levelGenerator.SpawnSection(true);
    }

    // Start is called before the first frame update
    void Awake()
    {
        Lane = Lanes.Middle;
        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("Run");
        height = Height.Ground;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        CheckGround();
        CheckForward();
    }

    void MoveForward()
    {
        if (isAlive)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

    }

    void CheckGround()
    {
        switch (heightInternal)
        {
            case Height.Roll:
                if (Physics.Raycast(model.transform.position + Vector3.up* .3f, Vector3.down, out groundHit, .5f, groundLayers))
                {
                    verticalVelocity = 0f;
                    height = Height.Ground;
                } else
                {
                    verticalVelocity -= gravity * 5 * Time.deltaTime;
                    model.transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
                }
                break;
            case Height.Air:
                if (Physics.Raycast(model.transform.position + Vector3.up* .3f, Vector3.down, out groundHit, .5f, groundLayers))
                {
                    verticalVelocity = 0f;
                    height = Height.Ground;
                } else
                {
                    verticalVelocity -= gravity * Time.deltaTime;
                    model.transform.position += Vector3.up * verticalVelocity * Time.deltaTime;
                }
                break;
            case Height.Ground:
                if (Physics.Raycast(model.transform.position + Vector3.up* .3f, Vector3.down, out groundHit, .5f, groundLayers))
                {
                    verticalVelocity = 0f;
                    model.transform.position = groundHit.point;
                } else
                {
                    height = Height.Air;
                }

                break;
            case Height.Jump:
                break;
            default:
                break;
        }
    }

    void CheckForward()
    {
        RaycastHit ForwardHit;
        if (isAlive && Physics.Raycast(model.transform.position + Vector3.up* .3f, Vector3.forward, out ForwardHit, .5f, obstacleLayers))
        {
            animator.SetTrigger("Death");
            Game.instance.ui.OpenMenuEnd();
            isAlive = false;
        }
    }

    public void Jump()
    {
        if (height == Height.Ground || height == Height.Roll)
        {
            height = Height.Jump;
        }
    }

    public void Roll() {
        height = Height.Roll;
    }

    public void Rigth() {
        switch (Lane)
        {
            case Lanes.Left:
                Lane  = Lanes.Middle;
                break;
            case Lanes.Middle:
                Lane = Lanes.Right;
                break;
            case Lanes.Right:
                break;
        }
    }
    public void Left() {
        switch (Lane)
        {
            case Lanes.Left:
                break;
            case Lanes.Middle:
                Lane = Lanes.Left;
                break;
            case Lanes.Right:
                Lane = Lanes.Middle;
                break;
        }
    }
}
