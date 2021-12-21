using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public TMPro.TextMeshProUGUI textEnemyNum;
    public TMPro.TextMeshProUGUI textCaution;
    private int EnemyNum = 10;
    public Image image;

    void Start()
    {
        textEnemyNum.text = "Enemy : " + EnemyNum;
        textCaution.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        findConditions = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyNum = findConditions.Length;
        textEnemyNum.text = "Enemy : " + EnemyNum;
        if (findConditions.Length == 1)
        {
            if (LastPassed == false)
            {
                LastPassed = true;
                Sound.Stop();
                Sound.clip = LastOne;
                Sound.loop = true;
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
                Sound.loop = false;
                Sound.Play();
                textCaution.text = "You killed all enemies!";
                StartCoroutine(KilledAll());
            }
        }
        else
        {
            textEnemyNum.gameObject.SetActive(true);
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
                        Sound.loop = true;
                        Sound.Play();
                        prev = NotFoundNo;
                        textCaution.text = "RUN!!!!\nOR\nTHROW SNOWBALL!!!!!";
                        //Debug.Log("find");
                    }
                    
                }
                else if(AllNotFound)
                {
                    if (prev != FoundNo)
                    {
                        Sound.Stop();
                        Sound.clip = NotFound;
                        Sound.loop = true;
                        Sound.Play();
                        
                        prev = FoundNo;
                        textCaution.text = "";
                        //Debug.Log("no");
                    }
                }
            }
        }
    }

    IEnumerator KilledAll()
    {
        yield return new WaitForSeconds(10);
        textCaution.text = "";
        textEnemyNum.gameObject.SetActive(false);
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        image.gameObject.SetActive(false);
    }

}

