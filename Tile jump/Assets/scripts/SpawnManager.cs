using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public GameObject platformsmily;
    public GameObject platformdiamond;

    public GameObject spawnPos;
    public GameObject spawnPos1;
    public GameObject spawnPos2;
    public GameObject ObjspawnPos1;
    public GameObject ObjspawnPos2;
    public List<GameObject> sideObjects;
    bool isSpawned;



    void Start()
    {
        //InvokeRepeating("SpawnRandomPosition", 0, 1.5f);
        InvokeRepeating("SideObjects", 2, 3f);
    }

    private void Update()
    {
        if(!isSpawned)
        {
            SpawnRandomPosition();
            isSpawned = true;
            StartCoroutine(WaitBeforeNextSpawn());
        }
    }

    void SpawnRandomPosition()
    {
        int rand = Random.Range(1, 100);
        int randselect = Random.Range(1, 10);

        if (randselect <= 1)
        {
            if (rand > 0 && rand < 33)
                SpawnPlatform(spawnPos, platformsmily);
            else if (rand > 33 && rand < 66)
                SpawnPlatform(spawnPos1, platformsmily);
            else
                SpawnPlatform(spawnPos2, platformsmily);
        }

        else if (randselect <= 2 && randselect > 1)
        {
            if (rand > 0 && rand < 33)
                SpawnPlatform(spawnPos, platformdiamond);
            else if (rand > 33 && rand < 66)
                SpawnPlatform(spawnPos1, platformdiamond);
            else
                SpawnPlatform(spawnPos2, platformdiamond);
        }
        else
        {
            if (rand > 0 && rand < 33)
                SpawnPlatform(spawnPos, platform);
            else if (rand > 33 && rand < 66)
                SpawnPlatform(spawnPos1, platform);
            else
                SpawnPlatform(spawnPos2, platform);
        }


    }
    void SideObjects()
    {
         
        if(Random.Range(1,100)%2==0)
            Instantiate(sideObjects[Random.Range(0,2)], ObjspawnPos1.transform.position, sideObjects[0].transform.rotation);

        if (Random.Range(1, 100) % 2 == 0)
            Instantiate(sideObjects[Random.Range(0, 2)], ObjspawnPos2.transform.position, sideObjects[0].transform.rotation);


    }

    void SpawnPlatform(GameObject pos,GameObject platformtype)
    {
        GameObject instance = Instantiate(platformtype, pos.transform.position, platform.transform.rotation);
        if (instance.CompareTag("Platform"))
        {
            GameManager.Instance.platformList.Add(instance);
        }
       
    }


    IEnumerator WaitBeforeNextSpawn()
    {
        yield return new WaitForSeconds(GameManager.Instance.timeBetweenSpawn);
        isSpawned = false;
    }
}
