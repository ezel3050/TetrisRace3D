using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioListener))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instnace;
    public SpawnableAS spawnableASPrefab;
    public List<AudioClip> clipList;

    AudioListener listener;

    private void Awake()
    {
        instnace = this;
        DontDestroyOnLoad(gameObject);
        listener = GetComponent<AudioListener>();
    }

    public void SetAudioMute(bool mute)
    {
        listener.enabled = !mute;
    }

    public void PlayClip(int clipIndex)
    {
        if (PlayerPrefs.GetInt("SFXOn" , 1) == 0) return;
        SpawnableAS ISpawnableAS = Instantiate(spawnableASPrefab);
        ISpawnableAS.Init(clipList[clipIndex]);
    }


}
