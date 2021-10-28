using System.Collections;
using Pathfinding;
using UnityEngine;

public class FollowerHealth : MonoBehaviour, IHealth
{
    #region Fields
    [SerializeField] int health = 2;
    [SerializeField] float recoveryTime = 1f;
    public bool isRecovering = false;

    FollowerAnimator m_animator;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }
    #endregion

    void MakeReferences () {
        m_animator = GetComponentInChildren<FollowerAnimator>();
    }

    public void Damage (int damage) {
        if (!isRecovering) {
            if (health > 1) {
                StartCoroutine(Recovery());
                health--;
            }
            else Die();
            m_animator.Damage();
        }
    }

    IEnumerator Recovery () {
        isRecovering = true;
        yield return new WaitForSeconds(recoveryTime);
        isRecovering = false;
    }

    public void Die () {
        m_animator.Die();
        Destroy(m_animator);
        Destroy(GetComponent<FollowPlayer>());
        Destroy(GetComponent<CircleCollider2D>());
        GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Below";
        GetComponent<AIDestinationSetter>().target = transform;
        Destroy(this);
    }
}
