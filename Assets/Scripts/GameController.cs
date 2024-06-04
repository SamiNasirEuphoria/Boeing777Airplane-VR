using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    #region Singleton
    private static GameController instance;
    public static GameController Instance
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
        }else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
           maskCount = 0;
           count = 0;
           exitCount = 0;
        oxygenMask = ObjectReferenceContainer.Instance.oxygenMask;
        if (PlayerPrefsHandler.CutSceneFlag == 0)
        {
            if (ObjectReferenceContainer.Instance.cutSceneGameObject)
            {
                ObjectReferenceContainer.Instance.cutSceneGameObject.SetActive(true);
                PlayerPrefsHandler.CutSceneFlag = 1;
            }
        }
        else
        {
            if (ObjectReferenceContainer.Instance.cutSceneGameObject)
            {
                ObjectReferenceContainer.Instance.cutSceneGameObject.SetActive(false);
                ObjectReferenceContainer.Instance.movementController.SetActive(true);
               // ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
                UIReferenceContainer.Instance.narrationPanel.SetActive(true);
                UIReferenceContainer.Instance.narrationPanel.GetComponent<NarationPanelStartScene>().enabled = true;
            }
        }
    }
    #endregion
    //this check is used when scene switching happens
    [HideInInspector]
    public static bool check, _check, dropMaskCheck, startGame;
   
    private int count, maskCount, exitCount;
    private GameObject oxygenMask;
    public void ChangeFloor()
    {
        count++;
       if (ObjectReferenceContainer.Instance.cameraController.floor.tag == TagManager.floor)
       {
          ObjectReferenceContainer.Instance.cameraController.floor.GetComponent<MeshRenderer>().material =
          ObjectReferenceContainer.Instance.textileFloor;
          ObjectReferenceContainer.Instance.cameraController.floor.tag = TagManager.markedFloor ;
       }
       else if(ObjectReferenceContainer.Instance.cameraController.floor.tag == TagManager.markedFloor)
       {
          ObjectReferenceContainer.Instance.cameraController.floor.GetComponent<MeshRenderer>().material =
          ObjectReferenceContainer.Instance.nonTextileFloor;
          ObjectReferenceContainer.Instance.cameraController.floor.tag = TagManager.floor;
       }
       if (count == 3)
       {
            UIReferenceContainer.Instance.quizIcon.gameObject.SetActive(true);
            UIReferenceContainer.Instance.floorIndicator.gameObject.SetActive(false);
        }
       if(count%5 == 0)
        {
            UIReferenceContainer.Instance.confirmationPanel.GetComponent<ConfirmationPanel>().EnablePanel();
        }
    }
    public void DropMask()
    {
        if (dropMaskCheck)
        {
            maskCount++;
            var obj = ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().bounds.center;
            //var objectToInstantiate = ObjectReferenceContainer.Instance.oxygenMask;
            //Vector3 instantiatePosition = Camera.main.transform.position + Camera.main.transform.forward.normalized * 2f;
            //Quaternion instantiateRotation = Camera.main.transform.rotation;
            //GameObject newObject = Instantiate(objectToInstantiate, obj+new Vector3(0,2.5f,0), instantiateRotation);
            GameObject newObject = Instantiate(oxygenMask, obj + new Vector3(0, 2.5f, 0), Quaternion.identity);

        }
        if (maskCount % 3 == 0)
        {
            UIReferenceContainer.Instance.confirmationPanelOxygenMask.GetComponent<ConfirmationPanel>().EnablePanel();
        }
    }
    public void ExitAreaMethod()
    {
       //exitCount++;
       //ObjectReferenceContainer.Instance.secondCamera.SetActive(true);
       UIReferenceContainer.Instance.popupMessage.GetComponent<PopUpMessage>().textToShow = "Exit Area";
       UIReferenceContainer.Instance.popupMessage.SetActive(true);
       //ObjectReferenceContainer.Instance.playerCamera.SetActive(false);
       //UIReferenceContainer.Instance.backButton.SetActive(false);
       ObjectReferenceContainer.Instance.movementController.SetActive(false);
       ObjectReferenceContainer.Instance.controlPanel.SetActive(false);
        StartCoroutine(CheckList());
    }
    IEnumerator CheckList()
    {
        
        yield return new WaitForSeconds(4.5f);
        var num = ObjectReferenceContainer.Instance.centerColliders.Length;
        for (int i = 0; i < num; i++)
        {
            ObjectReferenceContainer.Instance.centerColliders[i].SetActive(false);
        }
        ObjectReferenceContainer.Instance.checkList.GetComponent<CheckList>().EnablePanel();
        //remove door particles and colliders
    }
    IEnumerator Message()
    {
        yield return new WaitForSeconds(5.5f);
        UIReferenceContainer.Instance.popupMessage.GetComponent<PopUpMessage>().textToShow = "Try other Exit Door";
        UIReferenceContainer.Instance.popupMessage.SetActive(true);
    }
    public void CustomerAreaMessage()
    {
        UIReferenceContainer.Instance.passengerServiceUnitIndicator.gameObject.SetActive(false);
        ObjectReferenceContainer.Instance.directionalLines.SetActive(false);
        //UIReferenceContainer.Instance.popupMessage.SetActive(true);
        //dropMaskCheck = true;
        //UIReferenceContainer.Instance.narrationPanelOxygenMask.GetComponent<NarationPanelOxygenMask>().SetItActive();
    }
    public void ChairAddAndRemove()
    {
        if (_check)
        {
            count++;
            if (ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().enabled)
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().enabled = false;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshCollider>().convex = true;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshCollider>().isTrigger = true;
            }
            else
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().enabled = true;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshCollider>().convex = true;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshCollider>().isTrigger = false;
            }
            if (count == 3)
            {
                UIReferenceContainer.Instance.quizIcon.gameObject.SetActive(true);
                UIReferenceContainer.Instance.chairIndicator.gameObject.SetActive(false);
            }
            if (count % 5 == 0)
            {
                UIReferenceContainer.Instance.confirmationPanel.GetComponent<ConfirmationPanel>().EnablePanel();
            }
        }
    }
    public void ChairMaterial()
    {
        if (check)
        {
            count++;
            if (ObjectReferenceContainer.Instance.cameraController.selectedChair.tag == TagManager.economyChair)
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().material =
                ObjectReferenceContainer.Instance.defaultEconomyChair;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.tag = TagManager.markedEconomyChair;
            }
            else if (ObjectReferenceContainer.Instance.cameraController.selectedChair.tag == TagManager.markedEconomyChair)
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().material =
                ObjectReferenceContainer.Instance.economyChair;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.tag = TagManager.economyChair;
            }
            else if (ObjectReferenceContainer.Instance.cameraController.selectedChair.tag == TagManager.executiveChair)
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().material =
                ObjectReferenceContainer.Instance.defaultExecutiveChair;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.tag = TagManager.markedExecutiveChair;
            }
            else if (ObjectReferenceContainer.Instance.cameraController.selectedChair.tag == TagManager.markedExecutiveChair)
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().material =
                ObjectReferenceContainer.Instance.executiveChair;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.tag = TagManager.executiveChair;
            }
            else if (ObjectReferenceContainer.Instance.cameraController.selectedChair.tag == TagManager.businessChair)
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().material =
                ObjectReferenceContainer.Instance.defaultBusinessChair;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.tag = TagManager.markedBusinessChair;
            }
            else if (ObjectReferenceContainer.Instance.cameraController.selectedChair.tag == TagManager.markedBusinessChair)
            {
                ObjectReferenceContainer.Instance.cameraController.selectedChair.GetComponent<MeshRenderer>().material =
                ObjectReferenceContainer.Instance.businessChair;
                ObjectReferenceContainer.Instance.cameraController.selectedChair.tag = TagManager.businessChair;
            }
            if (count % 4 == 0)
            {
                UIReferenceContainer.Instance.confirmationPanel.GetComponent<ConfirmationPanel>().EnablePanel();
            }
        }
    }
    public void SetColor()
    {
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeIn");
        StartCoroutine(Wait());
        check = !check;
        _check = false;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        SceneChanger.Instance.ChangeScene("URP-Scene-Color-VR");
    }
    public void SetSeat()
    {
        ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("FadeIn");
        StartCoroutine(_Wait());
        _check = !_check;
        check = false;
    }
    IEnumerator _Wait()
    {
        yield return new WaitForSeconds(2.0f);
        SceneChanger.Instance.ChangeScene("URP-Scene-Seat-VR");
    }
    public void DropMaskCheck()
    {
        _check = false;
        ObjectReferenceContainer.Instance.directionalLines.SetActive(true);
        UIReferenceContainer.Instance.popupMessage.GetComponent<PopUpMessage>().textToShow = "Follow the arrows";
        UIReferenceContainer.Instance.popupMessage.SetActive(true);
    }
    public void DropMaskUnCheck()
    {
        dropMaskCheck = false;
        StartCoroutine(DoorTask());
    }
    IEnumerator DoorTask()
    {
        yield return new WaitForSeconds(3.5f);
        UIReferenceContainer.Instance.popupMessage.GetComponent<PopUpMessage>().textToShow = "Look Around Near Exit Doors";
        UIReferenceContainer.Instance.popupMessage.SetActive(true);
        var num = ObjectReferenceContainer.Instance.centerColliders.Length;
        for(int i=0;i < num; i++)
        {
            ObjectReferenceContainer.Instance.centerColliders[i].SetActive(true);
        }
        ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
    }
    public void SceneChange()
    {
        check = false;
        _check = false;
        SceneChanger.Instance.ChangeScene("URP-Scene-VR");
    }
    private void OnApplicationQuit()
    {
        PlayerPrefsHandler.CutSceneFlag = 0;
    }
    public void QuitApplication()
    {
        Application.Quit();
    }
}
