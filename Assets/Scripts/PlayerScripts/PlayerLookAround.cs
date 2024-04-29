using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    [SerializeField] private float xSensitivity = 30f;
    [SerializeField] private float ySensitivity = 30f;

    [SerializeField] private Camera playerCamera;

    public Camera PlayerCamera { get => playerCamera; }

    private float xRotation = 0f;
    private const float MAX_VALUE_X_ROTATION = 80f;
        
    public void ProcessLook(Vector2 input)
    {
        xRotation -= input.y * Time.deltaTime * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -MAX_VALUE_X_ROTATION, MAX_VALUE_X_ROTATION);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(input.x * Time.deltaTime * xSensitivity * Vector3.up);
    }
}
