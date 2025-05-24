using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text accuracyText;
    [SerializeField] TMP_Text commentText;

    [SerializeField] GameObject endGamePanel;  // Referens till sj�lva panelen som ska visas

    void Start()
    {
        endGamePanel.SetActive(false);  // G�r panelen inaktiv till att b�rja med
    }

    public void ShowEndGamePanel()
    {
        endGamePanel.SetActive(true);  // G�r panelen synlig n�r spelet �r slut

        // Uppdatera texten med score och accuracy
        int score = ScoreCounter.Score;
        float accuracy = (float)score / (score + MissCounter.Misses) * 100f;

        scoreText.text = $"Score: {score}";
        accuracyText.text = $"Accuracy: {accuracy.ToString("0")}%";

        // Kommentera baserat p� score och accuracy
        if (accuracy > 90)
        {
            commentText.text = "RANK: ELITE";
        }
        else if (accuracy > 50)
        {
            commentText.text = "RANK: VETERAN";
        }
        else
        {
            commentText.text = "RANK: ROOKIE";
        }
    }
}
