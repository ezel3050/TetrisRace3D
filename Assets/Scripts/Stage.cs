using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int maxPuzzlePerEnemy;
    public List<PuzzleStation> stations;
    public List<ListOfListOfSpawnedPuzzles> listOfListSpawnedPuzzles = new List<ListOfListOfSpawnedPuzzles>();
    public List<PuzzleSpawnPoint> puzzleSpawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnFirstPuzzleBlocks());
        InitilizeStations();
    }

    
    public IEnumerator SpawnFirstPuzzleBlocks()
    {
        List<PuzzleSpawnPoint> emptySpawnPoints = new List<PuzzleSpawnPoint>(puzzleSpawnPoints);
        int idIndex = 0;
        foreach (ListOfListOfSpawnedPuzzles listOfSpawnedPuzzles in listOfListSpawnedPuzzles)
        {
            for (int i = 0; i < maxPuzzlePerEnemy; i++)
            {
                int randomSpawnPoint;
                randomSpawnPoint = Random.Range(0, emptySpawnPoints.Count);

                emptySpawnPoints[randomSpawnPoint].SpawnPuzzleInside(idIndex);
                emptySpawnPoints.RemoveAt(randomSpawnPoint);

            }
            idIndex++;
        }
        yield return new WaitForEndOfFrame();

    }

    void InitilizeStations()
    {
        int i = 0;
        foreach(PuzzleStation station in stations)
        {
            station.Initilize(i);
            if (GameManager.instnace.currentLevel.stages.IndexOf(this) == GameManager.instnace.currentLevel.stages.Count - 1)
            {
                station.endPuzzleBlock.gameObject.SetActive(false);
            }
            i++;
        }
    }


    public int IdWithLowestSpawnedPuzzleItem()
    {
        int currentLowest = 0;
        int index = 0;
        foreach(ListOfListOfSpawnedPuzzles listOfSpawnedPuzzles in listOfListSpawnedPuzzles)
        {
            if(listOfSpawnedPuzzles.listOfSpawnedPuzzles.Count < listOfListSpawnedPuzzles[currentLowest].listOfSpawnedPuzzles.Count)
            {
                currentLowest = index;
            }
            index++;
        }
        return currentLowest;
    }

}
