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
        }
        //ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeEffect");
        //ObjectReferenceContainer.Instance.movementController.SetActive(false);
        //UIReferenceContainer.Instance.backButton.SetActive(false);
        //StartCoroutine(EnableMe());
    }
    IEnumerator EnableMe()
    {
        yield return new WaitForSeconds(2.0f);
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
        }
        //ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeEffect");
        StartCoroutine(DisableMe());
    }
    IEnumerator DisableMe()
    {
        yield return new WaitForSeconds(2.0f);
        UIReferenceContainer.Instance.confirmationPanelLast.GetComponent<ConfirmationPanelLast>().EnablePanel();
        //ObjectReferenceContainer.Instance.cameraController.enabled = true;
        //ObjectReferenceContainer.Instance.airplaneObject.SetActive(true);
        //ObjectReferenceContainer.Instance.outerSphere.SetActive(false);
        //ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
        //ObjectReferenceContainer.Instance.movementController.SetActive(true);
        //ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeOut");
    }
}
