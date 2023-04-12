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
    public bool considerGravity;
    public PurchaseApplierGameObject skinPuchaseApplier;

    [HideInInspector] public int currentStage;

    CharacterController characterController;

    public override void Awake()
    {
        //Not calling base.Awake on purpes to seperate Player with character for later reusabilty
        instance = this;
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        this.CallWithDelay(() =>
        {
            //waiting for purchase applier to activate the right skin
            SetAnimator();
        }, 1);
    }

    public void SetAnimator()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        CharacterMovement();
        Animation();
    }

    private void CharacterMovement()
    {
        if (!GameManager.instnace.isGameStarted) return;
        characterController.Move(new Vector3(InputManager.horizontal, !characterController.isGrounded && considerGravity ? -2 : 0, InputManager.vertical) * Time.deltaTime * moveSpeed);
        if (InputManager.DoesJoystickHaveAnyInput())
        {

            mesh.eulerAngles = new Vector3(0, (Mathf.Atan2(InputManager.vertical, InputManager.horizontal) * -180 / Mathf.PI) + rotationOffset, 0);
        }
        else
        {
            characterController.Move(Vector3.zero);
        }

    }

    void Animation()
    {
        if (!animator) return;
        animator.SetFloat("Speed", characterController.velocity.magnitude);
    }

    public void MovePlayerToPosition(Vector3 pos)
    {
        characterController.enabled = false;
        transform.position = pos;
        animator.SetFloat("Speed", 0);
        this.CallWithDelay(() =>
        {
            characterController.enabled = true;
        }, 0.2f);

    }

    public override void Initilize(int id)
    {
        foreach (SkinPartOfPlayer skinPartOfPlayer in GetComponentsInChildren<SkinPartOfPlayer>())
        {
            skinPartOfPlayer.skinnedMeshRenderer.material = GameManager.instnace.currentLevel.idMaterials[id];
        }

        skinPuchaseApplier.ApplyPurchase();

    }

    public override void PickUpPuzzleBlock(PuzzleBlock puzzleBlock)
    {
        base.PickUpPuzzleBlock(puzzleBlock);
        AudioManager.instnace.PlayClip(1);
    }



}