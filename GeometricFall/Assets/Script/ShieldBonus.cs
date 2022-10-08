using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBonus : MonoBehaviour
{
    private GameObject shield;
    private Animator shieldAnimation;

    //SFX
    public AudioClip shieldActivation;

    // Start is called before the first frame update
    void Start()
    {
        //Optimisation
        shield = GameObject.FindGameObjectWithTag("Shield");
        shieldAnimation = shield.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Vérifie que c'est bien le joueur
        if (collision.CompareTag("Player"))
        {
            //On affiche le bouclier
            shield.GetComponent<SpriteRenderer>().enabled = true;
            shieldAnimation.SetBool("ActiveShield", true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            SoundManager.Instance.PlaySound(shieldActivation); //On lance le son
            StartCoroutine(Destruction()); //On démare la destruction de l'objet
        }
    }

    private IEnumerator Destruction()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
