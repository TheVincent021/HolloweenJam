using Pathfinding;
using UnityEngine;

public class FollowerAnimator : MonoBehaviour
{
    [SerializeField] bool isMoving = true;

    Animator m_animator;
    Transform player;
    AIDestinationSetter aiDestination;
    AIPath aiPath;

    void Awake () {
        MakeReferences();
    }

    void Update () {
        AnimateMovement();
    }

    void MakeReferences () {
        m_animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
        aiDestination = GetComponentInParent<AIDestinationSetter>();
        aiPath = GetComponentInParent<AIPath>();
    }

    void AnimateMovement () {
        m_animator.SetBool("isMoving", isMoving);

        if (aiDestination.target != transform.parent && !isMoving)
            isMoving = true;
        else if (aiDestination.target == transform.parent && isMoving)
            isMoving = false;

        var velocityX = aiPath.velocity.x;
        var velocityY = aiPath.velocity.y;
        if (isMoving) {
            if (velocityX > 0.1f && velocityX > Mathf.Abs(velocityY)) {
                m_animator.Play("MoveRight");
            }
            if (velocityY > 0.1f && velocityY > Mathf.Abs(velocityX)) {
                m_animator.Play("MoveUp");
            }
            if (velocityX < -0.1f && Mathf.Abs(velocityX) > Mathf.Abs(velocityY)) {
                m_animator.Play("MoveLeft");
            }
            if (velocityY < -0.1f && Mathf.Abs(velocityY) > Mathf.Abs(velocityX)) {
                m_animator.Play("MoveDown");
            }
        }
    }

    public void Damage () {
        m_animator.SetTrigger("Damage");
    }

    public void Die () {
        m_animator.SetTrigger("Die");
    }
}
