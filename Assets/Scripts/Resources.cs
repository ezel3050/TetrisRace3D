using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public static Resources instance;
    public List<PuzzleBlock> puzzleBlocksPrefabs;
    public ParticleSystem placementParticle;

    private void Awake()
    {
        instance = this;
    }


}
