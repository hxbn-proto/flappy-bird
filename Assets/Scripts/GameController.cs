using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelController level;
    [SerializeField] private UiController ui;
    [SerializeField] private Player player;

    private int lives = 3;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void PlayerPassed()
    {
        ui.UpdateScore(++score);
    }

    public void PlayerFailed()
    {
        if (--lives == 0)
        {
            GameOver();
        }
        else
        {
            player.Reset();
            player.Run();
        }
        UpdateUiValues();
    }

    private void GameOver()
    {
        player.gameObject.SetActive(false);
        ui.ShowGameOverMessage(Reset);
    }

    private void Reset()
    {
        level.Stop();
        level.Reset();
        player.Reset();
        ui.Reset();

        lives = 3;
        score = 0;

        UpdateUiValues();

        ui.ShowStartMessage(
            level.Run,
            player.Run);
    }

    private void UpdateUiValues() {
        ui.UpdateLives(lives);
        ui.UpdateScore(score);
    }
}
