using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuzzlePlaceStation : MonoBehaviour
{
    public int stationId;
    public List<PuzzleBlock> puzzleBlocks;
    public Transform boxColliderDummy;
    BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        PlaceBoxColliderAtTheEnd();
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character == null) return;
        if (character.characterId != stationId) return;
        if (character.puzzleInHand == null) return;

        character.puzzleInHand.transform.parent = transform;
        character.puzzleInHand.transform.position = puzzleBlocks[puzzleBlocks.Count - 1].endPoint.position;
        character.puzzleInHand.transform.localScale = Vector3.one;
        puzzleBlocks.Add(character.puzzleInHand);
        character.puzzleInHand = null;
        character.HandUpAnimation(false);

        PlaceBoxColliderAtTheEnd();
    }


    void PlaceBoxColliderAtTheEnd()
    {
        boxColliderDummy.transform.position = puzzleBlocks[puzzleBlocks.Count - 1].endPoint.position;
        boxCollider.center = boxColliderDummy.transform.localPosition;


    }


}
