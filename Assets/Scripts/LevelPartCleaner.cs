using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPartCleaner : MonoBehaviour
{
    public float offset = 15f;
    private void Update()
    {
        transform.position = new Vector3(transform.parent.transform.position.x - offset, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LevelPart"))
        {
            Destroy(other.gameObject);
        }
    }
}
