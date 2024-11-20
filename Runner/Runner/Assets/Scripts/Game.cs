using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game instance;
    public UI ui;
    public LevelGenerator levelGenerator;
    public Player player;
    public float incrementalSpeed;
    public float maxSpeed;
    public int pointsInternal, coins = 0;

    public int points
    {
        get => pointsInternal;
        set
        {
            pointsInternal = value;
            ui.points.text = value.ToString();
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        InvokeRepeating("addPoints", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void addPoints()
    {
        if (!player.isAlive)
        {
            return;
        }
        points += (int) player.speed;
        player.speed = Mathf.Clamp(player.speed + incrementalSpeed, 0, maxSpeed);
    }
}
