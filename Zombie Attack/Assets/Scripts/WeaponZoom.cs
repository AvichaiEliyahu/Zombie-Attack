using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController firstPersonController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedOutSensitivity = 4f;

    [SerializeField] float zoomedInFOV = 30f;
    [SerializeField] float zoomedInSensitivity = 2f;

    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
            ZoomIn();
        else ZoomOut();

    }

    void ZoomIn()
    {
        fpsCamera.fieldOfView = zoomedInFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedInSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomedInSensitivity;
    }

    void ZoomOut()
    {
        fpsCamera.fieldOfView = zoomedOutFOV;
        firstPersonController.mouseLook.XSensitivity = zoomedOutSensitivity;
        firstPersonController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }
}
