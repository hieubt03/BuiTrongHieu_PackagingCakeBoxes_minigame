using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    private LevelStar[] levelStarData;
    private void Awake() {
       levelStarData = GetComponentsInChildren<LevelStar>();
    }
    private void Start() {
        for (int i = 0; i< levelStarData.Length; i++) {
            float remainTimeData = PlayerPrefs.GetFloat("LevelID" + i + "TimeRemain", 0 );
            Debug.Log(remainTimeData);
            levelStarData[i].SetSprite(Mathf.FloorToInt(remainTimeData));
        }
    }
}
