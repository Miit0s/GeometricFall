using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlateform : MonoBehaviour
{
    Rigidbody2D rb;
    ParticleSystem particle;
    GameObject player;

    SpriteRenderer platformSprite;
    BoxCollider2D plateformCollider;
    BoxCollider2D prePlatform;

    private void Start()
    {
        //Prend toute les valeur en avance pour éviter de le faire à chaque fois
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        particle = gameObject.GetComponent<ParticleSystem>();

        platformSprite = transform.parent.GetComponent<SpriteRenderer>();
        plateformCollider = transform.parent.GetComponent<BoxCollider2D>();
        prePlatform = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vérifie que c'est bien le joueur
        if (collision.CompareTag("Player"))
        {
            //Regarde si la vitesse est sufisante pour briser la plateforme
            if (rb.velocity.y <= -15)
            {
                //Effect de particule
                platformSprite.enabled = false;
                plateformCollider.enabled = false;
                prePlatform.enabled = false;
                particle.Play();

                //On amorce la destruction
                StartCoroutine(Coroutine());
            }

        }
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
