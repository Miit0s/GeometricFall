using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //L'instance ne va jamais être détruite pour permettre de tout le temps garder la même valeur
    //Permet d'éviter aussi que le son se coupe entre les scène
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
            //Si l'instance existe déjà, on détruit l'autre
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
