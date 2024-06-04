using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationPanelLast : MonoBehaviour
{
    private CanvasGroup canvesGroup;
    private float time, resetAlpha = 0f, setAlpha = 1f;
    public float delayTime;
    private bool forward, reverse;
    // Start is called before the first frame update
    void Start()
    {
        canvesGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {

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
        //ObjectReferenceContainer.Instance.controlPanel.SetActive(false);
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
    //the only difference bw yes and no is just control panel 
    public void DisablePanelNo()
    {
        if (canvesGroup.blocksRaycasts)
        {
            reverse = true;
            time = setAlpha;
            canvesGroup.alpha = setAlpha;
            canvesGroup.blocksRaycasts = false;
        }
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeEffect");
        StartCoroutine(DisableMe());
    }
    IEnumerator DisableMe()
    {
        yield return new WaitForSeconds(2.0f);
        ObjectReferenceContainer.Instance.airplaneObject.SetActive(true);
        ObjectReferenceContainer.Instance.outerSphere.SetActive(false);
        ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
        ObjectReferenceContainer.Instance.movementController.SetActive(true);
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeOut");
    }
    public void DisbalePanelYes()
    {
        if (canvesGroup.blocksRaycasts)
        {
            reverse = true;
            time = setAlpha;
            canvesGroup.alpha = setAlpha;
            canvesGroup.blocksRaycasts = false;
        }
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeEffect");
        StartCoroutine(_DisableMe());
    }
    IEnumerator _DisableMe()
    {
        yield return new WaitForSeconds(2.0f);
        ObjectReferenceContainer.Instance.airplaneObject.SetActive(true);
        ObjectReferenceContainer.Instance.outerSphere.SetActive(false);
        ObjectReferenceContainer.Instance.movementController.SetActive(true);
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeOut");
    }
}
