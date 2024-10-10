using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;
    public Transform targetTransform;
    public Transform startPos, endPos;
    // Start is called before the first frame update
    void Start()
    {
        target.transform.position = startPos.position;
        targetTransform = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        target.transform.position += (targetTransform.position - target.transform.position).normalized * speed * Time.deltaTime;

        if (Vector3.Distance(target.transform.position, targetTransform.position) < 0.2f)
        {
            if (targetTransform != startPos)
            {
                targetTransform = startPos;
                return;
            }

            targetTransform = endPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            target.SetActive(false);
            Game.Instance.points++;
			Game.Instance.EnableRandomTargets();
        }
    }
}
