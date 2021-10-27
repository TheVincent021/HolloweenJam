using UnityEngine;
using UnityEngine.InputSystem;

public class GunRotation : MonoBehaviour
{
    #region Fields
    [SerializeField] [Range(0f, 180f)] float offset = 90f;

    Vector3 difference;

    Transform m_transform;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Update()
    {
        GetDifference();
        ApplyRotation();
    }
    #endregion

    void MakeReferences () {
        m_transform = transform;
    }

    void GetDifference () {
        difference = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - m_transform.position;
        difference.Normalize();
    }

    void ApplyRotation () {
        float rotZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        m_transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + offset);
    }
}
