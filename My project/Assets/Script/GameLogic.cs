using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLogic : MonoBehaviour
{
    public int score;
    public TMP_Text scoreUI;
    public TMP_Text messageUI; // New UI text for messages
    public AudioSource scoreAudio;
    public int maxScore = 5;

    private bool isGameOver = false;

    private void Start()
    {
        UpdateScoreUI();
        if (messageUI != null)
            messageUI.gameObject.SetActive(false); // Hide message at start
    }

    private void Update()
    {
        // Check for restart
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f; // Resume game
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            score++;
            UpdateScoreUI();

            if (scoreAudio != null)
                scoreAudio.Play();

            Destroy(other.gameObject);

            if (score >= maxScore)
                EndGame();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreUI != null)
            scoreUI.text = "Score: " + score;
    }

    private void EndGame()
    {
        isGameOver = true;

        // Pause the game
        Time.timeScale = 0f;

        // Show restart message
        if (messageUI != null)
        {
            messageUI.text = "You collected all waypoints!\nPress R to Restart";
            messageUI.gameObject.SetActive(true);
        }
    }
}
