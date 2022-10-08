using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{
    private int index = 0;
    public Image skinPresentation;
    public TextMeshProUGUI price;
    public List<int> skinPrice = new List<int>(); //Contient le prix en int
    public List<string> skinPriceText = new List<string>(); //Contient se que le texte doit écrire (pour pouvoir changer par "Pick" si le joueur possède le skin
    public List<Sprite> skin = new List<Sprite>();

    public GameObject leftButton;
    public GameObject rightButton;

    private int coins;
    public TextMeshProUGUI coinsAmount;

    //On ne peut pas sauvegarder des booléen avec playerprefs, donc si skin1 = 0, alors le joueur n'a pas dévérouiller le skin et si skin1 = 1, il l'a dévérouillier
    private int skin1;
    private int skin2;
    private int skin3;
    private int skin4;

    //SFX
    public AudioClip newItem;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("CoinsNumber", 0); //Argent qu'a le joueur

        //Skin que le joueur possède
        skin1 = PlayerPrefs.GetInt("Skin1", 0);
        skin2 = PlayerPrefs.GetInt("Skin2", 0);
        skin3 = PlayerPrefs.GetInt("Skin3", 0);
        skin4 = PlayerPrefs.GetInt("Skin4", 0);

        //Va permettre de mettre en place la liste pour que le joueur puisse avoir
        if (skin1 == 1) { skinPriceText[1] = "Pick"; }
        if (skin2 == 2) { skinPriceText[2] = "Pick"; }
        if (skin3 == 3) { skinPriceText[3] = "Pick"; }
        if (skin4 == 4) { skinPriceText[4] = "Pick"; }
    }

    private void Update()
    {
        //Désactive le gameobject pour que le joueur ne puisse pas cliquer alors qu'il n'y plus de skin après
        if (index == 0) { leftButton.SetActive(false); }
        else if (index == skin.Count - 1 ) { rightButton.SetActive(false); }
        else
        {
            leftButton.SetActive(true);
            rightButton.SetActive(true);
        }

        //Affiche l'argent du joueur.
        //Mis dans update car quand le joueur achète qq chose, sont nombre de pièce doit être mis à jour.
        coinsAmount.text = PlayerPrefs.GetInt("CoinsNumber", 0).ToString("0");
    }

    public void Left()
    {
        //Affiche le skin précédant dans la liste et le prix du skin
        index -= 1;
        skinPresentation.sprite = skin[index];
        price.text = skinPriceText[index];
    }

    public void Right()
    {
        //Affiche le skin suivant dans la liste et le prix du skin
        index += 1;
        skinPresentation.sprite = skin[index];
        price.text = skinPriceText[index];
    }

    public void PaySkin()
    {
        //Si le joueur possède le skin, va appliquer le skin, sinon va regarder si le joueur peut l'achter
        if (skinPriceText[index] == "Pick")
        {
            PlayerPrefs.SetInt("SkinChoose", index);
        }
        else if (skinPrice[index] < coins)
        {
            SoundManager.Instance.PlaySound(newItem); //On lance le son

            coins -= skinPrice[index];
            PlayerPrefs.SetInt("CoinsNumber", coins);
            PlayerPrefs.SetInt("Skin" + index.ToString("0"), 1);
            skinPriceText[index] = "Pick";
            price.text = "Pick";

        }
        else
        {
            Debug.Log("Pas assez d'argent ou pas encore obtenue");
        }
    }

    public void Exit()
    {
        //Change la scène
        SceneManager.LoadScene(0);
    }
}
