using Pathfinding;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    #region Fields
    [SerializeField] float stopDistance = 0.25f;

    AIDestinationSetter aiDestination;
    Transform player;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Update () {
        StopNearTarget();
    }
    #endregion

    void MakeReferences () {
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

    void OnDisable () {
        aiDestination.target = transform;
    }
}
