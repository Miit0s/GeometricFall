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

    private GameObject shield;
    private Animator shieldAnimation;

    //SFX
    public AudioClip deathSound;
    public AudioClip destroyShield;

    void Start()
    {
        //Optimisation
        player = GameObject.FindWithTag("Player");
        playerSprite = player.GetComponent<SpriteRenderer>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        playerParticle = player.GetComponent<ParticleSystem>();
        playerRb = player.GetComponent<Rigidbody2D>();

        shield = GameObject.FindGameObjectWithTag("Shield");
        shieldAnimation = shield.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vérifie que c'est bien le joueur
        if (collision.collider.CompareTag("Player") && shield.GetComponent<SpriteRenderer>().enabled == false)
        {
            //Va freeze le joueur, puis désactiver son sprite renderer et son collider et enfin activer les particule
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;

            SoundManager.Instance.PlaySound(deathSound); //On lance le son

            playerSprite.enabled = false;
            playerCollider.enabled = false;
            playerParticle.Play(); //Démare les particule

            //Active l'UI
            gameOverScreen.GameOver();
        }
        else
        {
            //Sinon ont démarre la désactivation du shield
            StartCoroutine(Invinsibilte());
        }
    }

    private IEnumerator Invinsibilte()
    {
        SoundManager.Instance.PlaySound(destroyShield);

        shieldAnimation.SetBool("ActiveShield", false);
        shieldAnimation.SetTrigger("Destruction");
        yield return new WaitForSeconds(2f);
        shield.GetComponent<SpriteRenderer>().enabled = false;
    }
}
