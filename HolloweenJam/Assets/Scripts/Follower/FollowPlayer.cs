using Pathfinding;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float stopDistance = 0.25f;

    AIPath aiPath;
    AIDestinationSetter aiDestination;
    Transform player;

    void Awake () {
        MakeReferences();
    }

    void Update () {
        StopNearTarget();
    }

    void MakeReferences () {
        aiPath = GetComponent<AIPath>();
        aiDestination = GetComponent<AIDestinationSetter>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void StopNearTarget () {
        if (Vector3.Distance(transform.position, player.position) <= stopDistance) {
            aiDestination.target = transform;
        } else {
            aiDestination.target = player;
        }
    }
}
