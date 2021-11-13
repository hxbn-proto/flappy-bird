using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int velocity;
    [SerializeField] private float upperOffset;
    [SerializeField] private float bottomOffset;
    [SerializeField] private GameObject spawn;

    internal void Spawn() {
        Vector2 spawnerPosition = gameObject.transform.position;
        float offset = Random.Range(bottomOffset * -1, upperOffset);
        spawnerPosition.y += offset;

        GameObject pipeInstance = Instantiate(spawn, spawnerPosition, Quaternion.identity);
        pipeInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity * -1, 0);
    }
}
