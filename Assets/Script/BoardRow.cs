using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardRow : MonoBehaviour
{
   public BoardCell[] cells;
   private void Awake() {
       cells = GetComponentsInChildren<BoardCell>();
   }
}
