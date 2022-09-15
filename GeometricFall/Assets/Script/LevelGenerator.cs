using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject manager;
    public GameObject player;

    public List<GameObject> plateforme = new List<GameObject>();
    private int randomPlateforme;

    private float distance = -350f;

    public int platformCount = 300;

    // Start is called before the first frame update
    void Start()
    {
        //D�fini le son sauvegarder avant
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        //Met en place les plateforme
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            //Choisi une plateforme al�atoire
            randomPlateforme = Random.Range(0, 100);

            if (randomPlateforme < 70)
            {
                randomPlateforme = 0; //Plateforme normal
            }
            else if (randomPlateforme > 70 && randomPlateforme < 90)
            {
                randomPlateforme = 2; //Plateforme avec piece
            }
            else
            {
                randomPlateforme = 1; //Plateforme qui tue le joueur
            }

            spawnPosition.y -= Random.Range(0.5f, 2f);
            spawnPosition.x = Random.Range(-2.5f, 2.5f);
            Instantiate(plateforme[randomPlateforme], spawnPosition, Quaternion.identity, manager.transform);
        }
    }

    //G�n�ration infini
    void Update()
    {
        //Si le joueur arrive � une certaine distance on fait r�aparaitre des plateforme
        if (player.transform.position.y < distance)
        {
            Debug.Log("NewGeneration");

            //Va refaire appara�tre des plateforme
            Vector3 spawnPosition1 = new Vector3();
            spawnPosition1.y = player.transform.position.y - 20f;

            //Choisi une plateforme al�atoire
            randomPlateforme = Random.Range(0, 100);

            if (randomPlateforme < 70)
            {
                randomPlateforme = 0; //Plateforme normal
            }
            else if (randomPlateforme > 70 && randomPlateforme < 90)
            {
                randomPlateforme = 2; //Plateforme avec piece
            }
            else
            {
                randomPlateforme = 1; //Plateforme qui tue le joueur
            }

            for (int i = 0; i < 100; i++)
            {
                spawnPosition1.y -= Random.Range(0.5f, 2f);
                spawnPosition1.x = Random.Range(-2.5f, 2.5f);
                Instantiate(plateforme[randomPlateforme], spawnPosition1, Quaternion.identity, manager.transform);
            }

            //On r�augmente la distance pour refaire �a quand le joueur aura atteint la fin de ceux que nous avons fait r�aparaitre
            distance -= 123f;

        }
    }
}
