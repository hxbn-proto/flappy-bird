using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LevelController level;
    [SerializeField] private UiController ui;
    [SerializeField] private Player player;

    [SerializeField] private int lives = 3;
    [SerializeField] private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Reset();

        UpdateUiValues();

        ui.ShowStartMessage(
            level.Run,
            player.Run);
    }

    public void PlayerPassed()
    {
        ui.UpdateScore(++score);
    }

    public void PlayerFailed()
    {
        level.Stop();
        if (--lives == 0)
        {
            GameOver();
        }
        else
        {
            player.Reset();
            player.Run();
        }
    }

    private void GameOver()
    {
        ui.ShowGameOverMessage(Reset);
    }

    private void Reset()
    {
        level.Reset();
        player.Reset();
        ui.Reset();
    }

    private void UpdateUiValues() {
        ui.UpdateLives(lives);
        ui.UpdateScore(score);
    }
}
