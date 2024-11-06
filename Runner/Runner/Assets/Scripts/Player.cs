using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lanes { Left, Middle, Right };

public class Player : MonoBehaviour
{
    public Animator animator;
    public float laneSwitchTime = .2f;
    private Lanes lane;
    public float speed = 1f;
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
    void Start()
    {
        Lane = Lanes.Middle;
        animator = GetComponentInChildren<Animator>();
        animator.SetTrigger("Run");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        if (Physics.Raycast(model.transform.position + Vector3.up* .3f, Vector3.down, out groundHit, .5f, groundLayers))
        {
            model.transform.position = groundHit.point;   
        }
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");
    }

    public void Roll() {
        animator.SetTrigger("Roll");
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
