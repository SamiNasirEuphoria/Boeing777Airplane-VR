using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject joystick,drag,crosshair;

    private CanvasGroup joystickPanel;
    private Button joystickPanelButton;
    
    private CanvasGroup dragPanelCanvasGroup;
    private Button dragPanelButton;
   
    private CanvasGroup crosshairCanvasGroup;
    private Button crosshairButton;

    private CanvasGroup currentPanelCanvasGroup;
    private Button currentPanelButton;
    //this method called before awake 
    private void Start()
    {
        //joystickPanel = joystick.GetComponent<CanvasGroup>();
        //joystickPanelButton = joystick.GetComponent<Button>();

        //dragPanelCanvasGroup = drag.GetComponent<CanvasGroup>();
        //dragPanelButton = drag.GetComponent<Button>();

        //crosshairCanvasGroup = crosshair.GetComponent<CanvasGroup>();
        //crosshairButton = crosshair.GetComponent<Button>();
        //InitializePanel(joystickPanel, joystickPanelButton);
        //InitializePanel(dragPanelCanvasGroup, dragPanelButton);
        //InitializePanel(crosshairCanvasGroup, crosshairButton);
        //ShowPanel(joystickPanel, joystickPanelButton);
        EndTutorial();
    }
    private void Awake()
    {
        joystickPanel = joystick.GetComponent<CanvasGroup>();
        joystickPanelButton = joystick.GetComponent<Button>();

        dragPanelCanvasGroup = drag.GetComponent<CanvasGroup>();
        dragPanelButton = drag.GetComponent<Button>();

        crosshairCanvasGroup = crosshair.GetComponent<CanvasGroup>();
        crosshairButton = crosshair.GetComponent<Button>();
        crosshairButton.onClick.AddListener(()=> EndTutorial());
        InitializePanel(joystickPanel, joystickPanelButton);
        InitializePanel(dragPanelCanvasGroup, dragPanelButton);
        InitializePanel(crosshairCanvasGroup, crosshairButton);
        ShowPanel(joystickPanel, joystickPanelButton);
    }
    private void OnEnable()
    {
       
    }
    void InitializePanel(CanvasGroup canvasGroup, Button button)
    {
        // Set the initial state
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;

        // Add a click listener to the button
        button.onClick.AddListener(() => OnButtonClick(canvasGroup));
    }

    void ShowPanel(CanvasGroup canvasGroup, Button button)
    {
        // Set the current panel
        currentPanelCanvasGroup = canvasGroup;
        currentPanelButton = button;

        // Fade in the current panel
        StartCoroutine(FadePanel(currentPanelCanvasGroup, 1f));
    }

    void OnButtonClick(CanvasGroup canvasGroup)
    {
        // Fade out the current panel and show the next one
        canvasGroup.blocksRaycasts = false;
        StartCoroutine(FadePanel(currentPanelCanvasGroup, 0f, () => ShowNextPanel()));
    }

    void ShowNextPanel()
    {
        // Determine the next panel based on the current panel
        if (currentPanelCanvasGroup == joystickPanel)
        {
            ShowPanel(dragPanelCanvasGroup, dragPanelButton);
        }
        else if (currentPanelCanvasGroup == dragPanelCanvasGroup)
        {
            ShowPanel(crosshairCanvasGroup, crosshairButton);
        }
        // Add more conditions if needed for additional panels
    }
    IEnumerator FadePanel(CanvasGroup canvasGroup, float targetAlpha, System.Action onComplete = null)
    {
       // float duration = 0.5f; // Time for the fade effect
        float duration = 0.35f; // Time for the fade effect
        // Fade to the target alpha
        while (Mathf.Abs(canvasGroup.alpha - targetAlpha) > 0.01f)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, targetAlpha, Time.deltaTime / duration);
            yield return null;
        }

        // Ensure the alpha is set to the exact target value
        canvasGroup.alpha = targetAlpha;

        // Enable or disable raycasts based on the alpha
        canvasGroup.blocksRaycasts = targetAlpha > 0.01f;

        // Call the onComplete action if provided
        onComplete?.Invoke();
    }
    public void EndTutorial()
    {
        GameController.startGame = true;
        ObjectReferenceContainer.Instance.movementController.SetActive(true);
        //ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
        UIReferenceContainer.Instance.narrationPanel.SetActive(true);
        UIReferenceContainer.Instance.narrationPanel.GetComponent<NarationPanelStartScene>().enabled = true;
        StartCoroutine(MessageCaller());
    }
    public void SetInActive()
    {
        this.gameObject.SetActive(false);
    }
    IEnumerator MessageCaller()
    {
        yield return new WaitForSeconds(1.2f);
        UIReferenceContainer.Instance.popupMessage.GetComponent<PopUpMessage>().textToShow = "Start exploring now";
        UIReferenceContainer.Instance.popupMessage.SetActive(true);
    }
}
