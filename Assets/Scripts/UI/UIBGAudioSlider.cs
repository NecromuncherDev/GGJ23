using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIBGAudioSlider : MonoBehaviour
{
    [Space]
    [Space]
    [Header("Audio")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _audioGroup;
    private Slider _slider;

    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustMusicVolumn()
    {
        _audioMixer.SetFloat(_audioGroup, _slider.value);
    }
}
