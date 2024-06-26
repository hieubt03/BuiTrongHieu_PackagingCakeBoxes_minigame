using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remainTime;
    public bool isTimePaused = false;
    private UiManager uiManager;
    private void Awake() {
        uiManager = FindObjectOfType<UiManager>();
    }
    void Update()
    {   
        if (!isTimePaused) {
            if (remainTime > 0) {
                remainTime -= Time.deltaTime;
            } else {
                remainTime = 0;
                uiManager.GoToDefeatMenu();
                PauseTimer(true);
            }
        } 
        int minutes = Mathf.FloorToInt(remainTime / 60);
        int seconds = Mathf.FloorToInt(remainTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void PauseTimer(bool pause) {
        isTimePaused = pause;
    }
}
