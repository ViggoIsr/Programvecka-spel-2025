using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public Transform player; // Referens till spelarens transform
    public float triggerPointX; // X-koordinaten där monstret ska börja röra sig
    public float moveSpeed = 2f; // Farten på monstret

    private bool isChasing = false; // Om monstret ska börja röra sig

    void Update()
    {
        // Kolla om spelaren har passerat triggerpunkten
        if (!isChasing && player.position.x > triggerPointX)
        {
            isChasing = true;
        }

        // Om monstret ska jaga spelaren, rör det åt höger
        if (isChasing)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
