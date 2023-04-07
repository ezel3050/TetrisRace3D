using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawnPoint : MonoBehaviour
{
    public PuzzleBlock puzzleBlockInside;
    public Stage stage;
    int delayUntilRespawn = 3;

//Replace stage with the stage in the GameManager
//Contenue initilizing the level
//after everything initilized perfectly (including AIs and Player)
//make the AIs Work baby

    public void SpawnPuzzleInside(int id, int forcedPuzzle = -1)
    {
        int puzzleToSpawn = forcedPuzzle;
        if(forcedPuzzle == -1)
        {
            puzzleToSpawn = Random.Range(0, Resources.instance.puzzleBlocksPrefabs.Count);
        }

        puzzleBlockInside = Instantiate(Resources.instance.puzzleBlocksPrefabs[puzzleToSpawn]);
        puzzleBlockInside.transform.position = transform.position;
        puzzleBlockInside.transform.rotation = transform.rotation;

        stage.listOfListSpawnedPuzzles[id].listOfSpawnedPuzzles.Add(puzzleBlockInside);


        puzzleBlockInside.Initiliez(id);
    }

    public void PuzzleBlockPicked()
    {
        stage.listOfListSpawnedPuzzles[puzzleBlockInside.blockId].listOfSpawnedPuzzles.Remove(puzzleBlockInside);
        puzzleBlockInside = null;
        this.CallWithDelay(() =>
        {
            SpawnPuzzleInside(stage.IdWithLowestSpawnedPuzzleItem());
        }, delayUntilRespawn);
    }


    public bool isFull()
    {
        return puzzleBlockInside != null;
    }

    public bool isEmpty()
    {
        return puzzleBlockInside == null;
    }


}








//He who has a why, Can bear almost any how....