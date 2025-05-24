using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image fadePanel;
    public float fadeDuration = 1f;
    public string sceneToLoad = "SampleScene";

    void Start()
    {
        // Starta med fade in från svart
        StartCoroutine(FadeIn());
    }

    public void FadeToScene()
    {
        StartCoroutine(FadeOutAndLoad());
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float alpha = t / fadeDuration;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadePanel.raycastTarget = false; // Låt knapptryck gå igenom
    }

    IEnumerator FadeOutAndLoad()
    {
        fadePanel.raycastTarget = true; // Blockera klick
        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = t / fadeDuration;
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
