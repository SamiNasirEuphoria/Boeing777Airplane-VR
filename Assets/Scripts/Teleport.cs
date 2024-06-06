using UnityEngine;

public class Teleport : MonoBehaviour
{
    public LineRenderer myLine;
    private void OnDisable()
    {
        if (myLine.startColor !=  myLine.endColor)
        {
            ObjectReferenceContainer.Instance.fadeEffect.SetTrigger("Teleport");
        }
    }
}
