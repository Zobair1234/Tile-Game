using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDiamond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.diamondpoint += 1;
            GameManager.Instance.dimonds.text = "" + GameManager.Instance.diamondpoint;
            gameObject.SetActive(false);
        }
    }
}
