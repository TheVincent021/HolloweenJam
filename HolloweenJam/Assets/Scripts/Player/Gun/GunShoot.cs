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
        PlayerInput.actions.Default.Reload.performed += Reload;
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
                StartCoroutine(StartReload());
            }
        }
    }

    void ShootEffects() {
        Camera.main.GetComponent<CameraShake>().Shake(0.1f, 0.1f);
        Instantiate(muzzleFlash, barrelEnd.position, barrelEnd.rotation);
        SoundManager.instance.Play("GunShots");
    }

    void Reload (InputAction.CallbackContext ctx) {
        StartCoroutine(StartReload());
    }

    IEnumerator Cooldown () {
        isReady = false;
        yield return new WaitForSeconds(fireRate);
        isReady = true;
    }

    IEnumerator StartReload() {
        if (isReady == true && currentAmmo < clipCapacity) {
            isReady = false;
            isReloading = true;
            SoundManager.instance.Play("Reload");
            yield return new WaitForSeconds(reloadTime);
            currentAmmo = clipCapacity;
            isReady = true;
            isReloading = false;
        }
    }

    void OnDisable () {
        PlayerInput.actions.Default.Shoot.performed -= Shoot;
        PlayerInput.actions.Default.Reload.performed -= Reload;
    }
}
