using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public bool Found = false;
    public GameObject booom;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
        if(20 > distanceToEnemy) 
        {
            Found = true;
            transform.LookAt(player.transform);
            animator.SetBool("FindPlayer", true);
        }
        else
        {
            Found = false;
            animator.SetBool("FindPlayer", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SnowBall")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(booom, transform.position, transform.rotation);
        }
    }
}
