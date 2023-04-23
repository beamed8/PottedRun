using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
    ex. You have 3 different layers of backgrounds
    - duplicate them all
    - move all 3 duplicated gameobjects to the right side of the main 3
    - note the x difference of these duplicated ones to the main ones
    - do the same for the left side
    - group same layers under the first gameobject
    - add this script to all 3 parent gameobjects
    - set the x difference to the "diff" variable
    - set ascending or descending speeds, the closest layer should be the fastest
*/

public class AutoParallax : MonoBehaviour
{
    public bool canMove = true;

    [SerializeField] private Camera cam;
    [SerializeField] private float speed, diff;

    private void Start()
    {
        if (cam == null) cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0f, 0f);

        if (cam.transform.position.x >= transform.position.x + diff)
        {
            transform.position = new Vector2(cam.transform.position.x + diff, transform.position.y);
        }
    }

    public void StartMoving()
    {
        canMove = true;
    }

    public void StopMoving()
    {
        canMove = false;
    }
}
