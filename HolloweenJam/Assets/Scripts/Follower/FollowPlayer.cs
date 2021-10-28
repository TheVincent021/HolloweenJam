using Pathfinding;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float stopDistance = 0.25f;

    AIDestinationSetter aiDestination;
    Transform followPos;

    void Awake () {
        MakeReferences();
    }

    void Update () {
        StopNearTarget();
    }

    void MakeReferences () {
        aiDestination = GetComponent<AIDestinationSetter>();
        followPos = GameObject.FindWithTag("FollowerPos").transform;
    }

    void StopNearTarget () {
        if (Vector3.Distance(transform.position, followPos.position) <= stopDistance) {
            aiDestination.target = transform;
        } else {
            aiDestination.target = followPos;
        }
    }
}
