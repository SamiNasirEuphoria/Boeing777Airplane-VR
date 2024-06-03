using UnityEngine;
using UnityEngine.UI;

public class UIReferenceContainer : MonoBehaviour
{
    #region SingletonPattern
    private static UIReferenceContainer instance;
    public static UIReferenceContainer Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

    }
    #endregion

    public Image floorIndicator, chairIndicator,chairIndicatorMaterial,dropMaskIndicator,
            passengerServiceUnitIndicator, exitAreaIndicator,quizIcon;
    public GameObject confirmationPanel,confirmationPanelLast, narrationPanel,narrationPanelOxygenMask,
        confirmationPanelOxygenMask,popupMessage,backButton, customerServiceAreaMessageBox,
        fadeScreenEffect,joystick,crosshair,narationPanelConclusion, exitAreaMessage, CF2Panel;
}
