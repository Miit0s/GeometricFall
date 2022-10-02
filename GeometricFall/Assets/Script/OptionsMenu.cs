using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeBar;
    public TextMeshProUGUI volumeText;
    private float volume;

    private void Awake()
    {
        Load();
    }

    //Fonction qui change le volume
    public void changeVolume()
    {
        //Sauvegarde le volume, puis l'affiche
        volume = volumeBar.value;
        //*100 car la valeur de son est comprise entre 0 et 1
        volumeText.text = (volumeBar.value * 100).ToString("0");
        Save();
    }

    private void Load()
    {
        //Remet à jour le volume sauvegarder
        volumeBar.value = (float)PlayerPrefs.GetFloat("musicVolume", 1);
    }

    private void Save()
    {
        //Sauvegarde le volume de la musique
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
}
