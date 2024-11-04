using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Lanes { Left, Middle, Right };

public class Player : MonoBehaviour
{
    public Animator animator;
    public float laneSwitchTime = .2f;
    private Lanes lane;

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
