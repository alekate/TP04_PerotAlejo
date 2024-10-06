using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private float jump = 400f;
    private int points = 0;

    public bool isDead = false;

    [SerializeField] private GameObject UI;

    [SerializeField] private InitialGameData gameData; 

    [SerializeField] private Animator animator;

    [SerializeField] private AudioManager audioManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (isGrounded && !isDead)
        {
            if (Input.GetKeyDown(gameData.jump0))
            {
                rb.AddForce(Vector2.up * gameData.jumpForce);
                isGrounded = false;

                animator.SetTrigger("Jump");
                animator.SetBool("Ground", false);
                
                audioManager.JumpSFX();

            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioManager.LandSFX();
            animator.SetBool("Ground", true);
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {
            points++;
            UI.GetComponent<UI>().TextImport(points);
            Time.timeScale += 0.01f;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            audioManager.DieSFX();
            isDead = true;
            animator.SetTrigger("Die");
        }
    }
}

