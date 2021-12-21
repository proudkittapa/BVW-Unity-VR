using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorrorGame : MonoBehaviour
{
    [SerializeField] bool play = false;
    [SerializeField] GameObject[] gameSetting;
    [SerializeField] GameObject[] enemiesObject;

    public GameObject[] findConditions;

    public TMPro.TextMeshProUGUI startButton;
    public TMPro.TextMeshProUGUI enemies;

    private bool init = true;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            findConditions = GameObject.FindGameObjectsWithTag("Enemy");
            int EnemyNum = findConditions.Length;
            enemies.text = "" + EnemyNum;
            if (EnemyNum == 0)
            {
                play = false;
                startButton.text = "Start";
            }
        }
    }

    public void StartGame()
    {
        if (play == true)
        {
            startButton.text = "Restart";

        }
        else 
        {
            play = true;
            startButton.text = "Restart";
        }

        for (int i = 0; i < gameSetting.Length; i++)
        {
            gameSetting[i].SetActive(true);
        }

        if (init)
        {
            init = false;
            enemiesObject = GameObject.FindGameObjectsWithTag("Enemy");
        }

        for (int i = 0; i < enemiesObject.Length; i++)
        {
            enemiesObject[i].SetActive(true);
        }
    }

}
