using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    void Start()
    {
        if (SoundManager.instance.isPlaying = true)
            {
            if (PlayerStats.sacrificedCount < 1)
            {
                PlayMusic("Music_NoSacrificeStart", "Music_NoSacrificeLoop");
            }
            if (PlayerStats.sacrificedCount > 0)
            {
                PlayMusic("Music_MidSacrificeStart", "Music_MidSacrificeLoop");
            }
            if (PlayerStats.sacrificedCount > 2)
            {
                PlayMusic("Music_HighSacrificeStart", "Music_HighSacrificeLoop");
            }
            else
                return;
        }
    }

    void PlayMusic(string start, string loop)
    {
        SoundManager.instance.isPlaying = true;
        SoundManager.instance.Play(start);
        currentMusic = start;
        StartCoroutine(PlayLoop(loop, SoundManager.instance.GetSound(start).clip.length));

    }

    IEnumerator PlayLoop(string loop, float delay)
    {
        yield return new WaitForSeconds(delay);
        currentMusic = loop;
        SoundManager.instance.Play(loop);

    }

    public string currentMusic;

    public void StopMusic()
    {
        
        SoundManager.instance.Stop(currentMusic);
        SoundManager.instance.isPlaying = false;
        Destroy(this.gameObject);
    }
}