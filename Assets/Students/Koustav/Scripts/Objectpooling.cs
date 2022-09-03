using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpooling : MonoBehaviour
{
    public int BulletCount;
    public GameObject Bullets;
    public List<GameObject> PoolingBullets = new List<GameObject>();


    public static Objectpooling instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        GameObject BulletHolder;
        for (int i = 0; i <BulletCount; i++)
        {
            BulletHolder = Instantiate(Bullets,transform.position,Quaternion.identity);
            BulletHolder.transform.parent = this.transform;
            Bullets.SetActive(false);
            PoolingBullets.Add(BulletHolder);
           
        }

    }

    public GameObject Pooling()
    {
        for (int i = 0; i < BulletCount; i++)
        {
            if (!PoolingBullets[i].activeInHierarchy)
            {
                return PoolingBullets[i];
            }
        }
        return null;
    }

}
