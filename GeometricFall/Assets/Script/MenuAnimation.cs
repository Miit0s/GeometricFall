using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimation : MonoBehaviour
{
    private GameObject player;
    private TrailRenderer playerTrail;
    public List<Sprite> skin = new List<Sprite>();
    private int randomSkin;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTrail = player.GetComponent<TrailRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Vérifie que c'est bien le joueur
        if (col.CompareTag("Player"))
        {
            randomSkin = Random.Range(0, 5);

            playerTrail.enabled = false;
            player.GetComponent<Transform>().position = new Vector3(Random.Range(-2.05f, 2.06f), Random.Range(5.5f, 10.1f), 0);
            player.GetComponent<SpriteRenderer>().sprite = skin[randomSkin];
            StartCoroutine("stopSpeed");
        }
    }

    private IEnumerator stopSpeed()
    {
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        yield return new WaitForSeconds(1f);
        playerTrail.enabled = true;
        player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
