using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGrid : MonoBehaviour
{
    public BoardRow[] rows;
    public BoardCell[] cells;
    public int size => cells.Length;
    public int height => rows.Length;
    public int width => size / height;
    private void Awake() {
        rows = GetComponentsInChildren<BoardRow>();
        cells = GetComponentsInChildren<BoardCell>();
    }
    public BoardCell GetCell(int x, int y)
    {
        if (x >= 0 && x < width && y >= 0 && y < height) {
            return rows[y].cells[x];
        } else {
            return null;
        }
    }
}
