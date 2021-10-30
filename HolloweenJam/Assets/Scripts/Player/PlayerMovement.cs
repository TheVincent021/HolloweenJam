using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] float stepDelay = 0.3f;
    Vector2 movement;
    float nextStep = 0f;

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
        PlayFootsteps();
    }
    #endregion

    void MakeReferences () {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void GetInput () {
        movement = InputManager.actions.Default.Movement.ReadValue<Vector2>() * PlayerStats.speed;
    }

    void ApplyMovement () {
        m_rigidbody.velocity = movement;

    }

    void PlayFootsteps () {
        if (movement != Vector2.zero) {
            if (Time.time > nextStep) {
                SoundManager.instance.Play("Footsteps");
                nextStep = Time.time + stepDelay;
            }
        } else {
            nextStep = 0;
        }
    }
}
