using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoveByTouch : MonoBehaviour
{
    // Start is called before the first frame update

    private Touch touch;
    private float speedModifier;
    public GameObject song;

    bool isplaying;

    public TextMeshProUGUI touchTOstart;
    void Start()
    {
        speedModifier = 0.007f;
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && GameManager.Instance.gameover == false && GameManager.Instance.gamePaused == false)
        {
            if (!isplaying)
            {
                song.GetComponent<AudioSource>().Play();
                isplaying = true;
            }
            touchTOstart.text = "";
            Time.timeScale = 1;
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedModifier, transform.position.y, transform.position.z);
            }
        }
      

        if (transform.position.x <= -5.3f)
        {
            transform.position = new Vector3(-5.3f, transform.position.y, transform.position.z);
        }

        else if (transform.position.x >= 5.3f)
        {
            transform.position = new Vector3(5.3f, transform.position.y, transform.position.z);
        }

    }

}
