using System;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoSingleton<MusicManager>
{
    [SerializeField] FeelMusic[] musicMapView;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private MusicFeel feelOnStart = MusicFeel.Ambient;
    private Dictionary<MusicFeel, AudioClip> audioMap = new Dictionary<MusicFeel, AudioClip>();

    [Serializable]
    struct FeelMusic
    {
        [SerializeField] internal MusicFeel feel;
        [SerializeField] internal AudioClip clip;
    }

    internal void ChangeAudioFeel(MusicFeel feel)
    {
        if (audioMap.ContainsKey(feel))
            musicSource.clip = audioMap[feel];

        musicSource.Play();
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);

        foreach (var pair in musicMapView)
        {
            audioMap[pair.feel] = pair.clip;
        }
    }

    private void Start()
    {
        ChangeAudioFeel(feelOnStart);
    }

    public enum MusicFeel
    {
        Ambient,
        Combat
    }
}
