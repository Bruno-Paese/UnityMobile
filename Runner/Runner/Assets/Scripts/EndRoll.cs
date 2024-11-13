using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoll : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    public void endRoll()
    {
        player.height = Height.Ground;
    }
}
