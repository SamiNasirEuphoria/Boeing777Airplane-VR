using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRope : MonoBehaviour
{
    public GameObject prefabToInstantiate; // Reference to the prefab to instantiate
    public Transform spawnPoint; // Reference to the spawn point GameObject
    private void Awake()
    {
        Debug.Log("Ahmad");
    }
    void Start()
    {
        StartCoroutine(Wait());

    }
    IEnumerator Wait()
    {
        GameObject instantiatedObject = Instantiate(prefabToInstantiate, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(1.5f);
        instantiatedObject.SetActive(true);
    }
}
