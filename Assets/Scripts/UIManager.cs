using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Text gameOverText;
    [SerializeField] private AudioSource GameMusic;
    
    void Start()
    {
        GameMusic = SoundManager.Instance.GetAudioSource(SoundManager.Sound.GameMusic);
        GameMusic.loop = true;
        GameMusic.Play();
    }    

    public void UpdatePoints(int currentPoints)
    {
        pointsText.text = "Points: " + currentPoints;
    }

    public void PauseGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.UiSelect);
        GameMusic.volume = 0.2f;

        PauseMenuPanel.SetActive(true);
        GameManager.Instance.PauseGame();
    }

    public void ResumeGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.UiSelect);
        GameMusic.volume = 1f;

        PauseMenuPanel.SetActive(false);
        GameManager.Instance.ResumeGame();
    }

    public void RestartGame()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.UiSelect);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void BackToMenu()
    {
        SoundManager.Instance.PlaySound(SoundManager.Sound.UiSelect);
        SceneManager.LoadScene("Menu");
    }

    public void GameOver(int totalPoints)
    {
        GameOverPanel.SetActive(true);
        gameOverText.text = string.Format($"GAME OVER\n\nYOU GAINED {totalPoints} POINTS");
        GameManager.Instance.PauseGame();
    }
}
