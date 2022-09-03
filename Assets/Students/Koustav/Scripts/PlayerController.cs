using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoventSpeed;
    Rigidbody PlayerBody;
    GameObject BulletPositon;
    Vector3 temp;
    public Transform gun;
    public bool isreoad;
    public CharacterController Controller;
    public static PlayerController instance;
    public GameObject Aimassist;
    public Transform pos;
    public Transform Pos2;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {

         PlayerBody = GetComponent<Rigidbody>();
    }


    void Update()
    {

        SwitchingGunViews();
        PlayerMovement();
    }

    private void SwitchingGunViews()
    {
        if (Input.GetMouseButton(1))
        {
            pos.localPosition = new Vector3(-0.24f, 0f, 0f);
            Pos2.localPosition = new Vector3(-0.24f, 0f, 0f);
            Aimassist.SetActive(false);
        }
        else
        {
            pos.localPosition = new Vector3(0f, 0f, 0f);
            Pos2.localPosition = new Vector3(0f, 0f, 0f);
            Aimassist.SetActive(true);
        }
    }

    void PlayerMovement()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Virtical = Input.GetAxis("Vertical");
        Vector3 Move = transform.right * Horizontal + transform.forward * Virtical;
        Controller.Move(Move * MoventSpeed * Time.deltaTime);
    }

}
