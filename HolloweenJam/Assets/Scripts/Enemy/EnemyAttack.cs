using Pathfinding;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool attack = false;
    public bool disabled = false;
    [SerializeField] int damage = 1;
    [SerializeField] float attackRange = 0.2f;
    [SerializeField] Transform[] targets;
    public Transform currentTarget;

    AIDestinationSetter aiDestination;

    void Awake () {
        MakeReferences();
    }

    void Update () {
        if (attack) {
            ChooseTarget();
            FollowTarget();
            Attack();
            CheckTargets();
        } else {
            currentTarget = transform;
            DisablePathfinding();
        }
    }

    void OnTriggerEnter2D (Collider2D col) {
        if ((col.CompareTag("Player") || col.CompareTag("Follower")) && !disabled) {
            attack = true;
        }
    }

    void MakeReferences () {
        aiDestination = GetComponent<AIDestinationSetter>();
    }

    void ChooseTarget () {
        var smallestDistance = Vector3.Distance(transform.position, targets[0].position);
        currentTarget = targets[0];
        foreach (var target in targets) {
            var distance = Vector3.Distance(transform.position, target.position);
            if (distance < smallestDistance && target.GetComponent<IHealth>() != null) {
                smallestDistance = distance;
                currentTarget = target;
            }
        }
    }

    void FollowTarget () {
        aiDestination.target = currentTarget;
    }

    void Attack () {
        if (currentTarget.GetComponent<IHealth>() != null) {
            if (Vector3.Distance(transform.position, currentTarget.position) <= attackRange)
                currentTarget.GetComponent<IHealth>().Damage(damage);
        }
    }

    void CheckTargets () {
        foreach (var target in targets) {
            if (target.GetComponent<IHealth>() != null) {
                return;
            }
        }
        AllTargetsAreDead();
    }

    void AllTargetsAreDead () {
        DisablePathfinding();
        GetComponentInChildren<EnemyAnimator>().Idle();
    }

    void DisablePathfinding () {
        GetComponentInParent<AIDestinationSetter>().target = transform;
    }
 }
