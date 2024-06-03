using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationPanel : MonoBehaviour
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
            canvesGroup.interactable = true;
        }
        ObjectReferenceContainer.Instance.CF2CanvesPanel.SetActive(false);
        ObjectReferenceContainer.Instance.controlPanel.SetActive(false);
        //UIReferenceContainer.Instance.backButton.SetActive(false);
    }
    public void DisablePanelNo()
    {
        if (canvesGroup.blocksRaycasts)
        {
            reverse = true;
            time = setAlpha;
            canvesGroup.alpha = setAlpha;
            canvesGroup.blocksRaycasts = false;
            canvesGroup.interactable = false;
        }
        ObjectReferenceContainer.Instance.CF2CanvesPanel.SetActive(true);
        ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
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
        ObjectReferenceContainer.Instance.CF2CanvesPanel.SetActive(true);
    }
}
