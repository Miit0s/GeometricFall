using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiGenerator : MonoBehaviour
{
    private GameObject ennemi;
    private Transform playerPosition;
    private int randomNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        //Optimisation
        ennemi = GameObject.FindGameObjectWithTag("Ennemi");
        playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Boucle(); //Début de la boucle
    }

    //Permet de crée une boucle
    private void Boucle() { StartCoroutine("Coroutine"); }

    //Un chance sur 12 qu'un ennemi spawn toute les 2 secondes
    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(2f);
        randomNumber = Random.Range(1, 13);

        if (randomNumber == 5)
        {
            Debug.Log("Apparition d'un ennemi");
            Instantiate(ennemi, new Vector3(playerPosition.position.x + Random.Range(-2f, 2.01f), playerPosition.position.y - 20, playerPosition.position.z), Quaternion.identity, gameObject.transform);
        }

        Boucle();
    }
}
