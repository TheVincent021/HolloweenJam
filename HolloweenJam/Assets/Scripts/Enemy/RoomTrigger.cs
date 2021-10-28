using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] bool isClosed = false;
    [SerializeField] bool playerPassed = false;
    [SerializeField] bool followerPassed = false;
    [SerializeField] EnemyAttack[] enemies;
    [SerializeField] GameObject[] doors;

    void Update () {
        CheckEnemies();
        CheckToClose();
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Player") && !isClosed) {
            playerPassed = !playerPassed;
        } else if (col.CompareTag("Follower") && !isClosed) {
            followerPassed = !followerPassed;
        }
    }

    void CheckToClose () {
        if (playerPassed && (GameObject.FindWithTag("Follower").GetComponent<FollowerHealth>() == null || followerPassed) && !isClosed) {
            isClosed = true;
            CloseDoors();
        }
    }

    void CheckEnemies () {
        foreach (var enemy in enemies) {
            if (enemy.GetComponentInChildren<EnemyHealth>() != null) return;
        }
        OpenDoors();
        Destroy(this);
    }

    void AwakeEnemies () {
        foreach (var enemy in enemies) {
            enemy.disabled = false;
        }
    }

    void OpenDoors () {
        foreach (var door in doors) {
            door.SetActive(false);
        }
    }

    void CloseDoors () {
        foreach (var door in doors) {
            door.SetActive(true);
        }
    }
}
