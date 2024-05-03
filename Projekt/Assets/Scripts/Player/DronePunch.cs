using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DronePunch : MonoBehaviour
{





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Health>().DealDamage(15);
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
