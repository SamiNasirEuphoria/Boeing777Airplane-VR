
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagManager.customerServiceArea))
        {
            GameController._check = false;
            UIReferenceContainer.Instance.passengerServiceUnitIndicator.gameObject.SetActive(true);
            UIReferenceContainer.Instance.popupMessage.GetComponent<PopUpMessage>().textToShow = "Passenger Service Unit Area";
            UIReferenceContainer.Instance.customerServiceAreaMessageBox.SetActive(true);
            ObjectReferenceContainer.Instance.controlPanel.SetActive(false);
            ObjectReferenceContainer.Instance.directionalLines.SetActive(false);
        }
        else if (other.gameObject.CompareTag(TagManager.centerCollier))
        {
            UIReferenceContainer.Instance.exitAreaMessage.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(TagManager.customerServiceArea))
        {
            //UIReferenceContainer.Instance.passengerServiceUnitIndicator.gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag(TagManager.centerCollier))
        {
            if (ObjectReferenceContainer.Instance.cameraController.exitAreaCollider)
            {
                UIReferenceContainer.Instance.exitAreaIndicator.gameObject.SetActive(true);
            }
            else
            {
                UIReferenceContainer.Instance.exitAreaIndicator.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(TagManager.customerServiceArea))
        {
            //alteration from enter to exit

            GameController.dropMaskCheck = true;
            UIReferenceContainer.Instance.passengerServiceUnitIndicator.gameObject.SetActive(false);
            //UIReferenceContainer.Instance.customerServiceAreaMessageBox.GetComponent<PassengerServiceMessageBox>().DisableMe();
            UIReferenceContainer.Instance.narrationPanelOxygenMask.GetComponent<NarationPanelOxygenMask>().SetItActive();
            ObjectReferenceContainer.Instance.passengerServiceAreaCollider.GetComponent<BoxCollider>().enabled = false;
            
        }
        else if (ObjectReferenceContainer.Instance.cameraController.exitAreaCollider)
        {

            UIReferenceContainer.Instance.exitAreaIndicator.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag(TagManager.centerCollier))
        {
            UIReferenceContainer.Instance.exitAreaMessage.SetActive(false);
        }
        else
        {
            UIReferenceContainer.Instance.exitAreaIndicator.gameObject.SetActive(false);
        }
    }
}
