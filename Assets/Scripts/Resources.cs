using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public static Resources instance;
    public List<PuzzleBlock> puzzleBlocksPrefabs;
    public List<Material> idMaterials;


    private void Awake()
    {
        instance = this;
    }


}
