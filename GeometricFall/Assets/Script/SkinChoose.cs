using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChoose : MonoBehaviour
{
    private int skinChoose;
    public List<Sprite> skin = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        //Met le skin choisi
        skinChoose = PlayerPrefs.GetInt("SkinChoose", 0);
        gameObject.GetComponent<SpriteRenderer>().sprite = skin[skinChoose];
    }
}
