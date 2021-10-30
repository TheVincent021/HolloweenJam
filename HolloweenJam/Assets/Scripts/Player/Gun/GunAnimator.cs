using UnityEngine;
using UnityEngine.InputSystem;

public class GunAnimator : MonoBehaviour
{
    #region Fields
    [SerializeField] Sprite horizontalArm;
    [SerializeField] Sprite verticalArm;
    [SerializeField] Transform barrelEnd;
    [SerializeField] Vector3[] barrelEndPositions;
    [SerializeField] PlayerAnimator playerAnimator;

    Transform m_transform;
    Animator m_animator;
    SpriteRenderer m_graphics;
    GunShoot m_gun;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Start () {
        Initialization();
    }

    void Update () {
        Animate();
        FixBarrelEndPosition();
        GunSortingFix();
    }
    #endregion

    void MakeReferences () {
        m_transform = transform;
        m_animator = GetComponent<Animator>();
        m_graphics = GetComponent<SpriteRenderer>();
        m_gun = GetComponent<GunShoot>();
    }

    void Initialization () {
        InputManager.actions.Default.Shoot.performed += TriggerShoot;
    }

    void Animate () {
        if (playerAnimator.lastMoveDirection == Direction.Right || playerAnimator.lastMoveDirection == Direction.Left) {
            m_animator.SetBool("Horizontal", true); m_animator.SetBool("Vertical", false);
        } else if (playerAnimator.lastMoveDirection == Direction.Up || playerAnimator.lastMoveDirection == Direction.Down) {
            m_animator.SetBool("Vertical", true); m_animator.SetBool("Horizontal", false);
        }

        m_animator.SetBool("Reload", m_gun.isReloading);

        m_graphics.flipY = playerAnimator.lastMoveDirection == Direction.Left ? true : false;
    }

    void FixBarrelEndPosition () {
        if (playerAnimator.lastMoveDirection == Direction.Up || playerAnimator.lastMoveDirection == Direction.Down) {
            barrelEnd.localPosition = barrelEndPositions[0];
        } else if (playerAnimator.lastMoveDirection == Direction.Left) {
            barrelEnd.localPosition = barrelEndPositions[1];
        } else if (playerAnimator.lastMoveDirection == Direction.Right) {
            barrelEnd.localPosition = barrelEndPositions[2];
        }
    }

    void TriggerShoot (InputAction.CallbackContext ctx) {
        if (m_gun.isReady)
            m_animator.SetTrigger("Shoot");
    }

    void GunSortingFix () {
        m_graphics.sortingOrder = playerAnimator.lastMoveDirection == Direction.Up ? -1 : 1;
    }

    void OnDisable () {
        InputManager.actions.Default.Shoot.performed -= TriggerShoot;
    }
}
