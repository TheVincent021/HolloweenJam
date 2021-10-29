using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] GameObject defaultPanel;
    [SerializeField] List<BuffScreen> buffScreens;
    [SerializeField] List<GameObject> playerHearts;
    [SerializeField] List<GameObject> followerHearts;
    [SerializeField] List<GameObject> bullets;

    public static HUDManager instance;

    void Awake () {
        Singleton();
    }

    void Singleton () {
        if (HUDManager.instance != null && HUDManager.instance != this)
            Destroy(this.gameObject);
        else
            HUDManager.instance = this;
    }

    public void DamagePlayer () {
        Destroy(playerHearts[playerHearts.Count - 1]);
        playerHearts.RemoveAt(playerHearts.Count - 1);
    }

    public void DamageFollower () {
        Destroy(followerHearts[followerHearts.Count - 1]);
        followerHearts.RemoveAt(followerHearts.Count - 1);
    }

    public void RemoveAllFollowerHearts () {
        foreach (var heart in followerHearts)
            Destroy(heart);
    }

    public void PopBullet () {
        for (int i = bullets.Count - 1; i > -1; i--) {
            if (bullets[i].activeSelf == true) {
                bullets[i].SetActive(false);
                return;
            }
        }
    }

    public void DisableDefaultPanel () {
        defaultPanel.SetActive(false);
    }

    public void EnableDefaultPanel () {
        defaultPanel.SetActive(true);
    }

    public void FillClip () {
        foreach (var bullet in bullets)
            bullet.SetActive(true);
    }

    public void ActivateRandomBuff () {
        DisableDefaultPanel();
        PlayerInput.actions.Default.Disable();
        StartCoroutine(ActiveRandomBuffDelayed(4f));
    }

    IEnumerator ActiveRandomBuffDelayed (float delay) {
        yield return new WaitForSeconds(delay);
        int random = Random.Range(0, buffScreens.Count);
        buffScreens[random].Activate();
    }
}
