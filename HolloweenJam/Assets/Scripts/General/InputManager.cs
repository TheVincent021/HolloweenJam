using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Fields
    public static PlayerActions actions;
    public static InputManager instance;
    #endregion

    #region Callbacks
    void OnEnable () {
        Initialization();
    }

    void Awake () {
        Singleton();
    }

    void Update () {
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    void Initialization () {
        actions = new PlayerActions();
        actions.Enable();
    }

    void Singleton () {
        if (InputManager.instance != null && InputManager.instance != this) {
            Destroy(this.gameObject);
        } else {
            InputManager.instance = this;
        }
    }
}
