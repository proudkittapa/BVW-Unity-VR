using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject gameover;
    public Camera gameCam;
    public GameObject rig;

    void Update()
    {
        if (gameover.activeSelf)
        {
            Vector3 pos = gameCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 8f));
            gameover.transform.position = pos;
            gameover.transform.rotation = Quaternion.Euler(gameCam.transform.localEulerAngles.x, rig.transform.localEulerAngles.y + gameCam.transform.localEulerAngles.y, 0f);
        }
    }

    public void Hide()
    {
        gameover.SetActive(false);
    }
}
