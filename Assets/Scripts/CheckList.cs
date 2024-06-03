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
        UIReferenceContainer.Instance.exitAreaMessage.SetActive(false);
        UIReferenceContainer.Instance.CF2Panel.SetActive(false);
        if (!canvesGroup.blocksRaycasts)
        {
            time = resetAlpha;
            forward = true;
            reverse = false;
            canvesGroup.alpha = resetAlpha;
            canvesGroup.blocksRaycasts = true;
            ObjectReferenceContainer.Instance.CF2CanvesPanel.SetActive(false);
            ObjectReferenceContainer.Instance.controlPanel.SetActive(false);
            UIReferenceContainer.Instance.backButton.SetActive(false);
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
        //SceneChanger.Instance.ChangeScene("URP-Scene (Conclusion)");
        //UIReferenceContainer.Instance.fadeScreenEffect.SetActive(true);
        //ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeIn");
        UIReferenceContainer.Instance.narationPanelConclusion.SetActive(true);
    }
}
