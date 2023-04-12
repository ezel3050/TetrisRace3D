using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomText : MonoBehaviour
{
    public List<string> texts = new List<string>();

    TextMeshProUGUI textMesh;
    TextMeshPro textMeshPro;

    private void Awake()
    {

    }

    private void OnEnable()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMeshPro = GetComponent<TextMeshPro>();

        int randomN; 
        randomN = Random.Range(0, texts.Count); 

        if (textMesh)
            textMesh.text = texts[randomN];

        if (textMeshPro)
            textMeshPro.text = texts[randomN];
    }


}
