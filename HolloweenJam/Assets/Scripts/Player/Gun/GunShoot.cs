using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    public bool isReady = true;
    public bool isReloading = false;
    [SerializeField] Transform barrelEnd;
    [SerializeField] GameObject normalBullet;
    [SerializeField] GameObject spreadBullet;
    [SerializeField] GameObject muzzleFlash;
    [SerializeField] float damage = 1f;
    [SerializeField] float fireRate = 0f;
    [SerializeField] int clipCapacity = 8;
    [SerializeField] float reloadTime = 2f;
    [SerializeField] RoundRobin shotEffects;

    public int currentAmmo = 0;
    GameObject bullet;

    void Start () {
        Initialization();
    }

    void Initialization () {
        InputManager.actions.Default.Shoot.performed += Shoot;
        InputManager.actions.Default.Reload.performed += Reload;

        clipCapacity = PlayerStats.clipCapacity;
        currentAmmo = clipCapacity;
        if (PlayerStats.spreadBullet) bullet = spreadBullet; else bullet = normalBullet;

        UIManager.instance.FillClip();
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
        UIManager.instance.PopBullet();
    }

    public void ReloadCall () {
        StartCoroutine(StartReload());
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
        if (isReady == true && currentAmmo < PlayerStats.clipCapacity) {
            isReady = false;
            isReloading = true;
            SoundManager.instance.Play("Reload");
            yield return new WaitForSeconds(reloadTime);
            UIManager.instance.FillClip();
            clipCapacity = PlayerStats.clipCapacity;
            currentAmmo = clipCapacity;
            isReady = true;
            isReloading = false;
        }
    }

    public void ChangeBullet () {
        bullet = spreadBullet;
    }

    void OnDisable () {
        InputManager.actions.Default.Shoot.performed -= Shoot;
        InputManager.actions.Default.Reload.performed -= Reload;
    }
}
