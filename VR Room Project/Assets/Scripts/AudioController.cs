using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] findConditions;
    public AudioSource Sound;
    public AudioClip NotFound;
    public AudioClip Found;
    public AudioClip LastOne;
    public AudioClip Win;
    private int prev = 2;
    private int FoundNo = 1;
    private int NotFoundNo = 0;
    private bool LastPassed = false;
    private bool AllDied = false;
    private bool AllNotFound = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        findConditions = GameObject.FindGameObjectsWithTag("Enemy");
        if (findConditions.Length == 1)
        {
            if (LastPassed == false)
            {
                LastPassed = true;
                Sound.Stop();
                Sound.clip = LastOne;
                Sound.Play();
            }
        }
        else if(findConditions.Length == 0)
        {
            if(AllDied == false)
            {
                AllDied = true;
                Sound.Stop();
                Sound.clip = Win;
                Sound.Play();
            }
        }
        else
        {
            //Debug.Log(findConditions.Length);
            foreach (GameObject findCondition in findConditions)
            {
                if(findCondition.GetComponent<Enemies>().Found == true)
                {
                    AllNotFound = false;
                    break;
                }
                else
                {
                    AllNotFound = true;
                }
            }
            foreach (GameObject findCondition in findConditions)
            {
                if (findCondition.GetComponent<Enemies>().Found == true)
                {
                    if (prev != NotFoundNo)
                    {
                        Sound.Stop();
                        Sound.clip = Found;
                        Sound.Play();
                        prev = NotFoundNo;
                        Debug.Log("find");
                    }
                    
                }
                else if(AllNotFound)
                {
                    if (prev != FoundNo)
                    {
                        Sound.Stop();
                        Sound.clip = NotFound;
                        Sound.Play();
                        prev = FoundNo;
                        Debug.Log("no");
                    }
                }
            }
        }
    }
}
