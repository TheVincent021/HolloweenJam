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

    void Start () {
        Initialization();
    }
    #endregion

    void MakeReferences () {
        eventHandler = GetComponent<FollowerEventHandler>();
    }

    void Initialization () {
        health = PlayerStats.health - 1;
        UIManager.instance.ResetFollowerHearts();
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

    public void Heal (int amount) {
        health += amount;
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
    
}
