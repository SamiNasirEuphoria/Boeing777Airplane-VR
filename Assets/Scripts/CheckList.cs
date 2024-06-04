using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheckList : MonoBehaviour
{
    public Button[] button;
    public Sprite clickedButton;
    private int clickedButtonCount, totalButtons;
    private CanvasGroup canvesGroup;
    private float time, resetAlpha = 0f, setAlpha = 1f;
    public float delayTime, setActiveTimer, setInactiveTimer;
    private bool forward, reverse;
    private void Start()
    {
        canvesGroup = GetComponent<CanvasGroup>();
        clickedButtonCount = 0;
        totalButtons = button.Length;
        for (int i=0; i < totalButtons; i++)
        {
            var num = i;
            button[i].onClick.AddListener(() => ClickMethod(button[num]));
        }
    }
    public void ClickMethod(Button thisButton)
    {
        clickedButtonCount++;
        thisButton.GetComponent<Image>().sprite = clickedButton;
        if(clickedButtonCount== totalButtons)
        {
            DisablePanel();
        }
    }
    private void FixedUpdate()
    {
        if (forward)
        {
            time += Time.fixedDeltaTime / delayTime;
            canvesGroup.alpha = time;
            if (canvesGroup.alpha == 1)
            {
                forward = false;
            }
        }
        else if (reverse)
        {
            time -= Time.fixedDeltaTime / delayTime;
            canvesGroup.alpha = time;
            if (canvesGroup.alpha == 0)
            {
                reverse = false;
            }
        }
    }
    public void EnablePanel()
    {
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeEffect");
        ObjectReferenceContainer.Instance.movementController.SetActive(false);
        StartCoroutine(EnableMe());
    }
    IEnumerator EnableMe()
    {
        yield return new WaitForSeconds(2.0f);
        UIReferenceContainer.Instance.exitAreaMessage.SetActive(false);
        UIReferenceContainer.Instance.CF2Panel.SetActive(false);
        ObjectReferenceContainer.Instance.movementController.SetActive(false);
        ObjectReferenceContainer.Instance.controlPanel.SetActive(false);
        UIReferenceContainer.Instance.backButton.SetActive(false);
        ObjectReferenceContainer.Instance.airplaneObject.SetActive(false);
        ObjectReferenceContainer.Instance.outerSphere.SetActive(true);
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.2f);
        //dealing with UI
        if (!canvesGroup.blocksRaycasts)
        {
            time = resetAlpha;
            forward = true;
            reverse = false;
            canvesGroup.alpha = resetAlpha;
            canvesGroup.blocksRaycasts = true;
        }
    }
    public void DisablePanel()
    {
        if (canvesGroup.blocksRaycasts)
        {
            reverse = true;
            time = setAlpha;
            canvesGroup.alpha = setAlpha;
            canvesGroup.blocksRaycasts = false;
            StartCoroutine(BackToMainScene());
        }
    }
    IEnumerator BackToMainScene()
    {
        yield return new WaitForSeconds(3.5f);
        UIReferenceContainer.Instance.narationPanelConclusion.SetActive(true);
    }
}
