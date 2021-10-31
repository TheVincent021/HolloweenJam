using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
    [SerializeField] bool canExit = false;

    public void OnTriggerEnter2D (Collider2D col) {
        if (col.CompareTag("Player")) {
            canExit = true;
            InputManager.actions.Default.Interact.performed += GoToNextLevel;
        }
    }

    public void OnTriggerExit2D (Collider2D col) {
        if (col.CompareTag("Player")) {
            canExit = false;
            InputManager.actions.Default.Interact.performed -= GoToNextLevel;
            
        }

    }

    public void GoToNextLevel (InputAction.CallbackContext ctx) {
        InputManager.actions.Default.Interact.performed -= GoToNextLevel;
        PlayerStats.currentLevel += 1;
        if (GameObject.FindObjectOfType<FollowerHealth>() != null) PlayerStats.followerSaved += 1;

        InputManager.actions.Default.Disable();
        UIManager.instance.DisableHUDPanel();

        StartCoroutine(LoadLevelsNexus());
        GameObject.FindObjectOfType<MusicManager>().StopMusic();
    }

    IEnumerator LoadLevelsNexus () {
        UIManager.instance.FadeOut();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("StatsScene");
    }
}
