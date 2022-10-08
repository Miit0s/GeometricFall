using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSideLeft : MonoBehaviour
{
    private Transform player;
    public TrailRenderer playerTrail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine("trail");

            //Replace le joueur de l'autre c�t�
            Vector3 spawnPosition = new Vector3();

            player = collision.GetComponent<Transform>();
            spawnPosition = player.position;
            spawnPosition.x = 2.05f;
            player.position = spawnPosition;

           
        }
    }

    private IEnumerator trail()
    {
        //D�sactive le trail pour �viter des effect bizzare
        playerTrail.enabled = false;
        yield return new WaitForSeconds(0.17f);
        playerTrail.enabled = true;
    }
}
