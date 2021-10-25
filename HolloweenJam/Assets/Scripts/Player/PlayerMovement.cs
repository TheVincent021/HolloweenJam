using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] float speed = 5f;
    Vector2 movement;

    Rigidbody2D m_rigidbody;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Update()
    {
        GetInput();
        ApplyMovement();
    }
    #endregion

    void MakeReferences () {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void GetInput () {
        movement = PlayerInput.actions.Default.Movement.ReadValue<Vector2>() * speed;
    }

    void ApplyMovement () {
        m_rigidbody.velocity = movement;
    }
}
