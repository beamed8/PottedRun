using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OpponentAI : MonoBehaviour
{
    public static OpponentAI instance;

    [Header("Master Toggle")]
    public bool canMove = true;
    public bool canJump = true;

    [Header("Settings")]
    [Header("Movement")]
    public float moveSpeed = 2f;
    [Header("Jump")]
    public float jumpForce = 10f;
    public float jumpReleaseVel = 2f;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    [Header("Keybinds")]
    public KeyCode primaryJumpKey = KeyCode.Space;
    public KeyCode alternativeJumpKey = KeyCode.Mouse0;

    [Header("References")]
    public Rigidbody2D rb;
    private Animator animator;

    [Header("Particles")]
    public ParticleSystem dustParticles;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        canMove = PlayerMovement.instance.canMove;
        moveSpeed = PlayerMovement.instance.moveSpeed;

        var jumpInput = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0);
        var jumpInputReleased = Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (canMove)
        {
            Move();
            animator.SetBool("canMove", true);
        }
        else
        {
            animator.SetBool("canMove", false);
        }

        if (canJump && isGrounded)
        {
            if (jumpInput)
            {
                // isJumping = true;
                // jumpTimeCounter = jumpTime;
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                // rb.velocity = Vector2.up * jumpForce;
                Jump();
            }

            // if (Input.GetKey(primaryJumpKey) && isJumping)
            // {
            //     if (jumpTimeCounter > 0)
            //     {
            //         // rb.velocity = Vector2.up * jumpForce;
            //         rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //         Jump();
            //         jumpTimeCounter -= Time.deltaTime;
            //     }
            //     else
            //     {
            //         isJumping = false;
            //     }
            // }
        }

        if (jumpInputReleased && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / jumpReleaseVel);
            // isJumping = false;
        }


        if (rb.velocity.y == 0)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        // transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            PlayParticleEffect(dustParticles);
            animator.SetTrigger("jump");
            SoundManager.instance.PlayRandomFromList(SoundManager.instance.jumpingSounds);
        }
    }

    public void PlayerJumped()
    {
        StartCoroutine(AiJump());
    }

    private IEnumerator AiJump()
    {
        yield return new WaitForSeconds(0.28f);
        Jump();
    }

    private void PlayParticleEffect(ParticleSystem particle)
    {
        if (!particle.isPlaying)
        {
            particle.Play();
        }
        else
        {
            particle.Stop();
            particle.time = 0;
            particle.Play();
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
