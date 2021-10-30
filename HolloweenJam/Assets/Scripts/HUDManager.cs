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
        for (int i = playerHearts.Count - 1; i > -1; i--) {
            if (playerHearts[i].activeSelf == true) {
                playerHearts[i].SetActive(false);
                return;
            }
        }
    }

    public void HealPlayer () {
        for (int i = playerHearts.Count - 1; i > -1; i--) {
            if (playerHearts[i].activeSelf == true) {
                playerHearts[i+1].SetActive(true);
                return;
            }
        }
    }

    public void DamageFollower () {
        for (int i = followerHearts.Count - 1; i > -1; i--) {
            if (followerHearts[i].activeSelf == true) {
                followerHearts[i].SetActive(false);
                return;
            }
        }
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
        for (int i = 0; i < PlayerStats.clipCapacity; i++) {
            bullets[i].SetActive(true);
        }
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
