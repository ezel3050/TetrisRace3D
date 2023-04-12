using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinPartOfPlayer : MonoBehaviour
{
    [HideInInspector] public SkinnedMeshRenderer skinnedMeshRenderer;
    private void Awake()
    {
        skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

}
