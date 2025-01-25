using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip mainTitleClip;

    void Start()
    {
        audioSource.clip = mainTitleClip;
        audioSource.Play();
    }
}
