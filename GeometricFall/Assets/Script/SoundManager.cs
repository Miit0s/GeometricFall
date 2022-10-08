using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //L'instance ne va jamais �tre d�truite pour permettre de tout le temps garder la m�me valeur
    //Permet d'�viter aussi que le son se coupe entre les sc�ne
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource, effectSource;

    private void Awake()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume", 1);

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Si l'instance existe d�j�, on d�truit l'autre
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void ChangerMasterVolume(float value)
    {
        AudioListener.volume = value;
    }
}
