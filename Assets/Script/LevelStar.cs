using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStar : MonoBehaviour
{
    public Image image;
    public List<Sprite> sprites;
    public void SetSprite(int timeRemain) {
        if (timeRemain > 0) {
            int star = timeRemain / 15;
            switch (star) {
                case 2:
                    image.sprite = sprites[0];
                    break;
                case 1:
                    image.sprite = sprites[1];
                    break;
                case 0:
                    image.sprite = sprites[2];
                    break;
            }
        } else {
            image.sprite = sprites[3];
        }
    }
}
