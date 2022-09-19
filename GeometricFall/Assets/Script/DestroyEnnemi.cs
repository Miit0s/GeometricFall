using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnnemi : MonoBehaviour
{
    private Rigidbody2D rb;
    private ParticleSystem particle;
    private Collider2D ennemiCollider;
    private Collider2D preCollider;
    private SpriteRenderer ennemiSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        particle = gameObject.GetComponent<ParticleSystem>();
        ennemiCollider = gameObject.GetComponent<PolygonCollider2D>();
        preCollider = gameObject.GetComponent<BoxCollider2D>();
        ennemiSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Regarde si la vitesse est sufisante pour détruire l'ennemi
            if (rb.velocity.y <= -15)
            {
                //On désactive tous ce qui ne doit plus être vue
                ennemiCollider.enabled = false;
                preCollider.enabled = false;
                ennemiSprite.enabled = false;

                //Effect de particule
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
