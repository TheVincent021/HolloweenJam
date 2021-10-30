using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int health = 3;
    public static int damage = 1;
    public static int clipCapacity = 6;
    public static float speed = 3f;
    public static float bulletForce = 500f;
    public static bool spreadBullet = false;

    void Update () {
        DontDestroyOnLoad(this.gameObject);
    }

    public void HealthBuff () {
        health += 1;
        GameObject.FindObjectOfType<PlayerHealth>().Heal(1);
        HUDManager.instance.HealPlayer();
    }

    public void DamageBuff () {
        Debug.Log("Damage Buffed!");
        damage += 1;
        Debug.Log("Current damage: " + damage);
    }

    public void ClipCapacityBuff () {
        clipCapacity += 3;
        GameObject.FindObjectOfType<GunShoot>().ReloadCall();
    }

    public void ShotgunBulletBuff () {
        spreadBullet = true;
        GameObject.FindObjectOfType<GunShoot>().ChangeBullet();
    }

    public void SpeedBuff () {
        Debug.Log("Speed Buffed!");
        speed += 1f;
        Debug.Log("Current speed: " + speed);
    }

    public void BulletForceBuff () {
        bulletForce += 400f;
    }
}
