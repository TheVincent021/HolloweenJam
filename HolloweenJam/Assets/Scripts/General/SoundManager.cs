using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource playerSource;

    public static SoundManager instance;

    float nextPlay = 0f;

    void Awake () {
        Singleton();
    }

    void Singleton () {
        if (SoundManager.instance == null) {
            SoundManager.instance = this;
        } else {
            Destroy(this.gameObject);
        }
    }

    public void PlayerSourcePlayRR (RoundRobin robin, float delay = 0f) {
        if (delay > 0f) {
            if (Time.time >= nextPlay) {
                nextPlay = Time.time + delay;
                playerSource.PlayOneShot(robin.NextClip());
            }
        } else {
            playerSource.PlayOneShot(robin.NextClip());
        }
    }
}
