using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Swipe : MonoBehaviour
{
    Vector2 initialPos, endPos;
    Touch primaryTouch;
    public UnityEvent swipeUp, swipeDown, swipeLeft, swipeRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            primaryTouch = Input.GetTouch(0);
            if (primaryTouch.phase == TouchPhase.Began)
            {
                initialPos = primaryTouch.position;
            }

            if (primaryTouch.phase == TouchPhase.Ended)
            {
                endPos = primaryTouch.position;
                Vector2 direction = endPos - initialPos;
                direction = direction.normalized;
                direction = new Vector2(Mathf.Round(direction.x), Mathf.Round(direction.y));
                CheckDirection(direction);
            }
        }
    }

    void CheckDirection(Vector2 direction) {
        if (direction == Vector2.up)
        {
            swipeUp.Invoke();
        }
        if (direction == Vector2.left)
        {
            swipeLeft.Invoke();
        }
        if (direction == Vector2.right)
        {
            swipeRight.Invoke();
        }
        if (direction == Vector2.down)
        {
            swipeDown.Invoke();
        }
    }
}
