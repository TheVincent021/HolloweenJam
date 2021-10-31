using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int currentLevel = 1;
    public static int followerSaved = 0;
    public static int health = 3;
    public static int damage = 1;
    public static int clipCapacity = 6;
    public static float speed = 3f;
    public static float bulletForce = 750f;
    public static bool spreadBullet = false;
    public static int sacrificedCount;

    public void HealthBuff () {
        health += 1;
        GameObject.FindObjectOfType<PlayerHealth>().Heal(1);
        UIManager.instance.HealPlayer();

        if (GameObject.FindObjectOfType<FollowerHealth>() != null) {
            GameObject.FindObjectOfType<FollowerHealth>().Heal(1);
            UIManager.instance.HealFollower();
        }
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
        speed += 0.6f;
        Debug.Log("Current speed: " + speed);
    }

    public void BulletForceBuff () {
        bulletForce += 750f;
    }
}
