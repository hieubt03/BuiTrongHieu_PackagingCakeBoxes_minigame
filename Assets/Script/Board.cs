using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Board : MonoBehaviour
{
    private UiManager uiManager;
    public List<GameObject> prefabs;
    public Vector2Int cakePosition;
    public Vector2Int boxPosition;
    private GameObject cake;
    private GameObject box;
    public List<Vector2Int> candyPosition;
    private List<GameObject> candies;

    private BoardGrid grid;
    private void Awake() {
        uiManager = FindObjectOfType<UiManager>();
        grid = GetComponentInChildren<BoardGrid>();
        candies = new List<GameObject>();
    }
    private void Start() {
        NewGame();
    }
    public void NewGame() {
        for (int i = 0; i < grid.cells.Length; i++) {
            grid.cells[i].gameObj = null;
        }
        cake = Instantiate(prefabs[0], grid.transform);
        cake.transform.position = grid.GetCell(cakePosition.x, cakePosition.y).transform.position;
        grid.GetCell(cakePosition.x, cakePosition.y).gameObj = prefabs[0];
        box = Instantiate(prefabs[1], grid.transform);
        box.transform.position = grid.GetCell(boxPosition.x, boxPosition.y).transform.position;
        grid.GetCell(boxPosition.x, boxPosition.y).gameObj = prefabs[1];
        for (int i = 0; i < candyPosition.Count; i++) {
            GameObject candy = Instantiate(prefabs[2], grid.transform);
            grid.GetCell(candyPosition[i].x, candyPosition[i].y).gameObj = candy;
            candies.Add(candy);
            candy.transform.position = grid.GetCell(candyPosition[i].x, candyPosition[i].y).transform.position;
        }
    }

    public void MoveRight() {
        Move(cakePosition.x, cakePosition.y, 1, 0);
        Move(boxPosition.x, boxPosition.y, 1, 0);
    }
    public void MoveLeft() {
        Move(cakePosition.x, cakePosition.y, -1, 0);
        Move(boxPosition.x, boxPosition.y, -1, 0);
    }
    public void MoveUp() {
        Move(cakePosition.x, cakePosition.y, 0, -1);
        Move(boxPosition.x, boxPosition.y, 0, -1);
    }
    public void MoveDown() {
        Move(cakePosition.x, cakePosition.y, 0, 1);
        Move(boxPosition.x, boxPosition.y, 0, 1);
        if (cakePosition.x == boxPosition.x && (boxPosition.y - cakePosition.y == 1)) {       
            cake.SetActive(false);
            uiManager.GoToVictoryMenu();
        }
    }
    private void Move(int x, int y, int xDirection, int yDirection) {
        BoardCell currentSell = grid.GetCell(x, y);
        if (currentSell.gameObj != null) {
            int newX = x + xDirection;
            int newY = y + yDirection;
            while (isCellValid(newX, newY)) {
                newX = newX + xDirection;
                newY = newY + yDirection;
            }
            newX = newX - xDirection;
            newY = newY - yDirection;
            grid.GetCell(newX, newY).gameObj = grid.GetCell(x, y).gameObj;
            if (grid.GetCell(x, y).gameObj.CompareTag("Cake")) {
                if (newX != x || newY != y) {
                    cake.transform.position = grid.GetCell(newX, newY).transform.position;
                    cakePosition.x = newX;
                    cakePosition.y = newY;
                    grid.GetCell(x, y).gameObj = null;
                }    
            } else if (grid.GetCell(x, y).gameObj.CompareTag("Box")) {
                if (newX != x || newY != y) {
                    box.transform.position = grid.GetCell(newX, newY).transform.position;
                    boxPosition.x = newX;
                    boxPosition.y = newY;
                    grid.GetCell(x, y).gameObj = null;
                }
            }
        }
    }

    private bool isCellValid(int x, int y) {
        if (x < 0 || x >= grid.width || y < 0 || y >= grid.height) return false;
        if (grid.GetCell(x, y).gameObj != null) return false;
        return true;
    }
}
