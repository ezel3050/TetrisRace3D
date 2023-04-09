using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStation : MonoBehaviour
{
    public List<PuzzleBlock> puzzleBlocks;
    public PuzzleBlock endPuzzleBlock;
    public Transform boxColliderDummy;

    int stationId;
    BoxCollider boxCollider;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        PlaceBoxColliderAtTheEnd();

    }


    public void Initilize(int id)
    {
        stationId = id;
        foreach(PuzzleBlock block in puzzleBlocks)
        {
            block.Initiliez(id);
            block.SetCollidersActive(true);
            block.SetNavMeshObstaclesActive(true);
        }

        endPuzzleBlock.Initiliez(id);
        endPuzzleBlock.SetCollidersActive(true);
        endPuzzleBlock.SetNavMeshObstaclesActive(true); 
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player== null) return;
        if (player.characterId != stationId) return;
        if (player.puzzleInHand == null) return;
        
        AddPuzzleBlockToStation(player);
    }


    public void AddPuzzleBlockToStation(Character character)
    {
        character.puzzleInHand.transform.parent = transform;
        character.puzzleInHand.transform.rotation= Quaternion.identity;
        character.puzzleInHand.transform.position = puzzleBlocks[puzzleBlocks.Count - 1].endPoint.position;
        character.puzzleInHand.transform.localScale = Vector3.one * 0.77f;

        character.puzzleInHand.SetCollidersActive(true);
        character.puzzleInHand.SetNavMeshObstaclesActive(true , true);

        puzzleBlocks.Add(character.puzzleInHand);

        character.puzzleInHand = null;
        character.HandUpAnimation(false);

        PlaceBoxColliderAtTheEnd();

        EnemyAI enemyAI = character.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            this.CallWithDelay(() =>
            {
                if (isStationConnectedToTheEnd())
                {
                    enemyAI.ThisStationIsFinished();
                }

            }, 0.1f);
        }
    }

    public bool isStationConnectedToTheEnd()
    {
        return Vector3.Distance(puzzleBlocks[puzzleBlocks.Count - 1].transform.position, endPuzzleBlock.transform.position) <= 2;
    }


    void PlaceBoxColliderAtTheEnd()
    {
        boxColliderDummy.transform.position = puzzleBlocks[puzzleBlocks.Count - 1].endPoint.position;
        boxCollider.center = boxColliderDummy.transform.localPosition;


    }


}
