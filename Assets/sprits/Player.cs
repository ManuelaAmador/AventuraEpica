using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f; // velocidad de movimiento
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Manejar movimiento
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true);

            float moveVertical = Input.GetAxis("Vertical");
            float newY = transform.position.y + moveVertical * speed * Time.deltaTime;

            // Limitar movimiento vertical
            float upperLimit = 2.0f;
            float lowerLimit = -3.0f;

            if (newY <= upperLimit && newY >= lowerLimit)
            {
                transform.position = new Vector2(transform.position.x, newY);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Manejar ataque
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isAttacking", true);
        }
        else if (!Input.GetMouseButton(0))
        {
            animator.SetBool("isAttacking", false);
        }
    }

    // Método para verificar si el jugador está corriendo
    public bool IsRunning()
    {
        return animator.GetBool("isRunning");
    }
}