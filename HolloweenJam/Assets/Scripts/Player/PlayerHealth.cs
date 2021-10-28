using System.Collections;
using UnityEngine;

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
    #endregion

    void MakeReferences () {
        m_animator = GetComponentInChildren<PlayerAnimator>();
    }

    public void Damage (int damage) {
        if (!isRecovering) {
            
            if (health > 1) {
                StartCoroutine(Recovery());
                health--;
                PlayPlayerPain();
            }
            else Die();
            m_animator.Damage();
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
    void PlayPlayerPain()
    {
        SoundManager.instance.Play("Player_Pain");
    }
}
