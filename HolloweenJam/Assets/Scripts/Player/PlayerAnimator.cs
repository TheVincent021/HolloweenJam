using UnityEngine.InputSystem;
using UnityEngine;

public enum Direction {
    Up, Down, Right, Left
}

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimator : MonoBehaviour
{
    #region Fields
    public Direction lastMoveDirection;

    Vector2 movement;
    Vector2 mousePos;
    bool isMovingRight = false;
    bool isMovingLeft = false;
    bool isMovingUp = false;
    bool isMovingDown = false;

    Animator m_animator;
    SpriteRenderer m_graphics;
    Transform m_transform;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Update () {
        GetInput();
        GunPositionFix();
        Animate();
    }
    #endregion

    void MakeReferences () {
        m_animator = GetComponent<Animator>();
        m_graphics = GetComponent<SpriteRenderer>();
        m_transform = transform;
    }

    void GetInput () {
        movement = PlayerInput.actions.Default.Movement.ReadValue<Vector2>();
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    void Animate () {
        if (movement != Vector2.zero) {
            if (movement.x > 0f && !isMovingUp && !isMovingDown) {
                isMovingRight = true;
                if (mousePos.x < m_transform.parent.position.x) {
                    m_animator.Play("BackwardsRight");
                    lastMoveDirection = Direction.Left;
                } else {
                    m_animator.Play("MoveRight");
                    lastMoveDirection = Direction.Right;
                }
            } else if (movement.x <= 0f) isMovingRight = false;
            if (movement.x < 0f && !isMovingUp && !isMovingDown) {
                isMovingLeft = true;
                if (mousePos.x > m_transform.position.x) {
                    m_animator.Play("BackwardsLeft");
                    lastMoveDirection = Direction.Right;
                } else {
                    m_animator.Play("MoveLeft");
                    lastMoveDirection = Direction.Left;
                }
            } else if (movement.x >= 0f) isMovingLeft = false;
            if (movement.y > 0f && !isMovingRight && !isMovingLeft) {
                isMovingUp = true;
                if (mousePos.y < m_transform.position.y) {
                    m_animator.Play("BackwardsUp");
                    lastMoveDirection = Direction.Down;
                } else {
                    m_animator.Play("MoveUp");
                    lastMoveDirection = Direction.Up;
                }
            } else if (movement.y <= 0f) isMovingUp = false;
            if (movement.y < 0f && !isMovingRight && !isMovingLeft) {
                isMovingDown = true;
                if (mousePos.y > m_transform.position.y) {
                    m_animator.Play("BackwardsDown");
                    lastMoveDirection = Direction.Up;
                } else {
                    m_animator.Play("MoveDown");
                    lastMoveDirection = Direction.Down;
                }
            } else if (movement.y >= 0f) isMovingDown = false;
        } else {
            var difference = ((Vector3)mousePos - transform.position).normalized;
            if (difference.x > 0.5f && difference.y < 0.5f && difference.y > -0.5f) {
                m_animator.Play("RightIdle");
                lastMoveDirection = Direction.Right;
            } else if (difference.y > 0.5f && difference.x < 0.5f && difference.x > -0.5f) {
                m_animator.Play("UpIdle");
                lastMoveDirection = Direction.Up;
            } else if (difference.x < -0.5f && difference.y < 0.5f && difference.y > -0.5f) {
                m_animator.Play("LeftIdle");
                lastMoveDirection = Direction.Left;
            } else if (difference.y < -0.5f && difference.x < 0.5f && difference.x > -0.5f) {
                m_animator.Play("DownIdle");
                lastMoveDirection = Direction.Down;
            } else {
                if (lastMoveDirection == Direction.Up) m_animator.Play("UpIdle");
                else if (lastMoveDirection == Direction.Down) m_animator.Play("DownIdle");
                else if (lastMoveDirection == Direction.Right) m_animator.Play("RightIdle");
                else if (lastMoveDirection == Direction.Left) m_animator.Play("LeftIdle");
            }
        }
    }

    void GunPositionFix () {
        m_graphics.sortingOrder = lastMoveDirection == Direction.Up ? 2 : 0;
    }
}
