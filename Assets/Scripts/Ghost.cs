using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost;
    public bool createGhost;
    // Start is called before the first frame update
    void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (createGhost)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else
            {
                GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
                Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
                currentGhost.GetComponent<SpriteRenderer>().flipX = this.GetComponent<SpriteRenderer>().flipX;
                currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
                ghostDelaySeconds = ghostDelay;
                Destroy(currentGhost, 1f);
            }
        }
    }
}
