using UnityEngine;
using UnityEngine.InputSystem;

public class Altar : MonoBehaviour
{
    #region Fields
    [SerializeField] bool interactable = false;
    [SerializeField] FollowerEventHandler victim;
    #endregion

    #region Callbacks
    void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Follower")) {
            interactable = true;
            InputManager.actions.Default.Interact.performed += Sacrifice;
        }
    }

    void OnTriggerExit2D (Collider2D col) {
        if (col.CompareTag("Follower")) {
            interactable = false;
            InputManager.actions.Default.Interact.performed -= Sacrifice;
        }
    }
    #endregion

    void Sacrifice (InputAction.CallbackContext ctx) {
        if (victim) {
            victim.Die(true);
            UIManager.instance.ActivateRandomBuff();
        } else
            Debug.Log("No victim to sacrifice!");
    }
}
