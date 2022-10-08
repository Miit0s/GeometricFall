using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioSource musicSource;

    public void ReturnToMenu()
    {
        //Remet le temps en route
        Time.timeScale = 1f;
        //Change la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Met en pause le jeu (publique car on veut que ce soit accesible directement depuis unity pour qu'il execute la fontion quand on appuie sur certain boutton)
    public void PauseGame()
    {
        //Met en pause la musique
        musicSource.mute = true;

        //Arrête le temps
        Time.timeScale = 0f;
    }

    //Reprend le jeu
    public void ResumeGame()
    {
        //Cette fonction permet de ralentir le temps
        Time.timeScale = 1f;

        //Remet la musique
        musicSource.mute = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
