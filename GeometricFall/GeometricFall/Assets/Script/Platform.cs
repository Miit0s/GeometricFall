using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vérifie que c'est bien le joueur
        if (collision.collider.CompareTag("Player")){

            //Vérifie si le joueur arrive bien d'en haut
            if (collision.relativeVelocity.y <= 0f)
            {
                //Prend le composant ridgidbody
                rb = collision.collider.GetComponent<Rigidbody2D>();

                //Va faire rebondir notre joueur
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
                
            }
        }
    }
}
