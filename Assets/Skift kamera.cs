using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skift : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    void Start()
    {
        // Check if cameras are assigned
        if (cam1 == null || cam2 == null)
        {
            Debug.LogError("Cameras not assigned in the inspector!");
            return;
        }

        // Initially enable the first camera and disable the second camera
    }

    // This method is called when another collider enters the trigger collider attached to this GameObject
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Toggle cameras
        ToggleCameras();
    }

    void ToggleCameras()
    {
        // Toggle the active state of cameras
        cam1.enabled = !cam1.enabled;
        cam2.enabled = !cam2.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        // You can add update logic here if needed
    }
}
