using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerHealth : MonoBehaviour, IHealth
{
    #region Fields
    [SerializeField] int health = 5;
    [SerializeField] float recoveryTime = 1f;
    [SerializeField] GameObject gun;
    public bool isRecovering = false;

    PlayerAnimator m_animator;
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
        m_animator = GetComponentInChildren<PlayerAnimator>();
    }

    void Initialization () {
        health = PlayerStats.health;
    }

    public void Hit (int damage) {
        if (!isRecovering) {
            if (health > 1) {
                StartCoroutine(Recovery());
                health--;
                PlayPlayerPain();
            }
            else Die();
            m_animator.Damage();
            HUDManager.instance.DamagePlayer();
            Camera.main.GetComponent<CameraShake>().Shake(0.15f, 0.15f);
        }
    }

    IEnumerator Recovery () {
        isRecovering = true;
        yield return new WaitForSeconds(recoveryTime);
        isRecovering = false;
    }

    public void Die () {
        m_animator.Die();
        Destroy(gun);
        Destroy(m_animator);
        Destroy(GetComponent<PlayerMovement>());
        Destroy(GetComponent<PlayerInput>());
        Destroy(GetComponent<Rigidbody2D>());
        Destroy(this);
    }

    public void Heal (int amount) {
        health += amount;
    }

    void PlayPlayerPain()
    {
        SoundManager.instance.Play("Player_Pain");
    }
}
