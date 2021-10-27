using UnityEngine;

[System.Serializable]
public class RoundRobin
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] float delay = 0.3f;
    int counter = -1;

    public AudioClip NextClip () {
        counter += 1;
        Debug.Log(counter);
        if (counter > clips.Length - 1) counter = 0;
        return clips[counter];
    }

    public float Delay {
        get {
            return delay;
        }
    }
}
