using UnityEngine;

public class GunScript : MonoBehaviour
{

    RaycastHit hit;

    [SerializeField] private float currentAmmo;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed = 100f;

    private float nextFire;


    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet;
    Rigidbody rigidBody;



    AudioSource gunSound;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
            BulletInstance();
            Shoot();
            
            gunSound = GetComponent<AudioSource>();
            gunSound.PlayScheduled(0.3);
        }

       

    }


    private void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            currentAmmo--;
        }

        
        if (Physics.Raycast(firePoint.position,firePoint.forward, out hit, range))
        {
            if (hit.transform.tag == "Drone")
            {
                
                Debug.Log("Hit Drone");
            }
            else
            {
                Debug.Log("Hit smthn else");
            }
        } 
    }
    
    private void BulletInstance()
    {
            GameObject bulletPrefab = Instantiate(bullet, firePoint.position,firePoint.rotation) as GameObject;
            Rigidbody rb = bulletPrefab.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.transform.forward * bulletSpeed, ForceMode.Impulse);

    }






} 