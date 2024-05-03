using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drone"))
        {
            other.gameObject.GetComponent<Health>().DealDamage(25);
            Destroy(gameObject);
        }   
    }
}
