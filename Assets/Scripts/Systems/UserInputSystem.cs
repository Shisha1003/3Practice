
using UnityEngine;
using Unity.Entities;
using UnityEngine.InputSystem;
using Unity.Mathematics;
using static UserInputData;
using System;

public class UserInputSystem : ComponentSystem
{
    private EntityQuery inputQuery;

    private InputAction _moveAction;
    private InputAction _shootAction;
    private InputAction _burstAction;


    private float2 _moveInput;
    private bool _burstInput;
    private bool _shootInput;
   
    protected override void OnCreate()
    {
        inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());

        PlayerControls playerCont = new PlayerControls();
        playerCont.UI.Enable();
        playerCont.UI.Moving.performed += PlayerMoving;
        playerCont.UI.Moving.canceled += _ => _moveInput = Vector2.zero;

        playerCont.UI.Burst.performed += Burst_started;
        playerCont.UI.Burst.canceled += _ => _burstInput = false;


        playerCont.UI.Shoot.performed += Shoot_started;
        playerCont.UI.Shoot.canceled += _ => _shootInput = false;
    }

    private void Shoot_started(InputAction.CallbackContext context)
    {
        _shootInput = context.ReadValueAsButton();
    }
    
    private void Burst_started(InputAction.CallbackContext obj)
    {
        _burstInput = obj.ReadValueAsButton();
    }

    private void PlayerMoving(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
        _shootAction.Disable();
        _burstAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(inputQuery).ForEach(
            (Entity entity, ref InputData inputData) =>
            {
                inputData.Move = _moveInput;
                inputData.Shoot = _shootInput ? 1f : 0f;
                inputData.Burst = _burstInput ? new float2(1, 0) : float2.zero;
            });
    }
}
