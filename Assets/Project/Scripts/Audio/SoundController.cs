using System;
using UnityEngine;

public class SoundController : IDisposable
{
    private SoundView soundView;
    private EventService eventService;
    public SoundController(SoundView soundView, EventService eventService)
    {
        this.soundView = soundView;
        this.eventService = eventService;
        SubscribeEvents();
    }

    private void SubscribeEvents() 
    {
        eventService.OnBGMusicPlay.AddListener(PlayBGMusic);
        eventService.OnSoundEffectPlay.AddListener(PlaySoundEffect);
        eventService.OnBGMusicVolumeChange.AddListener(ChangeBGMusicVolume);
    }

    private void PlayBGMusic(Sounds sound)
    {
        AudioClip audioClip = GetAudioClip(sound);
        if (audioClip != null)
        {
            soundView.BGMusic.clip = audioClip;
            soundView.BGMusic.Play();
        }
        else
        {
            Debug.Log("Clip not found");
        }
    }

    private void PlaySoundEffect(Sounds sound)
    {
        AudioClip audioClip = GetAudioClip(sound);
        if (audioClip != null)
        {
            soundView.SoundEffect.PlayOneShot(audioClip);
        }
        else
        {
            Debug.Log("Clip not found");
        }
    }

    private AudioClip GetAudioClip(Sounds sound)
    {
        AudioClip audioClip = System.Array.Find(soundView.SoundType, i => i.soundType == sound).soundClip;
        if (audioClip != null)
            return audioClip;
        else 
            return null;
    }

    private void ChangeBGMusicVolume(float value) => soundView.BGMusic.volume = value;

    private void UnsubscribeEvents() 
    {
        eventService.OnBGMusicPlay.RemoveListener(PlayBGMusic);
        eventService.OnSoundEffectPlay.RemoveListener(PlaySoundEffect);
        eventService.OnBGMusicVolumeChange.RemoveListener(ChangeBGMusicVolume);
    }

    public void Dispose()
    {
        UnsubscribeEvents();
    }
}