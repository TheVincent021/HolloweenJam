using System.Collections;
using Pathfinding;
using UnityEngine;

public class EnemyHealthAndAttack : MonoBehaviour
{
    #region Fields
    [SerializeField] int health = 4;
    [SerializeField] int damage = 1;
    [SerializeField] float attackRange = 1f;
    EnemyAnimator m_animator;

    Transform player;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Update () {
        Attack();
    }
    #endregion

    void MakeReferences () {
        m_animator = transform.parent.gameObject.GetComponentInChildren<EnemyAnimator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Bullet")) {
            Damage();
            Knockback(col.transform.position);
        }
    }

    void Damage () {
        if (health > 1) health--;
        else Die();

        m_animator.Damage();
    }

    void Knockback (Vector3 contactPosition) {
        var forceDirection = contactPosition - GameObject.FindWithTag("Barrel").transform.position;
        forceDirection.Normalize();
        GetComponentInParent<Rigidbody2D>().AddForce(forceDirection * 200f);
    }

    void Die () {
        DisablePathfinding();
        m_animator.Die();
        Destroy(m_animator);
        transform.parent.gameObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Below";
        StartCoroutine(DestroyCollider());
    }

    void Attack () {
        if (player.GetComponent<PlayerHealth>() != null) {
            if (Vector3.Distance(transform.position, player.position) <= attackRange)
                player.GetComponent<PlayerHealth>().Damage(damage);
        } else {
            PlayerIsDead();
        }
    }

    void PlayerIsDead () {
        DisablePathfinding();
        m_animator.Idle();
    }

    void DisablePathfinding () {
        GetComponentInParent<AIDestinationSetter>().target = transform.parent;
    }

    IEnumerator DestroyCollider () {
        yield return new WaitForSeconds(0.1f);
        Destroy(GetComponentInParent<CircleCollider2D>());
        Destroy(this.gameObject);
    }
}
