using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public bool isReady = true;
    public bool isReloading = false;
    [SerializeField] Transform barrelEnd;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] float damage = 1f;
    [SerializeField] float fireRate = 0f;
    [SerializeField] int clipCapacity = 8;
    [SerializeField] float reloadTime = 2f;
    [SerializeField] RoundRobin shotEffects;

    public int currentAmmo = 0;

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
                ShootEffects();
                currentAmmo--;
                Instantiate(bullet, barrelEnd.position, barrelEnd.rotation);
                StartCoroutine(Cooldown());
            } else {
                StartCoroutine(Reload());
            }
        }
    }

    void ShootEffects() {
        Camera.main.GetComponent<CameraShake>().Shake(0.1f, 0.1f);
        Instantiate(muzzleFlash, barrelEnd.position, muzzleFlash.transform.rotation);
        SoundManager.instance.Play("GunShots");
    }

    IEnumerator Cooldown () {
        isReady = false;
        yield return new WaitForSeconds(fireRate);
        isReady = true;
    }

    IEnumerator Reload () {
        isReady = false;
        isReloading = true;
        SoundManager.instance.Play("Reload");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = clipCapacity;
        isReady = true;
        isReloading = false;
    }
}
