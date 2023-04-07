using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock : MonoBehaviour
{
    public int blockId;
    public Transform endPoint;
    public GameObject endCollider;
    public PuzzleBlockState state;

    private void OnTriggerEnter(Collider other)
    {
        if (state != PuzzleBlockState.NotPickedUp) return;
        Character character = other.GetComponent<Character>();
        if (character == null) return;
        if (character.characterId != blockId) return;
        if (character.puzzleInHand != null) return;

        character.PickUpPuzzleBlock(this);
    }

}

public enum PuzzleBlockState
{
    NotPickedUp, InCharacterHand, Placed
}