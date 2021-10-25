using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Fields
    public static PlayerActions actions;
    #endregion

    #region Callbacks
    void OnEnable () {
        Initialization();
    }
    #endregion

    void Initialization () {
        actions = new PlayerActions();
        actions.Enable();
    }
}
