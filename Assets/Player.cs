using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    internal void Reset()
    {
        Vector3 position = gameObject.transform.position;
        position.x = 0;
        position.y = 0;

        Debug.Log("Player Resetted!");

    }

    internal void Run()
    {
        gameObject.SetActive(true);

        Debug.Log("Player Runs!");
    }

    private void Update()
    {
        float velocity = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        int negative = 1;
        if (velocity < 0)
            negative = -1;

        /*Vector3 rotation = gameObject.transform.eulerAngles;
        rotation.z = (float)Math.Sqrt(Math.Abs(velocity)) * negative;*/

        gameObject.transform.eulerAngles = new Vector3(
            0,
            0,
            velocity * velocity * negative
        );

        if (Input.GetKeyDown(KeyCode.Space)) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
        }
    }
}
