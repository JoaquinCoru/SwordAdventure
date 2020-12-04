using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip audioCoin;
    public AudioClip audioKey;
    public AudioClip audioJump;
    public AudioClip musicLevel;
    public AudioClip audioFire;
    public AudioClip audioDamage;
    public AudioClip audioLand;
    public AudioClip audioInvencible;

    //public AudioClip audioDead;
    public AudioClip levelCompleted;
    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        PlayLevelMusic();
    }
 

    public void PlayAudioCoin()
    {
        audioSource.PlayOneShot(audioCoin);
    }

    public void PlayAudioKey()
    {
        audioSource.PlayOneShot(audioKey);
    }

    public void PlayAudioJump()
    {
        audioSource.PlayOneShot(audioJump);
    }

    public void PlayAudioDamage()
    {
        audioSource.PlayOneShot(audioDamage);
    }

    public void PlayAudioFire()
    {
        audioSource.PlayOneShot(audioFire);
    }

    public void PlayAudioLand()
    {
        audioSource.PlayOneShot(audioLand);
    }

    public void PlayAudioInvencible()
    {
        audioSource.Pause();
        audioSource.clip = audioInvencible;
        audioSource.Play();
    }

    public void PlayLevelMusic()
    {
        audioSource.Pause();
        audioSource.clip = musicLevel;
        audioSource.Play();
    }

    
}
