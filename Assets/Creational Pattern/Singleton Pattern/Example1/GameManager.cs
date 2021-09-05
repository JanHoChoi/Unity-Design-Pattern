using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Awake() {
        base.Awake();
        if (_instance)
            Debug.Log("GameManager Initialized");
    }
}
