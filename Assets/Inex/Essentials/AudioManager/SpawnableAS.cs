using UnityEngine;

public class SpawnableAS : MonoBehaviour
{
    public AudioSource AS;

    public void Init(AudioClip ac, float volume =1)
    {
        AS.volume = volume == 1 ? AS.volume : volume;
        AS.clip = ac;
        AS.Play();
        Destroy(gameObject, ac.length);
    }
}
