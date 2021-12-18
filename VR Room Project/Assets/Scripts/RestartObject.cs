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

    public void toStart()
    {
        this.transform.position = startPos;
        this.transform.rotation = startRot;
    }

}
