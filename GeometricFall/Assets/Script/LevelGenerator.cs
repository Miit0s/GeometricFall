using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private GameObject manager;
    public GameObject player;

    public List<GameObject> plateforme = new List<GameObject>();
    private int randomPlateforme;

    private float distance = -350f;

    public int platformCount = 300;

    //Ces variable vont permettre d'augmenter la difficult�
    private int palierDeDifficult� = -500;
    private int apparitionPlateformeRouge = 90;
    private int apparitionPlateformePiece = 70;
    private int apparitionPlateformeBouclier = 68;
    private int apparitionPlateformeNormal = 68;

    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject;

        //D�fini le son sauvegarder avant
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        //Met en place les plateforme
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            //Choisi une plateforme al�atoire
            randomPlateforme = Random.Range(0, 100);

            if (randomPlateforme < 68)
            {
                randomPlateforme = 0; //Plateforme normal
            }
            else if (randomPlateforme >= 68 && randomPlateforme < 70)
            {
                Debug.Log("Plateforme avec bouclier");
                randomPlateforme = 3; //Plateforme avec bouclier
            }
            else if (randomPlateforme >= 70 && randomPlateforme < 90)
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
        //Plus le joueur va descendre, plus il y aura de plateforme rouge
        if (player.transform.position.y < palierDeDifficult�)
        {
            Debug.Log("Palier de difficult� augmenter");

            palierDeDifficult� -= 500;

            if (palierDeDifficult� == 10000)
            {
                apparitionPlateformeBouclier = 0;
                apparitionPlateformeNormal -= 1;
                apparitionPlateformePiece -= 1;
                apparitionPlateformeRouge -= 1;
            }
            else
            {
                apparitionPlateformeNormal -= 1;
                apparitionPlateformeBouclier -= 1;
                apparitionPlateformePiece -= 1;
                apparitionPlateformeRouge -= 1;
            }
        }

        //Si le joueur arrive � une certaine distance on fait r�aparaitre des plateforme
        if (player.transform.position.y < distance)
        {
            Debug.Log("NewGeneration");

            //Va refaire appara�tre des plateforme
            Vector3 spawnPosition1 = new Vector3();
            spawnPosition1.y = player.transform.position.y - 20f;

            for (int i = 0; i < 100; i++)
            {
                //Choisi une plateforme al�atoire
                randomPlateforme = Random.Range(0, 100);

                if (randomPlateforme > 0 && randomPlateforme < apparitionPlateformeNormal)
                {
                    randomPlateforme = 0; //Plateforme normal
                }
                else if (randomPlateforme >= apparitionPlateformeBouclier && randomPlateforme < apparitionPlateformePiece && apparitionPlateformeBouclier != 0)
                {
                    randomPlateforme = 3; //Plateforme avec bouclier
                }
                else if (randomPlateforme >= apparitionPlateformePiece && randomPlateforme < apparitionPlateformeRouge)
                {
                    randomPlateforme = 2; //Plateforme avec piece
                }
                else
                {
                    randomPlateforme = 1; //Plateforme qui tue le joueur
                }

                spawnPosition1.y -= Random.Range(0.5f, 2f);
                spawnPosition1.x = Random.Range(-2.5f, 2.5f);
                Instantiate(plateforme[randomPlateforme], spawnPosition1, Quaternion.identity, manager.transform);
            }

            //On r�augmente la distance pour refaire �a quand le joueur aura atteint la fin de ceux que nous avons fait r�aparaitre
            distance -= 123f;

        }
    }
}
