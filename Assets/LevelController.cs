using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    internal void Reset()
    {
        Debug.Log("Level Resetted!");
    }

    internal void Run()
    {
        Debug.Log("Level Runs!");
    }

    internal void Stop()
    {
        Debug.Log("Level Stopped!");
    }
}
