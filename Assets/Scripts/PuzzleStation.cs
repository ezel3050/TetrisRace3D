using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStation : MonoBehaviour
{
    public List<PuzzleBlock> puzzleBlocks;
    public PuzzleBlock endPuzzleBlock;
    public Transform boxColliderDummy;

    public int stationId;
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
        AudioManager.instnace.PlayClip(0);

    }


    public void AddPuzzleBlockToStation(Character character)
    {
        Vector3 placementPos = puzzleBlocks[puzzleBlocks.Count - 1].endPoint.position; 
        character.puzzleInHand.transform.parent = transform;
        character.puzzleInHand.transform.rotation= Quaternion.identity;
        character.puzzleInHand.transform.position = placementPos;
        character.puzzleInHand.transform.localScale = Vector3.one * 0.77f;

        character.puzzleInHand.SetCollidersActive(true);
        character.puzzleInHand.SetNavMeshObstaclesActive(true , true);


        ParticleSystem IPlacementParticle = Instantiate(Resources.instance.placementParticle, placementPos + (Vector3.up * 0.5f) + (Vector3.forward * 0.75f), Quaternion.identity);
        IPlacementParticle.Play();
        Destroy(IPlacementParticle.gameObject, 4);



        puzzleBlocks.Add(character.puzzleInHand);

        character.puzzleInHand = null;
        character.HandUpAnimation(false);

        PlaceBoxColliderAtTheEnd();

        if (isStationConnectedToTheEnd())
        {
            boxColliderDummy.gameObject.SetActive(false);

            EnemyAI enemyAI = character.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                this.CallWithDelay(() =>
                {
                    enemyAI.ThisStationIsFinished();

                }, 0.1f);
            }

            //is player
            else
            {
                Player.instance.currentStage++;
            }
            
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
