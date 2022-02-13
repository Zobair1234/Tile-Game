using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnHeight : MonoBehaviour
{
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.goingUp==true && transform.position.y >= 4.31f)
        {
           transform.position=new Vector3 ( transform.position.x, 4.31f,0);
           gameObject.GetComponent<Rigidbody>().isKinematic = true;
           GameManager.Instance.goingUp = false;

        }
    }
}
