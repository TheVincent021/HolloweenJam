using System.Collections;
using UnityEngine;

public class FollowerHealth : MonoBehaviour, IHealth
{
    #region Fields
    [SerializeField] int health = 2;
    [SerializeField] float recoveryTime = 1f;
    public bool isRecovering = false;

    FollowerEventHandler eventHandler;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }
    #endregion

    void MakeReferences () {
        eventHandler = GetComponent<FollowerEventHandler>();
    }

    public void Hit (int damage) {
        if (!isRecovering) {
            if (health > 1) {
                Damage();
            } else {
                Die();
             }
        }
    }

    void Damage () {
        health--;
        StartCoroutine(Recovery());
        // EVENT
        eventHandler.Damage();
        PlayFollowerPain();
    }

    IEnumerator Recovery () {
        isRecovering = true;
        yield return new WaitForSeconds(recoveryTime);
        isRecovering = false;
    }

    public void Die () {
        eventHandler.Die(false);
        Destroy(this);
    }

    public void PlayFollowerPain()
    {
        SoundManager.instance.Play("Follower_Pain");
    }
    public void PlayFollowerDeath()
    {
        SoundManager.instance.Play("Follower_Death");
        SoundManager.instance.Play("Stinger_FollowerDeath");
    }
}
