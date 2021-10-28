using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    #region Fields
    [SerializeField] float minDistanceToAnimate = 0.5f;
    [SerializeField] bool isMoving = false;
    Animator m_animator;
    AIPath aiPath;
    AIDestinationSetter aiDestination;
    Transform target;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Update () {
        AnimateMovement();
    }
    #endregion

    void MakeReferences () {
        m_animator = GetComponent<Animator>();
        aiPath = GetComponentInParent<AIPath>();
        aiDestination = GetComponentInParent<AIDestinationSetter>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void AnimateMovement () {
        target = GetComponentInParent<EnemyAttack>().currentTarget;

        if (target != null && aiDestination.target != transform.parent && !isMoving)
            Move();
        else if (aiDestination.target == transform.parent)
            Idle();

        var direction = (target.position - transform.position).normalized;
        if (isMoving) {
            if (direction.x > 0f && direction.x > Mathf.Abs(direction.y)) {
                m_animator.Play("MoveRight");
            }
            if (direction.y > 0f && direction.y > Mathf.Abs(direction.x)) {
                m_animator.Play("MoveUp");
            }
            if (direction.x < 0f && Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) {
                m_animator.Play("MoveLeft");
            }
            if (direction.y < 0f && Mathf.Abs(direction.y) > Mathf.Abs(direction.x)) {
                m_animator.Play("MoveDown");
            }
        }
    }

    void Move () {
        isMoving = true;
        m_animator.SetTrigger("Move");
    }

    public void Idle() {
        isMoving = false;
        m_animator.SetTrigger("Idle");
    }

    // Called by EnemyHealthAndTrigger
    public void Damage () {
        m_animator.SetTrigger("Damage");
    }

    public void Die () {
        m_animator.SetTrigger("Died");
    }
}
