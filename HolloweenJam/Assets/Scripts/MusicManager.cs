using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    void Start()
    {
        if (PlayerStats.followerSaved < 1)
        {
            PlayMusic("NoSacrifice_Start", "NoSacrifices_Loop");
        }
        if (PlayerStats.followerSaved > 0)
        {
            PlayMusic("MiddleSacrifice_Start", "Middlesacrifices_Loop");
        }
        if (PlayerStats.followerSaved > 2)
        {
            PlayMusic("HighSacrifice_Start", "HighSacrifice_Loop");
        }
        else
            return;
    }

    void PlayMusic(string start, string loop)
    {
        SoundManager.instance.Play(start);
        StartCoroutine(PlayLoop(loop, SoundManager.instance.GetSound(start).clip.length));
    }

    IEnumerator PlayLoop(string loop, float delay)
    {
        yield return new WaitForSeconds(delay);
        SoundManager.instance.Play(loop);
    }


}