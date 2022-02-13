using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force_down : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            other.gameObject.GetComponent<Rigidbody>().AddForce(-transform.up * GameManager.Instance.downForce);
        }
    }
}
