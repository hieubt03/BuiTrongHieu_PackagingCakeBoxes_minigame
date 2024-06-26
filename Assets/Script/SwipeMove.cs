using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour
{
    private Vector2 startTouchPosition, endTouchPosition;
    private float swipeHold = 25f;
    private Touch touch;
    private Board board;
    void Start() {
        board = FindObjectOfType<Board>();
    }

    void Update()
    {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);
        }
        if (touch.phase ==  TouchPhase.Began) {
            startTouchPosition = touch.position;
        }
        if (Input.touchCount > 0 && touch.phase == TouchPhase.Ended) {
            endTouchPosition = touch.position;
            DetectSwipeDirection();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
            board.MoveUp();
            
        } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            board.MoveLeft();
         
        } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
            board.MoveDown();
          
        } else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            board.MoveRight();
        }
    }
    private void DetectSwipeDirection() {
        float xDistance = endTouchPosition.x - startTouchPosition.x;
        float yDistance = endTouchPosition.y - startTouchPosition.y;

        if (Mathf.Abs(xDistance) > swipeHold || Mathf.Abs(yDistance) > swipeHold) {
            if (Mathf.Abs(xDistance) > Mathf.Abs(yDistance)) {
                if (xDistance > 0) {
                    board.MoveRight();
                } else {
                    board.MoveLeft();
                }
            } else {
                if (yDistance > 0) {
                    board.MoveUp();
                } else {
                    board.MoveDown();
                }
            }
        }
    }
}
