using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    public Slider volumeBar;
    public TextMeshProUGUI volumeText;
    private int volume = 100;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetInt("musicVolume", 100);
            Load();
        }

        else
        {
            Load();
        }
    }

    //Fonction qui change le volume
    public void changeVolume()
    {
        volume = Convert.ToInt32(volumeBar.value);
        volumeText.text = Convert.ToString(volume);
        AudioListener.volume = volume;
        Save();
    }

    private void Load()
    {
        //Remet à jour le volume sauvegarder
        volumeBar.value = PlayerPrefs.GetInt("musicVolume");
    }

    private void Save()
    {
        //Sauvegarde le volume de la musique
        PlayerPrefs.SetInt("musicVolume", volume);
    }
}
