using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject ballPrefab;
    public float force = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject ball = Instantiate(ballPrefab);
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            ball.transform.position = ray.origin;

            if (rb != null)
            {
                rb.AddForce(ray.direction * force, ForceMode.Impulse);
            }
        }
    }
}
