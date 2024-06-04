using UnityEngine;

public class ObjectReferenceContainer : MonoBehaviour
{
    #region Singleton
    private static ObjectReferenceContainer instance;
    public static ObjectReferenceContainer Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    public Animator fadeEffect;
    public GameObject outerSphere,airplaneObject,cutSceneGameObject, cutSceneView, oxygenMask,playerCamera,secondCamera,
        movementController,controlPanel, directionalLines, checkList, passengerServiceAreaCollider;
    public Material textileFloor, nonTextileFloor, greenColor, whiteColor, defaultBusinessChair, businessChair, defaultExecutiveChair, executiveChair, defaultEconomyChair, economyChair;
    public CameraController cameraController;
    public GameObject[] centerColliders;
   
}
