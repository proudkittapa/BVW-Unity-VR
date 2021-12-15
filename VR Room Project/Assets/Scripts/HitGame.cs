using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGame : MonoBehaviour
{
    public TMPro.TextMeshProUGUI timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if play
        currentTimer -= Time.deltaTime;

        textScore.text = currentScore + " - Score";
        textTimer.text = "Timer: " + Mathf.Round(currentTimer);

    }
}
