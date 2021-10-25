using UnityEngine;

public enum Direction {
    Up, Down, Right, Left
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] Direction lastMoveDirection;
    Vector2 movement;

    Animator m_animator;
    SpriteRenderer m_graphics;

    void Awake () {
        MakeReferences();
    }

    void Update () {
        GetInput();
        AnimateMovement();
        GunPositionFix();
    }

    void MakeReferences () {
        m_animator = GetComponent<Animator>();
        m_graphics = GetComponent<SpriteRenderer>();
    }

    void GetInput () {
        movement = PlayerInput.actions.Default.Movement.ReadValue<Vector2>();
    }

    void AnimateMovement () {
        m_animator.SetBool("MoveRight", movement.x > 0f);
        m_animator.SetBool("MoveLeft", movement.x < 0f);
        m_animator.SetBool("MoveUp", movement.y > 0f);
        m_animator.SetBool("MoveDown", movement.y < 0f);
    }

    void GunPositionFix () {
        m_graphics.sortingOrder = movement.y > 0f ? 2 : 0;
    }
}
