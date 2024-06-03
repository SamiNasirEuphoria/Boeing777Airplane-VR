using UnityEngine;
using System.Collections; 
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonPopupAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private RectTransform buttonTransform;
    private bool check;
    public bool isPlayPause;
    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = true;
        buttonTransform = button.GetComponent<RectTransform>();
        button.onClick.AddListener(Clicked);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!check)
        { 
           buttonTransform.DOScale(Vector3.one * 1.25f, 0.75f);
        }
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
            if (!check)
            {
                buttonTransform.DOScale(Vector3.one, 0.75f);
            }
    }
    public void Clicked()
    {
       
        //SoundManager.Instance.ButtonClick();
        if (!isPlayPause)
        {
            buttonTransform.DOScale(Vector3.one * 1.50f, 0.75f);
            button.interactable = false;
            StartCoroutine(Wait());
            check = true;
        }
        else
        {
            buttonTransform.DOScale(Vector3.one * 1.50f, 0.75f);
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        buttonTransform.DOScale(Vector3.one, 0.75f);
    }
}
