using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public GameObject mainPanel, exitPanel, aboutPanel;
    public bool aboutBool, exitBool,mainBool;
    public float rotationSpeed;
    private void Start()
    {
        transform.LookAt(mainPanel.transform);
    }
    private void FixedUpdate()
    {
        if (aboutBool)
        {
            // Get the direction to the target
            Vector3 directionToTarget = aboutPanel.transform.position - transform.position;

            // Calculate the rotation step based on the speed and deltaTime
            float rotationStep = rotationSpeed * Time.deltaTime;

            // Use Quaternion.Slerp for smooth interpolation
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationStep);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                // Stop further rotation
                aboutBool = false;
            }
        }
        else if(exitBool)
        {
            // Get the direction to the target
            Vector3 directionToTarget = exitPanel.transform.position - transform.position;

            // Calculate the rotation step based on the speed and deltaTime
            float rotationStep = rotationSpeed * Time.deltaTime;

            // Use Quaternion.Slerp for smooth interpolation
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationStep);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                // Stop further rotation
                exitBool = false;
            }
        }
        else if (mainBool)
        {
            // Get the direction to the target
            Vector3 directionToTarget = mainPanel.transform.position - transform.position;

            // Calculate the rotation step based on the speed and deltaTime
            float rotationStep = rotationSpeed * Time.deltaTime;

            // Use Quaternion.Slerp for smooth interpolation
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationStep);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                // Stop further rotation
                mainBool = false;
            }
        }
    }
}
