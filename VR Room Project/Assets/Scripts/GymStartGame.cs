using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymStartGame : MonoBehaviour
{
    public static bool play = false;
    [SerializeField] float duration = 30f;
    [SerializeField] float currentTimer = 30f;
    [SerializeField] GameObject canvas;

    public int score = 0;

    public TMPro.TextMeshProUGUI startButton;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI scoreText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            canvas.SetActive(true);
            currentTimer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Round(currentTimer);
            scoreText.text = "Score: " + GymScoreManager.Instance.score;

            if (currentTimer <= 0f)
            {
                canvas.SetActive(false);
                play = false;
                currentTimer = duration;
                startButton.text = "Start";
                timerText.text = "TimeUp";
                scoreText.text = "Your Score: " + GymScoreManager.Instance.score;
            }
        }
    }

    public void StartGame()
    {
        if (play == true)
        {
            currentTimer = duration;
            startButton.text = "Restart";
            GymScoreManager.Instance.score = 0;

        }
        
        else 
        {
            play = true;
            startButton.text = "Restart";
            GymScoreManager.Instance.score = 0;
        }

    }

    // Tag for Box = "Present" not Box
    // Tag for stick = "Stick"
}
