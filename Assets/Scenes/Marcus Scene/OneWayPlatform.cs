using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waitTime = 0.5f;
    private float timer;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        // If player is pressing down
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (timer <= 0)
            {
                effector.rotationalOffset = 180f;
                timer = waitTime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }

        // Reset platform when player releases down or jumps
        if (Input.GetAxisRaw("Vertical") >= 0 || Input.GetButtonDown("Jump"))
        {
            effector.rotationalOffset = 0;
        }
    }
}