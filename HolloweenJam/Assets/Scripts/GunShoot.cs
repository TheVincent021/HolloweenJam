using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    [SerializeField] Transform barrelEnd;
    [SerializeField] GameObject bullet;
    [SerializeField] bool isReady = true;
    [SerializeField] float damage = 1f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] int clipCapacity = 8;
    [SerializeField] float reloadTime = 2f;

    int currentAmmo = 0;

    void Start () {
        Initialization();
    }

    void Initialization () {
        PlayerInput.actions.Default.Shoot.performed += Shoot;
        currentAmmo = clipCapacity;
    }

    void Shoot (InputAction.CallbackContext ctx) {
        if (isReady) {
            if (currentAmmo > 0) {
                currentAmmo--;
                Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
                StartCoroutine(Cooldown());
            } else {
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Cooldown () {
        isReady = false;
        yield return new WaitForSeconds(fireRate);
        isReady = true;
    }

    IEnumerator Reload () {
        isReady = false;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = clipCapacity;
        isReady = true;
    }
}
