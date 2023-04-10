using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    AudioSource AS;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        AS =GetComponent<AudioSource>();
        instance = this;
    }

    public void StopMusic()
    {
        AS.Pause();
    }

    public void ResumeMusic()
    {
        AS.Play();
    }


}
