using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGun : MonoBehaviour
{
    public static bool Gunchage;
    public GameObject Gun_1;
    public GameObject Gun_2;
    public GameObject BulletUpdate_1;
    public GameObject BulletUpdate_2;
    void Start()
    {
        Gunchage = true;
    }

    void Update()
    {
        SelectingGun();
    }

    private void SelectingGun()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Gunchage = !Gunchage;
           

        }
        if (Gunchage)
        {
            Gun_1.SetActive(true);
            Gun_2.SetActive(false);
            BulletUpdate_1.SetActive(true);
            BulletUpdate_2.SetActive(false);
        }
        else
        {
            Gun_1.SetActive(false);
            Gun_2.SetActive(true);
            BulletUpdate_1.SetActive(false);
            BulletUpdate_2.SetActive(true);
        }
    }
}
