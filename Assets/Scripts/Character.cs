using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int characterId;
    public Transform handPoint;

    [HideInInspector] public PuzzleBlock puzzleInHand;

    internal Animator animator;

    public virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();

    }

    public virtual void PickUpPuzzleBlock(PuzzleBlock puzzleBlock)
    {
        puzzleInHand = puzzleBlock;
        puzzleInHand.state = PuzzleBlockState.InCharacterHand;
        puzzleInHand.transform.parent = handPoint;
        puzzleInHand.transform.position = handPoint.position;
        puzzleInHand.transform.localScale = Vector3.one * 0.4f;
        HandUpAnimation(true);
    }

    public void HandUpAnimation(bool handUp)
    {
        animator.SetBool("HandsUp", handUp);
    }


}
