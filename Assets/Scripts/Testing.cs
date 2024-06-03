using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public void ButtonClick()
    {
        SceneChanger.Instance.ChangeScene("DummyPlaneScene");
    }
}
