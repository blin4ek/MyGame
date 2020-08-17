using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    [SerializeField] private Toggle OnOffMusic;
    [SerializeField] private AudioMixerGroup musicVolume;

    private void Start()
    {
        OnOffMusic.isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        OnOffVolume(OnOffMusic.isOn);
    }

    public void OnOffVolume(bool enabled)
    {
        if (!enabled)
        {
            musicVolume.audioMixer.SetFloat("Volume", -80);
        }
        else
        {
            musicVolume.audioMixer.SetFloat("Volume", 0);
        }
        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }
}
