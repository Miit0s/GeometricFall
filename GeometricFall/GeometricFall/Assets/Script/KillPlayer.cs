using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer playerSprite;
    private BoxCollider2D playerCollider;
    private ParticleSystem playerParticle;
    private Rigidbody2D playerRb;

    public GameOverMenu gameOverScreen;
    
    void Start()
    {
        //Optimisation
        player = GameObject.FindWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        playerParticle = player.GetComponent<ParticleSystem>();
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vérifie que c'est bien le joueur
        if (collision.collider.CompareTag("Player"))
        {
            //Va freeze le joueur, puis désactiver son sprite renderer et son collider et enfin activer les particule
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;

            playerSprite.enabled = false;
            playerCollider.enabled = false;
            playerParticle.Play(); //Démare les particule

            //Active l'UI
            gameOverScreen.GameOver();
        }
    }
}
