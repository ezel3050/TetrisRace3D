using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : Character
{
    public static Player instance;
    public Transform mesh;
    public float moveSpeed;
    public float rotationOffset;

    CharacterController characterController;

    public override void Awake()
    {
        //Not calling base.Awake on purpes to seperate Player with character for later reusabilty
        instance = this;
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        CharacterMovement();
        Animation();
    }

    private void CharacterMovement()
    {
        if (InputManager.DoesJoystickHaveAnyInput())
        {
            characterController.Move(new Vector3(InputManager.horizontal, characterController.isGrounded ? 0 : -2, InputManager.vertical) * Time.deltaTime * moveSpeed);
            mesh.eulerAngles = new Vector3(0, (Mathf.Atan2(InputManager.vertical, InputManager.horizontal) * -180 / Mathf.PI) + rotationOffset, 0);
        }
        else
        {
            characterController.Move(Vector3.zero);
        }

    }

    void Animation()
    {
        animator.SetFloat("Speed", characterController.velocity.magnitude);

    }
}