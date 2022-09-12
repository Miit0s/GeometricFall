using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public Joystick joystick;
    Vector2 velocity;

    float movement = 0f;
    public float movementSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Mouvement avec le doigt du joueur
    void Update()
    {
        //Au lieu de Input.GetAxisRaw("Horizontal") on utilise joystick.Horizontal
        movement = joystick.Horizontal * movementSpeed;
    }

    void FixedUpdate()
    {
        velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }
}
