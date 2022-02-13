using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplatform : MonoBehaviour
{
    // Start is called before the first frame update
    
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-transform.forward *Time.deltaTime * GameManager.Instance.platformMoveSpeed);
    }
}
