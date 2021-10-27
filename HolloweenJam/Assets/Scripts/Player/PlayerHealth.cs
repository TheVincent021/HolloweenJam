using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] float recoveryTime = 1f;
    public bool isRecovering = false;

    public void Damage (int damage) {
        if (!isRecovering) {
            if (health > 1) {
                StartCoroutine(Recovery());
                health--;
            }
            else Die();
            GetComponentInChildren<PlayerAnimator>().Damage();
            Camera.main.GetComponent<CameraShake>().Shake(0.2f, 0.2f);
        }
    }

    IEnumerator Recovery () {
        isRecovering = true;
        yield return new WaitForSeconds(recoveryTime);
        isRecovering = false;
    }

    public void Die () {
        Destroy(this.gameObject);
    }
}
