using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreenEffect : MonoBehaviour
{
    public float fadeDuration = 2f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        // Get the CanvasGroup component
        canvasGroup = GetComponent<CanvasGroup>();

        // Start the fade-in effect
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;

        // Gradually increase alpha from 0 to 1 over fadeDuration seconds
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            yield return null;
        }

        // Ensure the alpha reaches exactly 1 at the end
        canvasGroup.alpha = 1f;

        // Wait for a moment (you can adjust this time if needed)
        yield return new WaitForSeconds(1f);

        // Start the fade-out effect
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;
        UIReferenceContainer.Instance.joystick.SetActive(false);
        UIReferenceContainer.Instance.crosshair.SetActive(false);
        UIReferenceContainer.Instance.narationPanelConclusion.SetActive(true);
        // Gradually decrease alpha from 1 to 0 over fadeDuration seconds
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            yield return null;
        }

        // Ensure the alpha reaches exactly 0 at the end
        canvasGroup.alpha = 0f;

        // You can add additional actions or transitions here after the fade-out

        // For demonstration purposes, let's restart the fade-in
        this.gameObject.SetActive(false);
    }

}
