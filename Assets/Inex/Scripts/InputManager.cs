using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static float horizontal, vertical;
    public static bool movementInputActive = true;

    public static Action interactAction;


    private void Awake()
    {
        interactAction = null;
        movementInputActive = true;
    }


    private void Update()
    {
        MovementInputs();
        if (Interact())
        {
            interactAction?.Invoke();
        }
        
    }

    void MovementInputs()
    {
        if (!movementInputActive)
        {
            horizontal = 0;
            vertical = 0;
            return;
        }

        horizontal = DynamicJoystick.instance.Horizontal;
        if (DynamicJoystick.instance.Horizontal == 0)
        {
            horizontal = Input.GetAxis("Horizontal");
        }

        vertical = DynamicJoystick.instance.Vertical;
        if (DynamicJoystick.instance.Vertical == 0)
        {
            vertical = Input.GetAxis("Vertical");
        }
    }

    public static bool DoesJoystickHaveAnyInput()
    {
        return horizontal != 0 || vertical != 0;
    }

    public static bool isMouseDown()
    {
        return Input.GetMouseButton(0);
    }


    public static bool Interact()
    {
        return Input.anyKey || Input.GetMouseButtonDown(0);
    }

}