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

    [SerializeField] AudioSource correct;
    [SerializeField] AudioSource wrong;

    public TMPro.TextMeshProUGUI startButton;
    public TMPro.TextMeshProUGUI timerText;
    public TMPro.TextMeshProUGUI scoreText;
    public GameObject gameover;

    private XRSocketInteractor xRSocketInteractor;
    private RestartObject restartObject;

    [SerializeField] string objTagR;
    private string sockTagR = "Red_Box";
    [SerializeField] string objTagB;
    private string sockTagB = "Blue_Box";


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

    public void AddScoreR()
    {   
        xRSocketInteractor = sockets[0].GetComponentInChildren<XRSocketInteractor>();
        var currentBoxR = xRSocketInteractor.selectTarget.gameObject;
        objTagR = currentBoxR.tag;

        if (objTagR == sockTagR)
        {
            score++;
            correct.Play();
        }
        else{
            score--;
            if (score <= 0){
                score = 0;
            }
            wrong.Play();
        }
        
        StartCoroutine(Move(currentBoxR));
    }

    public void AddScoreB()
    {   
        xRSocketInteractor = sockets[1].GetComponentInChildren<XRSocketInteractor>();
        var currentBoxB = xRSocketInteractor.selectTarget.gameObject;
        objTagB = currentBoxB.tag;

        if (objTagB == sockTagB)
        {
            score++;
            correct.Play();
        }
        else{
            score--;
            if (score <= 0){
                score = 0;
            }
            wrong.Play();
        }
        
        StartCoroutine(Move(currentBoxB));
    }

    IEnumerator Move(GameObject currentBox)
    {

        yield return new WaitForSeconds(2f);
        for (int i = 0; i < sockets.Length; i++)
        {
            xRSocketInteractor = sockets[i].GetComponentInChildren<XRSocketInteractor>();
            xRSocketInteractor.socketActive = false;
        }
        
        currentBox.GetComponent<Rigidbody>().velocity = Vector3.zero;
        currentBox.SetActive(false);
        currentBox.transform.position = new Vector3(Random.Range(-25f, -20f), 2.5f, Random.Range(-50f, -55f));
        currentBox.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < sockets.Length; i++)
        {
            xRSocketInteractor = sockets[i].GetComponentInChildren<XRSocketInteractor>();
            xRSocketInteractor.socketActive = true;
        }
    }

    IEnumerator Restart()
    {
        score = 0;

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

