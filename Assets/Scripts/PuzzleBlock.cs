using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class PuzzleBlock : MonoBehaviour
{
    public int verticalBlockN;
    public int blockId;
    public List<MeshRenderer> blockPieces;
    public Transform endPoint;
    public GameObject endCollider;
    public PuzzleBlockState state;

    [HideInInspector] public PuzzleSpawnPoint spawnPoint;


    private void Awake()
    {
        SetBlockPieces();
        SetCollidersActive(false);
        SetNavMeshObstaclesActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (state != PuzzleBlockState.NotPickedUp) return;
        Player player = other.GetComponent<Player>();
        if (player == null) return;
        if (player.characterId != blockId) return;
        if (player.puzzleInHand != null) return;

        player.PickUpPuzzleBlock(this);
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

    public void SetCollidersActive(bool active)
    {
        foreach(BoxCollider boxCollider in GetComponentsInChildren<BoxCollider>())
        {
            if (boxCollider.isTrigger) continue;
            boxCollider.enabled = active;
        }
    }
    public void SetNavMeshObstaclesActive(bool active,  bool happenWithDelay= false) 
    {
        this.CallWithDelay(() =>
        {
            foreach (NavMeshObstacle obstacle in GetComponentsInChildren<NavMeshObstacle>())
            {
                obstacle.enabled = active;
            }
        }, happenWithDelay ? 3 : 0);
    }

}

public enum PuzzleBlockState
{
    NotPickedUp, InCharacterHand, Placed
}

