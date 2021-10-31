using UnityEngine;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;

    void Awake()
    {
        Singleton();
    }

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

    void Update()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Singleton()
    {
        if (MusicManager.instance != null && MusicManager.instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            MusicManager.instance = this;
        }
    }

    void PlayMusic(string start, string loop)
    {
        SoundManager.Play(start);
        StartCoroutine(PlayLoop(loop, start.length));
    }

    IEnumerator PlayLoop(string loop, float delay)
    {
        yield return new WaitForSeconds(delay);
        SoundManager.Play(loop);
    }


}