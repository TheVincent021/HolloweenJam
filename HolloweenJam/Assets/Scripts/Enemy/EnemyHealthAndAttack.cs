using System.Collections;
using Pathfinding;
using UnityEngine;

public class EnemyHealthAndAttack : MonoBehaviour
{
    [SerializeField] int health = 4;
    [SerializeField] int damage = 1;
    [SerializeField] float attackRange = 1f;
    EnemyAnimator m_animator;

    Transform player;

    void Awake () {
        MakeReferences();
    }

    void Update () {
        Attack();
    }

    void MakeReferences () {
        m_animator = transform.parent.gameObject.GetComponentInChildren<EnemyAnimator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Bullet")) {
            Damage(col.transform.position);
        }
    }

    void Damage (Vector3 bulletPosition) {
        if (health > 1) health--;
        else Die();

        m_animator.Damage();
        var forceDirection = bulletPosition - GameObject.FindWithTag("Barrel").transform.position;
        forceDirection.Normalize();
        GetComponentInParent<Rigidbody2D>().AddForce(forceDirection * 200f);
    }

    void Die () {
        Destroy(GetComponentInParent<AIDestinationSetter>());
        Destroy(GetComponentInParent<AIPath>());
        Destroy(GetComponentInParent<Seeker>());
        Destroy(m_animator);
        transform.parent.gameObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Below";
        StartCoroutine(DestroyCollider());
    }

    void Attack () {
        if (Vector3.Distance(transform.position, player.position) <= attackRange)
            player.GetComponent<PlayerHealth>().Damage(damage);
    }

    IEnumerator DestroyCollider () {
        yield return new WaitForSeconds(0.1f);
        Destroy(GetComponentInParent<CircleCollider2D>());
        Destroy(this.gameObject);
    }
}
