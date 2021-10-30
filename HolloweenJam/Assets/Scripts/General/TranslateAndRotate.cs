using UnityEngine;

public class TranslateAndRotate : MonoBehaviour {

    #region Fields
    [SerializeField] Vector3 translate;
    [SerializeField] Vector3 rotate;
    #endregion

    #region Callbacks
    void FixedUpdate () {
        PositionUpdate();
        RotationUpdate();
    }
    #endregion

    void PositionUpdate () {
        transform.Translate(translate);
    }

    void RotationUpdate () {
        transform.Rotate(rotate);
    }

}
