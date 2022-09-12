using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public Animator textAnimator;
    public Animator highScoreAnimator;

    public void ReturnToMenu()
    {
        //Remet le temps en route
        Time.timeScale = 1f;
        //Change la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);  //Retourne au menu
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Relance le jeux
    }

    public void GameOver()
    {
        gameObject.SetActive(true); //Affiche l'écran de gameover

        textAnimator.SetTrigger("Idle"); //Lance l'animation
        highScoreAnimator.SetTrigger("Idle");
    }
}
