using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public CanvasGroup firstCanvasGroup, secondCanvasGroup, thirdCanvasGroup, fourthCanvesGroup;

    public Button firstNextButton, secondNextButton, thirdNextButton, fourthNextButton;
    public Animator myAnimator;
    public float fadeDuration, startSceneConfig;

    void Start()
    {
        // Initialize canvas groups
        InitializeCanvasGroup(firstCanvasGroup, false);
        InitializeCanvasGroup(secondCanvasGroup, false);
        InitializeCanvasGroup(thirdCanvasGroup, false);
        InitializeCanvasGroup(fourthCanvesGroup, false);
        StartCoroutine(Fade(firstCanvasGroup, 1));
        // Set up button listeners
        firstNextButton.onClick.AddListener(FirstNextButton);
        secondNextButton.onClick.AddListener(SecondNextButton);
        thirdNextButton.onClick.AddListener(ThirdNextButton);
        fourthNextButton.onClick.AddListener(FourthNextButton);

    }
    public void FirstNextButton()
    {
        ShowCanvasGroup(secondCanvasGroup);
        HideCanvasGroup(firstCanvasGroup);
    }
    public void SecondNextButton()
    {
        ShowCanvasGroup(thirdCanvasGroup);
        HideCanvasGroup(secondCanvasGroup);
    }
    public void ThirdNextButton()
    {
        ShowCanvasGroup(fourthCanvesGroup);
        HideCanvasGroup(thirdCanvasGroup);
    }
    public void FourthNextButton()
    {
        StartExperience();
    }
    void InitializeCanvasGroup(CanvasGroup canvasGroup, bool startVisible)
    {
        canvasGroup.alpha = startVisible ? 1f : 0f;
        canvasGroup.interactable = startVisible;
        canvasGroup.blocksRaycasts = startVisible;
    }
    public void StartExperience()
    {
        StartCoroutine(FadeCanvasGroup(firstCanvasGroup, 0));
        myAnimator.SetTrigger("FadeIn");
        StartCoroutine(NextScene());
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2.25f);
        SceneChanger.Instance.ChangeScene("URP-Scene-VR");
    }
   
    void ShowCanvasGroup(CanvasGroup canvasGroup)
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, 1f));
    }

    void HideCanvasGroup(CanvasGroup canvasGroup)
    {
        StartCoroutine(FadeCanvasGroup(canvasGroup, 0f));
    }
    IEnumerator Fade(CanvasGroup canvasGroup, float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        canvasGroup.interactable = targetAlpha == 1f;
        canvasGroup.blocksRaycasts = targetAlpha == 1f;
    }
    IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float targetAlpha)
    {
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        canvasGroup.interactable = targetAlpha == 1f;
        canvasGroup.blocksRaycasts = targetAlpha == 1f;
    }
}
