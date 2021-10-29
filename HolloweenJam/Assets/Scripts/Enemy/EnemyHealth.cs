using System.Collections;
using Pathfinding;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
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
    #endregion

    void MakeReferences () {
        m_animator = transform.parent.gameObject.GetComponentInChildren<EnemyAnimator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Bullet")) {
            Damage();
            if (!GetComponentInParent<EnemyAttack>().disabled)
                GetComponentInParent<EnemyAttack>().attack = true;
            Knockback(col.transform.position);
        }
    }

    void Damage ()
    {
        if (health - PlayerStats.damage > 0)
        { 
            health -= PlayerStats.damage;
            PlayGhoulPain();
        }
        else
        {
            Die();
            PlayGhoulDeath();
        }

        m_animator.Damage();
    }

    void Knockback (Vector3 contactPosition) {
        var forceDirection = contactPosition - GameObject.FindWithTag("Barrel").transform.position;
        forceDirection.Normalize();
        GetComponentInParent<Rigidbody2D>().AddForce(forceDirection * PlayerStats.bulletForce);
    }

    void Die () {
        m_animator.Die();
        Destroy(m_animator);
        GetComponentInParent<EnemyAttack>().disabled = true;
        GetComponentInParent<EnemyAttack>().attack = false;
        transform.parent.gameObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Below";
        StartCoroutine(DestroyCollider());
    }

    IEnumerator DestroyCollider () {
        yield return new WaitForSeconds(0.1f);
        Destroy(GetComponentInParent<CircleCollider2D>());
        Destroy(this.gameObject);
    }

    void PlayGhoulPain() {
        SoundManager.instance.Play("Ghoul_Pain");
    }

    void PlayGhoulDeath() {
        SoundManager.instance.Play("Ghoul_Death");
    }

}
