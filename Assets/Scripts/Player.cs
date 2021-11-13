using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameController game;

    internal void Reset()
    {
        gameObject.transform.position = new Vector2(-1.16f, 0);

        Debug.Log("Player Resetted!");
        Enable(false);
    }

    internal void Run()
    {
        gameObject.SetActive(true);
        Enable(true);

        Debug.Log("Player Runs!");
    }

    private void Enable(bool isEnabled)
    {
        Rigidbody2D physix = gameObject.GetComponent<Rigidbody2D>();
        if (!isEnabled)
        {
            physix.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else {
            physix.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    private void Update()
    {
        float velocity = gameObject.GetComponent<Rigidbody2D>().velocity.y;

        int negative = 1;
        if (velocity < 0)
        {
            negative = -1;
        }

        float zAngle = Math.Min(35, velocity * velocity) * negative;
        gameObject.transform.eulerAngles = new Vector3(
            0,
            0,
            zAngle
        );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("success")) {
            game.PlayerPassed();
        } else if (collision.CompareTag("failure")) {
            game.PlayerFailed();
        }
    }
}
