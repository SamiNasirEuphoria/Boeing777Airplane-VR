using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenMask : MonoBehaviour
{
    private Rigidbody myRigidbody;
    //private MeshCollider myCollider;
    private CapsuleCollider myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        //myCollider = GetComponent<MeshCollider>();
        myCollider = GetComponent<CapsuleCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(TagManager.businessChair) ||
            other.gameObject.CompareTag(TagManager.markedBusinessChair) ||
            other.gameObject.CompareTag(TagManager.executiveChair) ||
            other.gameObject.CompareTag(TagManager.markedExecutiveChair) ||
            other.gameObject.CompareTag(TagManager.economyChair) ||
            other.gameObject.CompareTag(TagManager.markedEconomyChair)
            )
        {
            //myCollider.isTrigger = false;
            //myRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(DestroyMe());
            UIReferenceContainer.Instance.popupMessage.GetComponent<PopUpMessage>().textToShow = "Oxygen Mask Dropped";
            UIReferenceContainer.Instance.popupMessage.SetActive(true);
        }
    }
    IEnumerator DestroyMe()
    {
        yield return new WaitForSeconds(7.5f);
        Destroy(this.gameObject);
    }
}
