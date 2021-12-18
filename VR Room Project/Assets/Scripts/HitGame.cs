using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HitGame: MonoBehaviour
{
    [SerializeField] bool play = false;
    [SerializeField] float duration = 15f;
    [SerializeField] float currentTimer = 15f;
    [SerializeField] GameObject[] sockets;
    [SerializeField] GameObject[] boxes;

    public int score = 0;

    public TMPro.TextMeshProUGUI startButton;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject gameover;

    private XRSocketInteractor xRSocketInteractor;
    private RestartObject restartObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (play)
        {
            currentTimer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Round(currentTimer);
            scoreText.text = "Score: " + score;
        }
        if (currentTimer <= 0f)
        {
            play = false;
            currentTimer = duration;
            startButton.text = "Start";
            timerText.text = "";
            scoreText.text = "";
            gameover.SetActive(true);
        }
    }

    public void StartGame()
    {
        if (play == true)
        {
            currentTimer = duration;
            startButton.text = "Restart";
            StartCoroutine(Restart());
        }
        else 
        {
            play = true;
            startButton.text = "Restart";
            StartCoroutine(Restart());
        }
    }

    public void AddScore()
    {
        score++;
    }

    public void MinusScore()
    {
        score--;
    }

    // Tag for Box = "Present" not Box
    // Tag for stick = "Stick"
    IEnumerator Restart()
    {

        for (int i = 0; i < sockets.Length; i++)
        {
            xRSocketInteractor = sockets[i].GetComponentInChildren<XRSocketInteractor>();
            xRSocketInteractor.socketActive = false;
        }
        for (int i = 0; i < boxes.Length; i++)
        {
            restartObject = boxes[i].GetComponent<RestartObject>();
            restartObject.toStart();
        }
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < sockets.Length; i++)
        {
            xRSocketInteractor = sockets[i].GetComponentInChildren<XRSocketInteractor>();
            xRSocketInteractor.socketActive = true;
        }
    }

}

