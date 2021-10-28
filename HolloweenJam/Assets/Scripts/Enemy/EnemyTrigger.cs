using Pathfinding;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] AIDestinationSetter[] enemies;

    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Player")) {
            foreach (var enemy in enemies) {
                enemy.target = col.transform;
            }
            Destroy(this.gameObject);
        }
    }
}
