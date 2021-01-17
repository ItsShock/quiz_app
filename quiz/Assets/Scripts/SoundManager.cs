using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clipyAudio;
    AudioSource audios;
    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void OdtworzDzwiek(int numerKlipu)
    {
        audios.clip = clipyAudio[numerKlipu];
        audios.Play();

    }
}
