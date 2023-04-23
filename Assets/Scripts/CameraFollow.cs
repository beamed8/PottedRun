using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Master Toggle")]
    public bool isFollowing = true;

    [Header("Settings")]
    public Vector3 offset;

    [Header("References")]
    public Camera cam;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            Follow();
        }
    }

    private void Follow()
    {
        transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z) + offset;
    }
}
