using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player died!");
            PlayerHealth.instance.Death(false);
        }

        if (other.CompareTag("Opponent"))
        {
            Debug.Log("Opponent died!");
            OpponentHealth.instance.Death(false);
        }
    }
}
