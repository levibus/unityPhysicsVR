using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{

    public event Action onBallLaunch;
    public event Action onBallReset;
  
    void BallLaunch() {
        if (onBallLaunch != null) {
            onBallLaunch();
        }
    }

    void BallReset() {
        if (onBallReset != null) {
            onBallReset();
        }
    }

}
