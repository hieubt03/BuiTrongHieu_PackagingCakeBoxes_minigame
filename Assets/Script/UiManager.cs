using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    public GameObject victoryMenu;
    public GameObject defeatMenu;
    public Timer timer;
    public LevelStar star;
    public int levelId;
    void Start() {
        CloseAllUi();
    }

    private void CloseAllUi() {
        victoryMenu.SetActive(false);
        defeatMenu.SetActive(false);
    }

    public void GoToVictoryMenu() {
        victoryMenu.SetActive(true);
        timer.PauseTimer(true);
        star.SetSprite(Mathf.FloorToInt(timer.remainTime));
        float remainTimeData = PlayerPrefs.GetFloat("LevelID" + levelId + "TimeRemain", 0 );
        if (timer.remainTime > remainTimeData) {
            PlayerPrefs.SetFloat("LevelID" + levelId + "TimeRemain", timer.remainTime );
            PlayerPrefs.Save();
        }
    }

    public void GoToDefeatMenu() {
        defeatMenu.SetActive(true);
    }
    public void RestartLevel() {
        string activeScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeScene);
    }
}
