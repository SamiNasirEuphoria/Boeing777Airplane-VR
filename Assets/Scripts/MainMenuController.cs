using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    
    public CanvasGroup mainMenuCanvasGroup,instructionCanvasGroup,quitCanvasGroup;

    public Button instructionPanel,quitPanel,closeInstructionPanel,closeQuitPanel, startButton, closeExpereinceButton;
    public Animator myAnimator;
    public float fadeDuration, startSceneConfig;

    void Start()
    {
        // Initialize canvas groups
        InitializeCanvasGroup(mainMenuCanvasGroup, false);
        InitializeCanvasGroup(instructionCanvasGroup, false);
        InitializeCanvasGroup(quitCanvasGroup, false);
        StartCoroutine(Fade(mainMenuCanvasGroup,1));
        // Set up button listeners
        instructionPanel.onClick.AddListener(ShowInstructionsPanel);
        quitPanel.onClick.AddListener(ShowQuitPanel);
        closeInstructionPanel.onClick.AddListener(CloseInstructionPanel);
        closeQuitPanel.onClick.AddListener(CloseQuitPanel);
        startButton.onClick.AddListener(StartExperience);
        closeExpereinceButton.onClick.AddListener(QuitApplication);

    }

    void InitializeCanvasGroup(CanvasGroup canvasGroup, bool startVisible)
    {
        canvasGroup.alpha = startVisible ? 1f : 0f;
        canvasGroup.interactable = startVisible;
        canvasGroup.blocksRaycasts = startVisible;
    }
    public void StartExperience()
    {
        StartCoroutine(FadeCanvasGroup(mainMenuCanvasGroup,0));
        myAnimator.SetTrigger("FadeIn");
        StartCoroutine(NextScene());
    }
    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(2.25f);
        SceneChanger.Instance.ChangeScene("URP-Tutorial-VR");
    }
    public void QuitApplication()
    {
        Application.Quit();
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
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime/fadeDuration);
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
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime/fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
        canvasGroup.interactable = targetAlpha == 1f;
        canvasGroup.blocksRaycasts = targetAlpha == 1f;
    }

    public void ShowInstructionsPanel()
    {
        HideCanvasGroup(mainMenuCanvasGroup);
        ShowCanvasGroup(instructionCanvasGroup);
    }

    public void ShowQuitPanel()
    {
        HideCanvasGroup(mainMenuCanvasGroup);
        ShowCanvasGroup(quitCanvasGroup);
    }

    public void CloseInstructionPanel()
    {
        HideCanvasGroup(instructionCanvasGroup);
        ShowCanvasGroup(mainMenuCanvasGroup);
    }

    public void CloseQuitPanel()
    {
        HideCanvasGroup(quitCanvasGroup);
        ShowCanvasGroup(mainMenuCanvasGroup);
    }
}
