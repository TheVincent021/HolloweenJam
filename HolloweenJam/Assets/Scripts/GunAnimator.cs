using UnityEngine;

public class GunAnimator : MonoBehaviour
{
    #region Fields
    [SerializeField] Sprite[] armDirections;

    Transform m_transform;
    SpriteRenderer m_graphics;
    #endregion

    #region Callbacks
    void Awake () {
        MakeReferences();
    }

    void Update () {
        Animate();
    }
    #endregion

    void MakeReferences () {
        m_transform = transform;
        m_graphics = GetComponent<SpriteRenderer>();
    }

    void Animate () {
        Debug.Log(m_transform.localEulerAngles);
        if (m_transform.localEulerAngles.z < 45f || m_transform.localEulerAngles.z > 315f) {
            m_graphics.sprite = armDirections[0];
        } else if (m_transform.localEulerAngles.z < 135f && m_transform.localEulerAngles.z > 45f) {
            m_graphics.sprite = armDirections[1];
        } else if (m_transform.localEulerAngles.z < 225f && m_transform.localEulerAngles.z > 135f) {
            m_graphics.sprite = armDirections[2];
        } else if (m_transform.localEulerAngles.z < 315f && m_transform.localEulerAngles.z > 225f) {
            m_graphics.sprite = armDirections[3];
        }
    }
}
