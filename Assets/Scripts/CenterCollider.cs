using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterCollider : MonoBehaviour
{
    public GameObject particleEffect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            particleEffect.SetActive(false);
        }
    }
}
