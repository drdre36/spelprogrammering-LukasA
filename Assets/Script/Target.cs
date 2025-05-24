using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public static Action OnTargetHit;
    public AudioSource pingSoundEffect;

    void Start()
    {
        RandomizePosition();
        pingSoundEffect = GetComponent<AudioSource>();

        if (pingSoundEffect == null)
        {
            Debug.LogError("AudioSource saknas p� objektet: " + gameObject.name);
        }
    }

    public void Hit()
    {
        // Spela upp ljudet n�r target tr�ffas
        pingSoundEffect.Play();
        RandomizePosition();
        OnTargetHit?.Invoke();
    }

    void RandomizePosition()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }
}
