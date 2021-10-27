using System.Collections;
using Pathfinding;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 4;

    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Bullet")) {
            Damage(col.transform.position);
        }
    }

    void Damage (Vector3 bulletPosition) {
        if (health > 1) health--;
        else Die();

        var forceDirection = bulletPosition - GameObject.FindWithTag("Barrel").transform.position;
        forceDirection.Normalize();
        GetComponentInParent<Rigidbody2D>().AddForce(forceDirection * 200f);
    }

    void Die () {
        Destroy(GetComponentInParent<AIDestinationSetter>());
        Destroy(GetComponentInParent<AIPath>());
        Destroy(GetComponentInParent<Seeker>());
        Destroy(transform.parent.gameObject.GetComponentInChildren<EnemyAnimator>());
        transform.parent.gameObject.GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Below";
        StartCoroutine(DestroyCollider());
    }

    IEnumerator DestroyCollider () {
        yield return new WaitForSeconds(0.1f);
        Destroy(GetComponentInParent<CircleCollider2D>());
        Destroy(this.gameObject);
    }
}
