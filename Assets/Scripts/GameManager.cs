using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instnace;
    public List<Level> levels;
    public List<EnemyAI> enemyAIs;
    public int currentLevelIndex
    {
        get
        {
           return PlayerPrefs.GetInt(Globals.currentLevelIndexKey);
        }

        set
        {
            if (value >= levels.Count) value = 0;
            PlayerPrefs.SetInt(Globals.currentLevelIndexKey, value);
        }
    }

    private void Awake()
    {
        instnace = this;
    }

    private void Start()
    {
        ActivateCurrentLevel();
        InitilizeLevel();
    }



    void ActivateCurrentLevel()
    {
        DeactiveAllLevels();
        levels[currentLevelIndex].gameObject.SetActive(true);
    }

    void InitilizeLevel()
    {
        //Player positioning
        Player.instance.transform.position = levels[currentLevelIndex].spawnPoints[0].position;
        Player.instance.transform.rotation = levels[currentLevelIndex].spawnPoints[0].rotation;

        //AI
        Utilities.DeactivateAllEnemyAis();

        int index = 0;
        foreach(Transform spawnPoint in levels[currentLevelIndex].spawnPoints)
        {
            if (index == 0)
            {
                index++;
                continue;
            }

            enemyAIs[index].gameObject.SetActive(true);

            enemyAIs[index].transform.position = spawnPoint.position;
            enemyAIs[index].transform.rotation = spawnPoint.rotation;
            enemyAIs[index].puzzleStation = levels[currentLevelIndex].puzzleStations[index];

            enemyAIs[index].StartTheGame();

            index++;
        }

        
    }


    void DeactiveAllLevels()
    {
        foreach(Level level in levels)
        {
            level.gameObject.SetActive(false);
        }
    }



}
