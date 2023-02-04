using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoSingleton<MusicManager>
{
    [SerializeField] private Dictionary<MusicFeel, AudioClip> audioMap;
    [SerializeField] AudioSource musicSource;
    [SerializeField] MusicFeel feelOnStart;

    internal void ChangeAudioFeel(MusicFeel feel)
    {
        if (audioMap.ContainsKey(feel))
            musicSource.clip = audioMap[feel];
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
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
