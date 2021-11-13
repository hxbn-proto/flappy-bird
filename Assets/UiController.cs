using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text scoreObject;
    [SerializeField] private Text livesObject;
    [SerializeField] private GameObject messagePopUp;
    [SerializeField] private Text messageObject;

    private static string START_MESSAGE = "GO!";
    private static string GAMEOVER_MESSAGE = "Game Over";

    private void Start()
    {
        Reset();
    }

    internal void Reset()
    {
        messagePopUp.SetActive(false);
        scoreObject.text = "0";
        livesObject.text = "0";
        messageObject.text = "Sample message";
    }

    internal void UpdateScore(int newScore)
    {
        scoreObject.text = newScore.ToString();
    }

    internal void UpdateLives(int newLives)
    {
        livesObject.text = newLives.ToString();
    }

    internal void ShowGameOverMessage(params Action[] thenExecute)
    {
        StartCoroutine(ShowPopUpMessage(GAMEOVER_MESSAGE, thenExecute));
    }

    internal void ShowStartMessage(params Action[] thenExecute)
    {
        StartCoroutine(ShowPopUpMessage(START_MESSAGE, thenExecute));
    }

    private IEnumerator ShowPopUpMessage(string message, params Action[] callbacks) {
        yield return null;

        messagePopUp.SetActive(true);
        messageObject.text = message;

        yield return new WaitForSeconds(2);

        messagePopUp.SetActive(false);

        yield return new WaitForSeconds(0.5f);

        foreach (Action callback in callbacks) {
            callback.Invoke();
        }
    }
}
