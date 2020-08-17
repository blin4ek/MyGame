using System.Collections;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip[] clips;

    private AudioSource music;

    private static AudioController Instance = null;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        music = GetComponent<AudioSource>();
        StartCoroutine(PlayMusic());
    }

    IEnumerator PlayMusic()
    {
        yield return null;
        for (int i = 0; i < clips.Length; i++)
        {
            music.clip = clips[i];
            music.Play();
            while (music.isPlaying)
            {
                yield return null;
            }
        }
    }
}