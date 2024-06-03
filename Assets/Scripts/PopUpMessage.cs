using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PopUpMessage : MonoBehaviour
{
    public TMP_Text textMessage;
    public string textToShow;
    public float delayTimer;

    // Start is called before the first frame update
    public void OnEnable()
    {
        textMessage.text = textToShow;
        StartCoroutine(DisableMe());
    }
    IEnumerator DisableMe()
    {
        yield return new WaitForSeconds(delayTimer);
        this.gameObject.SetActive(false);
    }
}
