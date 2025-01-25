using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    [SerializeField] AudioSource audioSource_Music;
    [SerializeField] AudioSource audioSource_SE;
    [SerializeField] AudioClip mainTitleClip;

    [Header("MUSIC")]
    public AudioClip TITLE;
    
    public AudioClip PLAY;
    public AudioClip DEATH;
    public AudioClip INTENSE;


    [Header("SE")]
    public AudioClip BOUNCE;
    public AudioClip EXPLODE;
    public AudioClip GRAVITY;
    public AudioClip SHIELD;
    public AudioClip SPIKE;
    public AudioClip ARROW;
    public AudioClip WIN;


    void Start()
    {
        audioSource_Music.clip = mainTitleClip;
        audioSource_Music.Play();
    }

    public AudioClip returnMusicClip()
    {
        return audioSource_Music.clip;
    }

    public void Stop()
    {
        audioSource_Music.Stop();
    }


    public void playMusic(AudioClip clip)
    {
        audioSource_Music.clip = clip;
        audioSource_Music.Play();
    }

    public void playSE(AudioClip clip)
    {
        audioSource_SE.clip = clip;
        audioSource_SE.Play();
    }
}
