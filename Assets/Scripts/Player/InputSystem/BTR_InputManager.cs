using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BTR_InputManager : MonoBehaviour
{
    public bool wantsToPunch;
    public bool wantsToSpin;
    public bool wantsToShoot;
    public bool wantsToBerserk;
    public Vector2 movementVector;

    private PlayerInputs playerInputs;
    void Awake()
    {
        playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }

    private void Start()
    {
        playerInputs.Attacks.Punch.started += ctx => StartPunch(ctx);
        playerInputs.Attacks.Punch.canceled += ctx => EndPunch(ctx);

        playerInputs.Attacks.Spin.started += ctx => StartSpin(ctx);

        playerInputs.Attacks.Shoot.started += ctx => StartShoot(ctx);

        playerInputs.Attacks.Berserk.started += ctx => StartBerserk(ctx);

        playerInputs.Movement.Movement.performed += ctx => MovementInput(ctx);
        playerInputs.Movement.Movement.canceled += ctx => MovementInputZero(ctx);
    }

    void StartPunch(InputAction.CallbackContext context)
    {
        wantsToPunch = true;
    }

    void EndPunch(InputAction.CallbackContext context)
    {
        wantsToPunch = false;
    }

    void StartSpin(InputAction.CallbackContext context)
    {
        wantsToSpin = true;
    }

    void StartShoot(InputAction.CallbackContext context)
    {
        wantsToShoot = true;
    }

    void MovementInput(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>();
    }

    void MovementInputZero(InputAction.CallbackContext context)
    {
        movementVector = new Vector2();
    }

    void StartBerserk(InputAction.CallbackContext context)
    {
        wantsToBerserk = true;
    }
}
