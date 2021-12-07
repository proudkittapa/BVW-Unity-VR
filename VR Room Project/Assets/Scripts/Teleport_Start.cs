using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Start : MonoBehaviour
{
    public GameObject Rig;
    // Start is called before the first frame update
    void Start()
    {
        // new WaitForSeconds(5);
        Rig.transform.position = new Vector3(-10.24f, 1.26f, -20.37f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
