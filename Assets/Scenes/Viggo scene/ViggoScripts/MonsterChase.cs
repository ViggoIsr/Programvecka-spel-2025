using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterChase : MonoBehaviour
{
    public Transform player; // Referens till spelarens transform
    public float triggerPointX; // X-koordinaten d�r monstret ska b�rja r�ra sig
    public float moveSpeed = 2f; // Farten p� monstret

    private bool isChasing = false; // Om monstret ska b�rja r�ra sig

    void Update()
    {
        // Kolla om spelaren har passerat triggerpunkten
        if (!isChasing && player.position.x > triggerPointX)
        {
            isChasing = true;
        }

        // Om monstret ska jaga spelaren, r�r det �t h�ger
        if (isChasing)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
