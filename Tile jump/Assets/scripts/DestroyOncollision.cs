using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOncollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            GameManager.Instance.platformList.Remove(other.gameObject);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Planet") || other.gameObject.CompareTag("platformSmily") || other.gameObject.CompareTag("platformDiamond"))
        {
            Destroy(other.gameObject);
        }


    }
}
