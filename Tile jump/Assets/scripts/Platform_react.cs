using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Platform_react : MonoBehaviour
{
    // Start is called before the first frame update

    
    
    public float expand = 0.4f;
    public GameObject smiley;

    private void Start()
    {
         
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {   

            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * GameManager.Instance.jumpForce);
            GameManager.Instance.goingUp = true;
            Debug.Log(GameManager.Instance.goingUp);
            GameManager.Instance.totalPoint += GameManager.Instance.multiplier;
            gameObject.transform.GetChild(1).gameObject.transform.DOScale(expand, 0.3f);

            if(gameObject.CompareTag("platformSmily"))
            {
                gameObject.transform.GetChild(3).gameObject.SetActive(false);
                gameObject.transform.GetChild(5).gameObject.SetActive(false);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                smiley.SetActive(true);
            }
            StartCoroutine(SecondEffect());
            
        }




    }

    IEnumerator SecondEffect()
    {
        yield return new WaitForSeconds(.2f);
        gameObject.transform.GetChild(2).gameObject.transform.DOScale(expand, 0.3f);
    }

 
}
