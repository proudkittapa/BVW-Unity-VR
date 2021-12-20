using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartObject : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRot;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        startRot = Quaternion.Euler(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y + 1f, this.transform.localEulerAngles.z);
    }

    void Update() {
        Vector3 pos = this.transform.position;

        if (pos.x <= -50.0 || pos.x >= -10.0 || pos.y <= -5.0 || pos.y >= 20.0 || pos.z <= -70.0 || pos.z >= 0.0 )
        {   
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.transform.position = startPos;
            this.transform.rotation = startRot;
        }
    }

    public void toStart()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.transform.position = startPos;
        this.transform.rotation = startRot;
    }

}
