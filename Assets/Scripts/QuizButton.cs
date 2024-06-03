using UnityEngine;

public class QuizButton : MonoBehaviour
{
   public void EnablePanel()
   {
        ObjectReferenceContainer.Instance.controlPanel.SetActive(true);
   }
   public void DisbalePanel()
   {
        ObjectReferenceContainer.Instance.controlPanel.SetActive(false);
   }
}
