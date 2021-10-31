using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelsNexus : MonoBehaviour
{
    void Start () {
        Initialization();
    }

    void Initialization () {
        if (PlayerStats.currentLevel != 5) {
            UIManager.instance.EnableStatsPanel();
            InputManager.actions.InBetweenMenu.Enable();
            InputManager.actions.InBetweenMenu.Submit.performed += GoToNextLevel;
        } else {
            UIManager.instance.EnableGameOverPanel();
        }
    }

    void GoToNextLevel (InputAction.CallbackContext ctx) {
        InputManager.actions.InBetweenMenu.Disable();
        StartCoroutine(LoadNextLevel());
    }

    IEnumerator LoadNextLevel () {
        InputManager.actions.InBetweenMenu.Submit.performed -= GoToNextLevel;
        UIManager.instance.FadeOut();
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.DisableStatsPanel();
        UIManager.instance.EnableHUDPanel();
        InputManager.actions.Default.Enable();
        SceneManager.LoadScene(PlayerStats.currentLevel);
    }
}
