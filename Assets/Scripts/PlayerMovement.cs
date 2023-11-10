using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace AE0672
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D playerRb;
        // Reference to the player's rigidbody
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        private float directionX = 0f;
        [SerializeField] float speed = 8f;
        [SerializeField] float jumpForce = 15f;

        //Now I want to use enum to check the status of the player, for better animation control, since the player can only be in one state at a time.

        private enum PlayerStatus { idle, running, jumping, falling }
        // the index of the enum is the status of the player, so idle is 0, running is 1, jumping is 2, falling is 3.

        private BoxCollider2D boxCollider2D;
        // I want to use boxcast to check if the player is on the ground, so I need a box collider to do that.
        [SerializeField] private LayerMask groundLayerMask;

        [SerializeField] private AudioSource jumpAudioSource;

        public bool facingRight = true;


        // Start is called before the first frame update
        private void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            boxCollider2D = GetComponent<BoxCollider2D>();


        }

        // Update is called once per frame
        private void Update()
        {
            directionX = Input.GetAxis("Horizontal");

            playerRb.velocity = new Vector2(directionX * speed, playerRb.velocity.y);



            if (Input.GetKeyDown("space") && IsGrounded())
            {
                jumpAudioSource.Play();
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            }
            AnimationCheckStatus();

            if (directionX > 0f)
            {
                facingRight = true;
            }
            else if (directionX < 0f)
            {
                facingRight = false;
            }
            if (facingRight)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }

        private void AnimationCheckStatus()
        {
            PlayerStatus status;
            if (directionX > 0f)
            {
                status = PlayerStatus.running;

            }
            else if (directionX < 0f)
            {
                status = PlayerStatus.running;

            }
            else
            {
                status = PlayerStatus.idle;
            }

            if (playerRb.velocity.y > 0.1f)
            {
                status = PlayerStatus.jumping;
            }
            else if (playerRb.velocity.y < -0.1f)
            {
                status = PlayerStatus.falling;
            }
            animator.SetInteger("status", (int)status);

        }

        private bool IsGrounded()
        {
            return Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        }

        public float GetDirectionX()
        {
            return directionX;
        }

    }
}
