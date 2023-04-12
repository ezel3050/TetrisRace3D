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
        if (!GameManager.instnace.isGameStarted) return;

        puzzleInHand = puzzleBlock;
        puzzleInHand.state = PuzzleBlockState.InCharacterHand;
        puzzleInHand.transform.position = handPoint.position;
        puzzleInHand.transform.parent = handPoint;
        puzzleInHand.transform.localRotation = Quaternion.identity;

        puzzleInHand.transform.localScale = Vector3.one * 0.4f;

        puzzleInHand.spawnPoint.PuzzleBlockPicked();

        HandUpAnimation(true);
    }

    public virtual void Initilize(int id)
    {
        characterId = id;
        GetComponentInChildren<SkinnedMeshRenderer>().material = GameManager.instnace.currentLevel.idMaterials[id];

    }

    public void HandUpAnimation(bool handUp)
    {
        animator.SetBool("HandsUp", handUp);
    }


    public void Dance()
    {
        animator.SetTrigger("Dance");
    }


}
