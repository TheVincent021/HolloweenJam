using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject HUDPanel;
    [SerializeField] GameObject statsPanel;
    [SerializeField] TextMeshProUGUI savedPeopleNumber;
    [SerializeField] List<BuffScreen> buffScreens;
    [SerializeField] List<GameObject> playerHearts;
    [SerializeField] List<GameObject> followerHearts;
    [SerializeField] List<GameObject> bullets;

    public static UIManager instance;

    void Awake () {
        Singleton();
    }

    void Update () {
        DontDestroyOnLoad(this.gameObject);
    }

    void Singleton () {
        if (UIManager.instance != null && UIManager.instance != this)
            Destroy(this.gameObject);
        else
            UIManager.instance = this;
    }

    public void FadeOut () {
        GameObject.FindWithTag("FadePanel").GetComponent<Animator>().SetTrigger("FadeOut");
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

    public void DisableHUDPanel () {
        HUDPanel.SetActive(false);
    }

    public void EnableHUDPanel () {
        HUDPanel.SetActive(true);
    }

    public void EnableStatsPanel () {
        statsPanel.SetActive(true);
        savedPeopleNumber.text = PlayerStats.followerSaved.ToString();
    }

    public void DisableStatsPanel () {
        statsPanel.SetActive(false);
    }

    public void FillClip () {
        for (int i = 0; i < PlayerStats.clipCapacity; i++) {
            bullets[i].SetActive(true);
        }
    }

    public void ActivateRandomBuff () {
        DisableHUDPanel();
        InputManager.actions.Default.Disable();
        StartCoroutine(ActiveRandomBuffDelayed(4f));
    }

    IEnumerator ActiveRandomBuffDelayed (float delay) {
        yield return new WaitForSeconds(delay);
        int random = Random.Range(0, buffScreens.Count);
        buffScreens[random].Activate();
        buffScreens.RemoveAt(random);
    }
}
