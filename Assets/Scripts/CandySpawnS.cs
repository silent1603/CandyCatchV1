using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawnS : MonoBehaviour
{
    [SerializeField]float maxX;
    // Start is called before the first frame update
    [SerializeField]GameObject[] candies;

    [SerializeField] float spawnInterval;

    //we need to access class easy from outside so use simple static
    public static CandySpawnS instance;

    private void Awake()
    {
        //if instance is null , we are setting our current instance on the principal object to this instance so
        //we can easy access all funtion in this class
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        StartSpawningCandies();
    }



    // Update is called once per frame
    void Update()
    {

    }
    void SpawnCandy()
    {
        int randCandy = Random.Range(0, candies.Length);
        float ranPos = Random.Range(-maxX,maxX);
        Vector3 randomPos = new Vector3(ranPos, transform.position.y, transform.position.z);
        transform.position = randomPos;
        Instantiate(candies[randCandy],transform.position,candies[randCandy].transform.rotation);
    }
    IEnumerator SpawnCandies()
    {
        yield return new WaitForSeconds(2f);

        while(true)
        {
            SpawnCandy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    //Start Corouties
    public void StartSpawningCandies()
    {
        StartCoroutine("SpawnCandies");
    }

    public void StopSpawningCandies()
    {
        StopCoroutine("SpawnCandies");
    }
}
