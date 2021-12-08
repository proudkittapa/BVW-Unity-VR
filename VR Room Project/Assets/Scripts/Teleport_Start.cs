using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Start : MonoBehaviour
{
    public GameObject Rig;
    private Vector3 start;
    // Start is called before the first frame update
    void Start()
    {
        start = Rig.transform.position;
    }

    public void toStart()
    {
        Rig.transform.position = start;
    }
    public void toGym()
    {
        Rig.transform.position = new Vector3(11f, 1.26f, -7f);
    }
}
