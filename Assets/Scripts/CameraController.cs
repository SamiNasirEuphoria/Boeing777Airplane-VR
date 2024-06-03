using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    RaycastHit hit;
    [HideInInspector]
    public GameObject selectedChair;
    [HideInInspector]
    public GameObject floor;
    [HideInInspector]
    public bool exitAreaCollider;
    void FixedUpdate()
    {
        RayFromcamera();
    }
    public void RayFromcamera()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //4.5f
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            if (Physics.Raycast(ray, out hit, 5.0f))
            {
            if (hit.collider.gameObject.CompareTag(TagManager.floor) || hit.collider.gameObject.CompareTag(TagManager.markedFloor))
            {
                floor = hit.transform.gameObject;
                UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(true);
                UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(false);
                UIReferenceContainer.Instance.chairIndicatorMaterial.gameObject.SetActive(false);
            }
            else if(hit.collider.gameObject.CompareTag(TagManager.exitArea))
            {
                //UIReferenceContainer.Instance.exitAreaIndicator.gameObject.SetActive(true);
                exitAreaCollider = true;
            }
            else if (hit.collider.gameObject.CompareTag(TagManager.businessChair) ||
                     hit.collider.gameObject.CompareTag(TagManager.markedBusinessChair) ||
                     hit.collider.gameObject.CompareTag(TagManager.executiveChair) ||
                     hit.collider.gameObject.CompareTag(TagManager.markedExecutiveChair) ||
                     hit.collider.gameObject.CompareTag(TagManager.economyChair) ||
                     hit.collider.gameObject.CompareTag(TagManager.markedEconomyChair)
                )
            {
                selectedChair = hit.transform.gameObject;
                //Debug.Log("chair's pos in collider geometry near point"+ hit.collider.bounds.ClosestPoint(hit.point));
                //testing(hit);
                UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(false);
                UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(false);
                UIReferenceContainer.Instance.chairIndicatorMaterial.gameObject.SetActive(false);
                //UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(false);
                if (GameController.check)
                {
                    UIReferenceContainer.Instance.chairIndicatorMaterial.gameObject.SetActive(false);
                    UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(false);
                    //UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(false);
                    UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(true);
                }
                else if (GameController._check)
                {
                    UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(false);
                    UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(false);
                    //UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(false);
                    UIReferenceContainer.Instance.chairIndicatorMaterial.gameObject.SetActive(true);
                }
                else if (GameController.dropMaskCheck)
                {
                    UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(false);
                    UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(false);
                    UIReferenceContainer.Instance.chairIndicatorMaterial.gameObject.SetActive(false);
                    UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(true);
                }
                //else if (!GameController.dropMaskCheck)
                //{
                //    if (UIReferenceContainer.Instance.dropMaskIndicator)
                //    {
                //        if (UIReferenceContainer.Instance.dropMaskIndicator.gameObject.activeInHierarchy)
                //        {
                //            UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(false);
                //        }
                //    }
                //}
            }
            else
            {
                UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(false);
                UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(false);
                UIReferenceContainer.Instance.chairIndicatorMaterial.gameObject.SetActive(false);

                if (UIReferenceContainer.Instance.dropMaskIndicator)
                {
                    if (UIReferenceContainer.Instance.dropMaskIndicator.gameObject.activeInHierarchy)
                    {
                        UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(false);
                    }
                }
                //UIReferenceContainer.Instance.exitAreaIndicator.gameObject.SetActive(false);
                exitAreaCollider = false;
            }
        }
        else
        {
            UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(false);
            UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(false);
            UIReferenceContainer.Instance.chairIndicatorMaterial.gameObject.SetActive(false);
            if (UIReferenceContainer.Instance.dropMaskIndicator)
            {
                UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(false);
            }
            //if (UIReferenceContainer.Instance.dropMaskIndicator)
            //{
            //    if (UIReferenceContainer.Instance.dropMaskIndicator.gameObject.activeInHierarchy)
            //    {
            //        UIReferenceContainer.Instance.dropMaskIndicator.gameObject.SetActive(false);
            //    }
            //}
            //UIReferenceContainer.Instance.exitAreaIndicator.gameObject.SetActive(false);
            exitAreaCollider = false;
        }
    }
    //bool IsFrontSide(Vector3 faceNormal, Vector3 hitPoint)
    //{
    //    // Calculate the direction from the hit point to the camera
    //    Vector3 toCamera = Camera.main.transform.position - hitPoint;

    //    // Normalize the vectors
    //    faceNormal.Normalize();
    //    toCamera.Normalize();

    //    // Calculate the dot product of the face normal and the direction to the camera
    //    float dotProduct = Vector3.Dot(faceNormal, toCamera);

    //    // If the dot product is positive, the face normal is roughly facing the camera
    //    //return dotProduct < 90;
    //    return dotProduct >= 90 ? true : false;
    //}
    //void testing(RaycastHit hit)
    //{
    //    Vector3 hitPoint = hit.point;
    //    Collider hitCollider = hit.collider;
    //    // Compare the hit point with the object's transform to determine direction
    //    Vector3 localHitPoint = hitCollider.transform.InverseTransformPoint(hitPoint);
    //    Vector3 _localHitPoint = hitCollider.transform.TransformPoint(hitPoint);
    //    Debug.Log("the values of geometry"+hit.collider.bounds.size);
    //}
}
