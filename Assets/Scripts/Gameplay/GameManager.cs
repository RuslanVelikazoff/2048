using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;

    public Text currentScoreText;
    public Text highScoreText;

    public Button soundButton;
    public Sprite onSoundSprite;
    public Sprite offSoundSprite;

    private int score;

    private void Start() 
    {
        SetMusicSprite();

        NewGame();
    }

    public void NewGame()
    {
        SetScore(0);
        gameOver.alpha = 0f;
        gameOver.interactable = false;

        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    private void SetScore(int score)
    {
        this.score = score;
        currentScoreText.text = score.ToString();

        SaveHighScore();

        highScoreText.text = "Best: " + LoadHighScore().ToString();
    }

    private void SaveHighScore()
    {
        int highScore = LoadHighScore();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    private int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    private void SetMusicSprite()
    {
        if (PlayerPrefs.GetFloat("Volume") == 0)
        {
            soundButton.GetComponent<Image>().sprite = offSoundSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = onSoundSprite;
        }
    }

    public void SetMusicVolume()
    {
        if (PlayerPrefs.GetFloat("Volume") == 0)
        {
            AudioManager.instance.OnMusic();
            SetMusicSprite();
        }
        else
        {
            AudioManager.instance.OffMusic();
            SetMusicSprite();
        }

    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = .5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
