using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMe : MonoBehaviour
{
    public float delayTimer;
    // Start is called before the first frame update
    private void OnEnable()
    {
        
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(delayTimer);

    }
    public void OnAnimationComplete()
    {
        ObjectReferenceContainer.Instance.playerCamera.SetActive(true);
        ObjectReferenceContainer.Instance.movementController.SetActive(true);
        ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
        //UIReferenceContainer.Instance.backButton.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
