using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetCollision : MonoBehaviour
{
    public GameObject starPrefab;
    

    //public AudioSource soundRespawn;
    //public AudioSource soundHit;

    public int starArraySize = 2;
    public GameObject[] starArray;


    // Start is called before the first frame update
    void Start()
    {
        starArray = new GameObject[starArraySize];
        for (int i = 0; i < starArraySize; i++)
        {
            starArray[i] = Instantiate(starPrefab, new Vector3(Random.Range(34f, 14f), Random.Range(1f, 11f), Random.Range(-8f, -36f)), this.transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (GymStartGame.play) { 
            // when the collision happens, 
            Debug.Log("coin collected");
            if (collision.gameObject.tag == "TargetStar")
            {

                Debug.Log("coin collected");
                //soundHit.Play();
                // if the collided object is a coin, then we're gonnna make the coin disappear and increase the score
                // Destroy(collision.gameObject);
                // currentScore++;
                GymScoreManager.Instance.Add2Score();

                StartCoroutine(RespawnStar(collision.gameObject)); // Respawn Stars

            }
            if (collision.gameObject.tag == "TargetAlvo" || collision.gameObject.tag == "TargetSanta" || collision.gameObject.tag == "TargetSock")
            {
                Debug.Log("coin collected");
                GymScoreManager.Instance.Add1Score();

            }
        }

    }

    IEnumerator RespawnStar(GameObject star)
    {

        star.SetActive(false);
        yield return new WaitForSeconds(3f);

        // transform coin
        star.transform.position = new Vector3(Random.Range(34f, 12f), Random.Range(1f, 10f), Random.Range(-9f, -36f));
        star.SetActive(true);
        //soundRespawn.Play();

        // respawn coin
        // Instantiate(starPrefab, new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 6f), -5f), this.transform.rotation);

    }

    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {

            Debug.Log("coin collected");
            soundHit.Play();
            // if the collided object is a coin, then we're gonnna make the coin disappear and increase the score
            // Destroy(collision.gameObject);
            currentScore++;
            ScoreManager.Instance.AddScore();


            StartCoroutine(RespawnCoin(collision.gameObject)); // Respawn Coins

        }
    }*/

}
