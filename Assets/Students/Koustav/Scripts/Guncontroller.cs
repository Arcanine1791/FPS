using UnityEngine;
using TMPro;
public class Guncontroller : MonoBehaviour
{

    public float Damage = 10f;
    public float Range = 100f;
    public Camera cam;
    public ParticleSystem Gunflash;
    public AudioSource source;
    public AudioClip bulletSound;
    public GameObject Bulletimpact;
    float TimeInterval =0.1f;
    float TimeInterval_2 = 0.1f;

    public int MaxBullet_G1 = 20;
    public int MaxBullet_G2 = 20;
    int BulletReducer = 1;
    bool Isreloading;
    public TMP_Text BulletUpdater;
    public TMP_Text BulletUpdater_2;

    public GameObject Bulletpoint;

   
    void Start()
    {
        
        Isreloading = false;   
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && !Isreloading)
        {
            if (SelectGun.Gunchage)
            {
                RayCastFiring();
              
            }
            else
            {
                ObjectPoolFiring();
           
            }
        }
        Reloading(MaxBullet_G1);
        Reloading(MaxBullet_G2);
    }

    private void ObjectPoolFiring()
    {
        TimeInterval_2 -= Time.deltaTime;
        if (TimeInterval_2 <= 0)
        {
            TimeInterval_2 = 0.1f;
            GameObject ObjectpoolingGun = Objectpooling.instance.Pooling();
            ObjectpoolingGun.transform.position = Bulletpoint.transform.position;
            ObjectpoolingGun.transform.rotation = Bulletpoint.transform.rotation;
            if (ObjectpoolingGun != null)
            {
                ObjectpoolingGun.SetActive(true);
                MaxBullet_G2 -= BulletReducer;

            }

        }
    }

    private void RayCastFiring()
    {
        TimeInterval -=Time.deltaTime;
        if (TimeInterval <= 0)
        {
            
                TimeInterval = 0.1f;
                RaycastHit hit;
                Gunflash.Play();
                source.PlayOneShot(bulletSound);
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range))
                {
          
                    EnemyHandler EnemyAccesser = hit.transform.GetComponent<EnemyHandler>();

                    if (EnemyAccesser != null)
                    {
                        EnemyAccesser.HealthControl(Damage);
                    }
                    GameObject Holder = Instantiate(Bulletimpact, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(Holder, 1.5f);
                   
                }
                MaxBullet_G1 -= BulletReducer;
                BulletUpdater.text = "x " + MaxBullet_G1.ToString();
            
        }
    }

    void Reloading(int TotalBulet)
    {
        if(TotalBulet <= 0)
        {
            Isreloading = true;
        }
        if(Input.GetKeyDown(KeyCode.R) && SelectGun.Gunchage)
        {
            MaxBullet_G1 = 20;
            BulletUpdater.text = "x " + MaxBullet_G1.ToString();
            Isreloading = false;
        }
        if (Input.GetKeyDown(KeyCode.R) && !SelectGun.Gunchage)
        {
            Debug.Log(MaxBullet_G2);
            MaxBullet_G2 = 20;
            BulletUpdater_2.text = "x " + MaxBullet_G2.ToString();
            Isreloading = false;
        }

    }
}
