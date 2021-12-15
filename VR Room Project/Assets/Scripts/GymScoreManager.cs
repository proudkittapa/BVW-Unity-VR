using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GymScoreManager : MonoBehaviour
{
    public static GymScoreManager Instance;

    public int score;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void Add1Score()
    {

        score += 1;

    }
    public void Add2Score()
    {

        score += 2;

    }

}
