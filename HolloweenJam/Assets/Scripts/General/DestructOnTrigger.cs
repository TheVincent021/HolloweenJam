using UnityEngine;

public class DestructOnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col) {
        Debug.Log("HEY");
        Destroy(this.gameObject);
    }
}
