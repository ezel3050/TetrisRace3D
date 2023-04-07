using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBlock : MonoBehaviour
{
    public int blockId;
    public List<MeshRenderer> blockPieces;
    public Transform endPoint;
    public GameObject endCollider;
    public PuzzleBlockState state;

    private void Awake()
    {
        SetBlockPieces();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state != PuzzleBlockState.NotPickedUp) return;
        Character character = other.GetComponent<Character>();
        if (character == null) return;
        if (character.characterId != blockId) return;
        if (character.puzzleInHand != null) return;

        character.PickUpPuzzleBlock(this);
    }

    public void Initiliez(int id)
    {
        blockId = id;
        SetBlockPiecesMaterial(id);
    }


    void SetBlockPiecesMaterial(int idIndex)
    {
        foreach(MeshRenderer blockPiece in blockPieces)
        {
            blockPiece.material = Resources.instance.idMaterials[idIndex];
        }
    }

    void SetBlockPieces()
    {
        foreach(MeshRenderer meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            blockPieces.Add(meshRenderer);
        }
    }

}

public enum PuzzleBlockState
{
    NotPickedUp, InCharacterHand, Placed
}

