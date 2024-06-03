using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConclusionPanel : MonoBehaviour
{
    private CanvasGroup canvesGroup;
    private float time, resetAlpha = 0f, setAlpha = 1f;
    public float delayTime, setActiveTimer, setInactiveTimer;
    private bool forward, reverse;
    // Start is called before the first frame update
    void Start()
    {
        canvesGroup = GetComponent<CanvasGroup>();

    }
    IEnumerator SetinActivePanel()
    {
        yield return new WaitForSeconds(setInactiveTimer);
        DisablePanel();
    }
    IEnumerator SetActivePanel()
    {
        yield return new WaitForSeconds(setActiveTimer);
        EnablePanel();
    }
    private void OnEnable()
    {
        StartCoroutine(SetActivePanel());
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
        if (!canvesGroup.blocksRaycasts)
        {
            time = resetAlpha;
            forward = true;
            reverse = false;
            canvesGroup.alpha = resetAlpha;
            canvesGroup.blocksRaycasts = true;
            //StartCoroutine(SetinActivePanel());
        }
        UIReferenceContainer.Instance.backButton.SetActive(false);
    }
    public void DisablePanel()
    {
        if (canvesGroup.blocksRaycasts)
        {
            reverse = true;
            time = setAlpha;
            canvesGroup.alpha = setAlpha;
            canvesGroup.blocksRaycasts = false;
            ObjectReferenceContainer.Instance.cameraController.enabled = true;
            
        }
        //UIReferenceContainer.Instance.backButton.SetActive(true);
        UIReferenceContainer.Instance.confirmationPanelLast.GetComponent<ConfirmationPanel>().EnablePanel();
    }
}