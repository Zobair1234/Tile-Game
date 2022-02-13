using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExternalDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.hitMiddle = false;
            GameManager.Instance.multiplier = 1;

        }
    }
}
