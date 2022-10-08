using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsScript : MonoBehaviour
{
    private static int coins = 0; //Toute les piece on une valeur coins diff�rente, on met donc static pour qu'elle est toute la m�me
    public TextMeshProUGUI coinsNumberText;
    public Animator coinsAnimation;

    //SFX
    public AudioClip newCoins;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("CoinsNumber", 0); //Prend le nombre de coins
        coinsNumberText.text = PlayerPrefs.GetInt("CoinsNumber", 0).ToString("0"); //Affiche l'argent que le joueur a d�s que le jeux se lance
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //V�rifie que c'est bien le joueur
        if (col.CompareTag("Player"))
        {
            SoundManager.Instance.PlaySound(newCoins); //On lance le son

            //Si le joueur touche la pi�ce, on ajoute plus 1 � son nombre de coins et on d�sactive l'objet
            coins += 1;
            PlayerPrefs.SetInt("CoinsNumber", coins);
            coinsNumberText.text = coins.ToString("0");
            coinsAnimation.SetBool("Animation", false);
            gameObject.SetActive(false);
        }
    }
}
