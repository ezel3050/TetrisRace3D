using UnityEngine;

public class SpawnableAS : MonoBehaviour
{
    public AudioSource AS;

    public void Init(AudioClip ac)
    {
        AS.clip = ac;
        AS.Play();
        Destroy(gameObject, ac.length);
    }
}
