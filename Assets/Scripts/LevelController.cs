using System;
using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Spawner pipeSpawner;
    [SerializeField] private Spawner cloudSpawner;
    [SerializeField] private int cloudSpawningTimeoutMin;
    [SerializeField] private int cloudSpawningTimeoutMax;
    [SerializeField] private float tubeSpawningTimeout;
    internal Coroutine pipeSpawnerCoroutine;

    internal void Reset()
    {
        Debug.Log("Level Resetted!");
    }

    internal void Run()
    {
        Debug.Log("Level Runs!");
        pipeSpawnerCoroutine = StartCoroutine(SpawnPipes());
        StartCoroutine(SpawnClouds());
    }

    private IEnumerator SpawnPipes()
    {
        while (true)
        {
            yield return new WaitForSeconds(tubeSpawningTimeout);
            pipeSpawner.Spawn();
        }
    }

    private IEnumerator SpawnClouds()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(cloudSpawningTimeoutMin, cloudSpawningTimeoutMax));
            cloudSpawner.Spawn();
        }
    }

    internal void Stop()
    {
        Debug.Log("Level Stopped!");
        if (pipeSpawnerCoroutine != null)
        {
            StopAllCoroutines();
        }
    }
}
