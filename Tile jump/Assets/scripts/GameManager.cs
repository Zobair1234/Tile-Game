using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    // Start is called before the first frame update

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject twoX;

    public Material spaceMaterial;
    public TextMeshProUGUI point;
    public TextMeshProUGUI dimonds;
    public TextMeshProUGUI highScoretext;

    public int diamondpoint = 0;
    public int totalPoint   = 0;
    public int multiplier   = 1;


    public float timeBetweenSpawn = 1.5f;
    public int jumpForce ;
    public int downForce ;
    public float platformMoveSpeed;

    public bool hitMiddle = false;
    public bool goingUp = false;
    public bool gameover = false;
    
    
    public bool gamePaused = false;
    bool changeDifficulty = true;

    public GameObject song;

    public List<GameObject> platformList;


    int highScorePoint;
    int colorIndex = 0;
    
    [SerializeField]  List<Color> colorListSpace = new List<Color>();
   
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }


        Instance = this;
        //DontDestroyOnLoad(gameObject);

         
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScorePoint = PlayerPrefs.GetInt("HighScore");
            highScoretext.text = "" + highScorePoint;
        }
        
        InvokeRepeating("ChangeColorIndex", 1,10);
        

    }

    // Update is called once per frame
    void Update()
    {
        point.text = ""+ totalPoint;

        if(totalPoint>highScorePoint)
        {
            highScorePoint = totalPoint;
            highScoretext.text = "" + highScorePoint;
            PlayerPrefs.SetInt("HighScore",highScorePoint);
        }

        if(totalPoint%5 == 0 && totalPoint > 0 && changeDifficulty==true && jumpForce<800)
        {
            jumpForce += 50;
            downForce += 50;
            platformMoveSpeed += 0.75f;
            timeBetweenSpawn -= 0.08f;
            changeDifficulty = false;
            StartCoroutine(difficultyPause());
        }


        if (Application.platform == RuntimePlatform.Android)
        {

            
            if (Input.GetKeyDown(KeyCode.Escape) && gamePaused ==false)
            {
                 PauseGame();
                 gamePaused = true;
                 pauseMenu.SetActive(true);
                 
            }

            else if((Input.GetKeyDown(KeyCode.Escape) && gamePaused == true))
            {
                ResumeGame();
                 
            }
        }

        ActivateDiamond(hitMiddle);
         


    }

    void ChangeColorIndex()
    {
        Debug.Log(colorIndex);
        spaceMaterial.DOColor(colorListSpace[colorIndex], .5f);

        colorIndex++;

        if (colorIndex > 5)
        {
            colorIndex = 0;
        }
    }

    public void ActivateDiamond(bool val)
    {
        for (int i = 0; i < platformList.Count; i++)
        {
            if(platformList[i].CompareTag("Platform"))
            platformList[i].transform.GetChild(5).GetComponent<MeshRenderer>().enabled = val;
            twoX.SetActive(val);

        }
    }

    IEnumerator difficultyPause()
    {
        yield return new WaitForSeconds(3);
        changeDifficulty = true;

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        
        song.GetComponent<AudioSource>().Pause();
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false); 
        gamePaused = false;        
        song.GetComponent<AudioSource>().Play();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Main");
    }
    public void LoadSceneMain()
    {
        SceneManager.LoadScene("Main Menu");
    }



}
