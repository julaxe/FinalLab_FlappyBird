using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public int Score;
    public bool gameOver;

    private Rigidbody2D rb;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameOver = false;
        animator.SetBool("Die", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Vector3 direction = new Vector3(10.0f, rb.velocity.y, 0.0f);
            transform.right = direction.normalized;

            if (Input.touchCount > 0)
            {
                Jump();
                animator.SetBool("Flap", true);
            }
            else
            {
                animator.SetBool("Flap", false);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(0.0f, 5.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetBool("Die", true);
        gameOver = true;
    }
}
