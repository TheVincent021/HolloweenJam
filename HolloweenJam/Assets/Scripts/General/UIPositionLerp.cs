using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UIPositionLerp : MonoBehaviour
{
    #region Fields
    [SerializeField] Vector3 targetPosition;
    [SerializeField] [Range(0f, 1f)] float smoothness = 0.5f;

    RectTransform m_transform;
    #endregion

    #region Callbacks
    void Awake () {
        m_transform = GetComponent<RectTransform>();
    }

   void Update () {
       m_transform.localPosition = Vector3.Lerp(m_transform.localPosition, targetPosition, 1 - smoothness);
   }
   #endregion

   public void SetTargetPosition (Vector3 position) {
       targetPosition = position;
   }
}
