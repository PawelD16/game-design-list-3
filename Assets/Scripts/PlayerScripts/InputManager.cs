using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions OnFoot { get; private set; }

    private PlayerMotor playerMotor;
    private PlayerLookAround playerLookAround;
    private PlayerShoot playerShoot;

    private void Awake()
    {
        playerInput = new();
        playerMotor = GetComponent<PlayerMotor>();
        playerLookAround = GetComponent<PlayerLookAround>();
        playerShoot = GetComponent<PlayerShoot>();

        OnFoot = playerInput.OnFoot;

        OnFoot.Jump.performed += ctx => playerMotor.Jump();
        OnFoot.Shoot.performed += ctx => { if (PlayerManager.HasGun) playerShoot.Shoot(); };
    }

    private void OnEnable() => OnFoot.Enable();

    private void OnDisable() => OnFoot.Disable();

    private void FixedUpdate() => playerMotor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());

    private void LateUpdate() => playerLookAround.ProcessLook(OnFoot.LookAround.ReadValue<Vector2>());

}
