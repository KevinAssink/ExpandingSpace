using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderAudio : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public Slider volumeSlider;

    AudioSource audioSource;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (!audioSource.playOnAwake)
        {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volumeSlider.value;
        if (!audioSource.isPlaying)
       {
            audioSource.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            audioSource.Play();
       }
    }

    //Called when Slider is moved
    void changeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
    }

    void OnDisable()
    {
        volumeSlider.onValueChanged.RemoveAllListeners();
    }
}
//volumeSlider.onValueChanged.AddListener(delegate { changeVolume(volumeSlider.value); });