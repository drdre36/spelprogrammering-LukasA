using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Action OnGameEnded;

    public static bool GameEnded { get; private set; }

    [SerializeField] TMP_Text timerText;            // Text som visar tiden
    [SerializeField] EndPanel endPanel;             // Slutpanel
    [SerializeField] AudioSource segerSoundEffect;  // Ljud f�r seger

    private PlayerController playerController;

    float endTime;
    const float gameTime = 64f;

    void Start()
    {
        GameEnded = false;
        endTime = Time.time + gameTime;

        // Modern metod f�r att hitta spelarkontrollen
        playerController = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        if (GameEnded)
            return;

        float timeLeft = endTime - Time.time;

        if (timeLeft <= 0)
        {
            GameEnded = true;
            OnGameEnded?.Invoke();

            timeLeft = 0;

            PlayVictorySound();
            endPanel.ShowEndGamePanel();

            // L�s upp musen och stoppa kamerar�relse
            if (playerController != null)
                playerController.allowLook = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        timerText.text = $"Time Left: {timeLeft.ToString("0.0")}";
    }

    private void PlayVictorySound()
    {
        if (segerSoundEffect != null)
        {
            segerSoundEffect.Play();
        }
        else
        {
            Debug.LogWarning("SegerSoundEffect �r inte tilldelad!");
        }
    }
}
