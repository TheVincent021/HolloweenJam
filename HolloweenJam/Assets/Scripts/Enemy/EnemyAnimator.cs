using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    [SerializeField] float minDistanceToAnimate = 0.5f;
    Animator m_animator;
    AIPath aiPath;

    void Awake () {
        MakeReferences();
    }

    void Update () {
        AnimateMovement();
    }

    void MakeReferences () {
        m_animator = GetComponent<Animator>();
        aiPath = GetComponentInParent<AIPath>();
    }

    void AnimateMovement () {
        var velocityX = aiPath.velocity.x;
        var velocityY = aiPath.velocity.y;
        if (Vector3.Distance(GetComponentInParent<AIDestinationSetter>().target.position, transform.position) > minDistanceToAnimate) {
            if (velocityX > 0f && velocityX > Mathf.Abs(velocityY)) {
                m_animator.Play("MoveRight");
            }
            if (velocityY > 0f && velocityY > Mathf.Abs(velocityX)) {
                m_animator.Play("MoveUp");
            }
            if (velocityX < 0f && Mathf.Abs(velocityX) > Mathf.Abs(velocityY)) {
                m_animator.Play("MoveLeft");
            }
            if (velocityY < 0f && Mathf.Abs(velocityY) > Mathf.Abs(velocityX)) {
                m_animator.Play("MoveDown");
            }
        }
    }

    public void Damage () {
        m_animator.SetTrigger("Damage");
    }

    void OnDisable () {
        m_animator.SetTrigger("Died");
    }
}
