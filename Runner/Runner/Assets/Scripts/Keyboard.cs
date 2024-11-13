using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keyboard : MonoBehaviour
{
    public UnityEvent up, down, left, right;
    public KeyCode keyup, keydown, keyleft, keyright;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyup))
        {
            up.Invoke();
        }
        if (Input.GetKeyDown(keydown))
        {
            down.Invoke();
        }
        if (Input.GetKeyDown(keyleft))
        {
            left.Invoke();
        }
        if (Input.GetKeyDown(keyright))
        {
            right.Invoke();
        }
    }
}
