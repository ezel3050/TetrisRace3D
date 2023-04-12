using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public int maxPuzzlePerEnemy;
    public List<PuzzleStation> stations;
    public List<ListOfListOfSpawnedPuzzles> listOfListSpawnedPuzzles = new List<ListOfListOfSpawnedPuzzles>();
    public List<PuzzleSpawnPoint> puzzleSpawnPoints;
    public List<Transform> characterSpawnPoints;
    public List<GameObject> levelDesigns;

    private void Awake()
    {

    }

    private void Start()
    {
        StartCoroutine(SpawnFirstPuzzleBlocks());

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

    public void InitilizeStations()
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < GameManager.instnace.currentLevel.idMaterials.Count; i++)
        {
            indexes.Add(i);
        }

        foreach (PuzzleStation station in stations)
        {
            int randomIndex;
            randomIndex = Random.Range(0, indexes.Count);
            station.Initilize(indexes[randomIndex]);
            indexes.RemoveAt(randomIndex);
        }
    }

        public void SetLevelDesign(int levelDesignIndex)
    {
        DeActivateAllLevelDesigns();
        levelDesigns[levelDesignIndex].SetActive(true);
    }

    void DeActivateAllLevelDesigns()
    {
        foreach(GameObject levelDesign in levelDesigns)
        {
            levelDesign.SetActive(false);
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
