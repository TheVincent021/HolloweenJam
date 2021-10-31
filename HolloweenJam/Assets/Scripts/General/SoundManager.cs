using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Sound[] sounds;
    [SerializeField] RoundRobin[] roundRobins;

    public bool isPlaying;

    public static SoundManager instance;

    void Awake () {
        Singleton();
        SetupSounds();
        SetupRobins();
    }

    void Update () {
        DontDestroyOnLoad(this.gameObject);
    }

    void Singleton () {
        if (SoundManager.instance != null && SoundManager.instance != this) {
            Destroy(this.gameObject);
        } else {
            SoundManager.instance = this;
        }
    }

    void SetupSounds () {
        foreach (var sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.isLoop;
            sound.source.bypassListenerEffects = sound.bypassListenerEffects;
        }
    }

    void SetupRobins () {
        foreach (var robin in roundRobins) {
            robin.source = gameObject.AddComponent<AudioSource>();
            robin.source.volume = robin.volume;
            robin.source.pitch = robin.pitch;
        }
    }

    public void Play (string name) {
        FindSoundOrRobin(name, true);
    }

    public void Stop (string name) {
        FindSoundOrRobin(name, false);
    }

    public Sound GetSound (string name) {
        foreach (var sound in sounds) {
            if (sound.name == name) {
                return sound;
            }
        }
        return null;
    }

    void FindSoundOrRobin (string name, bool play) {
        foreach (var sound in sounds) {
            if (sound.name == name) {
                if (play) PlaySound(sound);
                else StopSound(sound);
                return;
            }
        }
        if (!play) {
            Debug.Log("No sound is playing named " + name + ".");
            return;
        }
        foreach (var robin in roundRobins) {
            if (robin.name == name) {
                PlayRobin(robin);
                return;
            }
        }
        Debug.LogError("There is no " + name + " at sound database!");
    }

    void PlaySound (Sound sound) {
        sound.source.Play();
    }


    void StopSound (Sound sound) {
        sound.source.Stop();
    }

    void PlayRobin (RoundRobin robin) {
        robin.source.clip = robin.nextClip;
        robin.source.Play();
    }
}

[System.Serializable]
public class Sound {
    public string name;
    public AudioClip clip;

    public float volume = 0f;
    public float pitch = 0f;

    public bool isLoop = false;
    public AudioSource source;
    public bool bypassListenerEffects;
}

[System.Serializable]
public class RoundRobin
{
    public string name;
    [SerializeField] AudioClip[] clips;

    public float volume = 0f;
    public float pitch = 0f;

    public AudioSource source;

    int counter = -1;

    public AudioClip nextClip {
        get {
            counter += 1;
            if (counter > clips.Length - 1) counter = 0;
            return clips[counter];
        }
    }
}


