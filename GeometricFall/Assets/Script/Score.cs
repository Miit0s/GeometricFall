using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI highScore;

    private float bestScore = 0;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("0"); //Affiche le meilleur score des que le jeux se lance
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.position.y) > bestScore) //Permet de garder tout le temps la valeur la plus haute
        {
            bestScore = Mathf.Abs(player.position.y);
            scoreText.text = Mathf.Abs(player.position.y).ToString("0"); //Affiche le score
            finalScore.text = Mathf.Abs(player.position.y).ToString("0"); //Affiche le score final

            if (Mathf.Abs(player.position.y) > PlayerPrefs.GetFloat("HighScore", 0)) //Affiche et enregistre le meilleur score du joueur
            {
                PlayerPrefs.SetFloat("HighScore", Mathf.Abs(player.position.y));
                highScore.text = Mathf.Abs(player.position.y).ToString("0");
            }
        }
    }
}
