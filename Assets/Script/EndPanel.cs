using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text accuracyText;
    [SerializeField] TMP_Text commentText;

    [SerializeField] GameObject endGamePanel;  // Referens till själva panelen som ska visas

    void Start()
    {
        endGamePanel.SetActive(false);  // Gör panelen inaktiv till att börja med
    }

    public void ShowEndGamePanel()
    {
        endGamePanel.SetActive(true);  // Gör panelen synlig när spelet är slut

        // Uppdatera texten med score och accuracy
        int score = ScoreCounter.Score;
        float accuracy = (float)score / (score + MissCounter.Misses) * 100f;

        scoreText.text = $"Score: {score}";
        accuracyText.text = $"Accuracy: {accuracy.ToString("0")}%";

        // Kommentera baserat på score och accuracy
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
