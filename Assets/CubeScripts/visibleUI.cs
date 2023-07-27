using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class visibleUI : MonoBehaviour
{
    public event Action onBlock;
    public event Action onBoard;

    void Block() {
        if (onBlock != null) {
            onBlock();
        }
    }

    void Board() {
        if (onBoard != null) {
            onBoard();
        }
    }

    void Update() {
        if (Input.GetKeyUp("b")) {
            onBlock();
        }
        if (Input.GetKeyUp("m")) {
            onBoard();
        }
    }
}
