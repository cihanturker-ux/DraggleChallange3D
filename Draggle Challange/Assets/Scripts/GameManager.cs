using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool hasGameStarted;
    public static bool hasGameOver;

    private void Awake()
    {
        Time.timeScale = 1;
        hasGameStarted = false;
        hasGameOver = false;
    }
}
