using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.Rotate(new Vector3(0f, 1f, 0f), Space.World);

    }



}
