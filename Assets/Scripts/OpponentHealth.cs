using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpponentHealth : MonoBehaviour
{
    public static OpponentHealth instance;

    [Header("Health Stats")]
    public float currentHealth;
    public float maxHealth = 1;

    [Header("References")]
    private Collider2D col;
    private Animator anim;
    public RectTransform avatar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Hit()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            Death(true);
        }
        else
        {
            // hit?
        }
    }

    public void Death(bool withAnim)
    {
        // NetworkController.instance.GameEnded();
        // MultiplayerSequence.instance.PlayerWon();

        OpponentAI pm = GetComponent<OpponentAI>();
        pm.canMove = false;
        pm.canJump = false;
        pm.rb.velocity = Vector2.zero;

        PlayerMovement om = PlayerMovement.instance;
        om.canMove = false;
        om.canJump = false;
        om.rb.velocity = Vector2.zero;

        SoundManager.instance.PlaySfx(SoundManager.instance.playerHit);

        Camera.main.GetComponent<CameraFollow>().isFollowing = false;

        if (withAnim)
        {
            pm.rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            pm.rb.AddForce(Vector2.right * 2.5f, ForceMode2D.Impulse);
        }

        Camera.main.DOShakePosition(0.5f, 0.1f);
        avatar.DOShakePosition(0.5f, 0.25f);

        AutoParallax[] bgs = GameObject.FindObjectsOfType<AutoParallax>();

        foreach (AutoParallax bg in bgs)
        {
            bg.StopMoving();
        }

        currentHealth = 0;

        col.enabled = false;
        anim.SetTrigger("death");

        LevelManager.instance.GameOver();

        //level handler - game over
    }

    public void StopGame(bool withAnim)
    {
        OpponentAI om = GetComponent<OpponentAI>();
        om.canMove = false;
        om.canJump = false;
        om.rb.velocity = Vector2.zero;

        PlayerMovement pm = PlayerMovement.instance;
        pm.canMove = false;
        pm.canJump = false;
        pm.rb.velocity = Vector2.zero;

        SoundManager.instance.PlaySfx(SoundManager.instance.playerHit);

        Camera.main.GetComponent<CameraFollow>().isFollowing = false;

        if (withAnim)
        {
            om.rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            om.rb.AddForce(Vector2.right * 2.5f, ForceMode2D.Impulse);
        }

        Camera.main.DOShakePosition(0.5f, 0.1f);
        avatar.DOShakePosition(0.5f, 0.25f);

        AutoParallax[] bgs = GameObject.FindObjectsOfType<AutoParallax>();

        foreach (AutoParallax bg in bgs)
        {
            bg.StopMoving();
        }

        currentHealth = 0;

        col.enabled = false;
        anim.SetTrigger("death");

        LevelManager.instance.GameOver();
    }
}
