using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{


    void Start()
    {

       
    }

    void Update()
    {
        if(this.transform.position.z > 100f)
        {
            gameObject.SetActive(false);
        }
        else
        {
            transform.Translate(0,0,60f*Time.deltaTime);
        }
    }


}
