using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*
* Author: Levi Busching
* Description: Signals when the UI buttons and pushed to turn the block and board visibility on/off.
*/

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

    void Update() {                    // can also use keybindings while in the Unity play mode
        if (Input.GetKeyUp("b")) {
            onBlock();
        }
        if (Input.GetKeyUp("m")) {
            onBoard();
        }
    }
}
