using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;

    void Start()
    {
        slider.value = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        mixer.SetFloat("BGMVolume", slider.value - 80f);
    }
}
