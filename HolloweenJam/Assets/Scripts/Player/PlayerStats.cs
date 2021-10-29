using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static int health = 3;
    public static int damage = 1;
    public static int clipCapacity = 6;
    public static float speed = 3f;
    public static float bulletForce = 300f;
    public static bool spreadBullet = false;

    void Update () {
        DontDestroyOnLoad(this.gameObject);
    }

    public void HealthBuff () {
        health += 1;
        GameObject.FindObjectOfType<PlayerHealth>().Heal(1);
    }

    public void DamageBuff () {
        Debug.Log("Damage Buffed!");
        damage += 1;
        Debug.Log("Current damage: " + damage);
    }

    public void ClipCapacityBuff () {
        clipCapacity += 3;
    }

    public void ShotgunBulletBuff () {
        spreadBullet = true;
        GameObject.FindObjectOfType<GunShoot>().ChangeBullet();
    }

    public void SpeedBuff () {
        speed += 1f;
    }

    public void BulletForceBuff () {
        bulletForce += 250f;
    }
}
