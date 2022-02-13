using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternalDetection : MonoBehaviour
{
     

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.hitMiddle = true;
            GameManager.Instance.multiplier = 2;
            Debug.Log("ASD");
            


        }
         

    }
}
