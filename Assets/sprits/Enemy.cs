using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float patrolSpeed = 2.0f; // Velocidad de patrulla
    public float attackSpeed = 5.0f; // Velocidad de ataque
    public float patrolRange = 3.0f; // Rango de patrulla
    public float visionRange = 3.0f; // Rango de visión

    private bool movingRight = true;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PJ").transform;
    }

    void Update()
    {
        Patrol();

        // Verificar si el jugador está dentro del rango de visión
        if (Vector2.Distance(transform.position, player.position) < visionRange)
        {
            // Detener la patrulla y atacar al jugador
            MoveTowardsPlayer();
        }
    }

    void Patrol()
    {
        // Movimiento horizontal de patrulla
        if (movingRight)
        {
            transform.Translate(Vector2.right * patrolSpeed * Time.deltaTime);
            transform.localScale = new Vector3(1, 1, 1); // mira a la derecha
        }
        else
        {
            transform.Translate(Vector2.left * patrolSpeed * Time.deltaTime);
            transform.localScale = new Vector3(-1, 1, 1); // mira a la izquierda
        }

        // Cambiar dirección si alcanza los límites de patrulla
        if (Mathf.Abs(transform.position.x) >= patrolRange)
        {
            movingRight = !movingRight;
        }
    }

    void MoveTowardsPlayer()
    {
        // Calcular dirección hacia el jugador
        Vector2 direction = player.position - transform.position;
        direction.Normalize();

        // Moverse hacia el jugador
        transform.Translate(direction * attackSpeed * Time.deltaTime);
    }
}
