using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public Text experienceText;
    public Text waveText;

    private int waveLevel;
    private float asteroidSpawnWaitTime;
    private float waveStartWait;
    private int experience;
    private bool waveSpawned;
    private float spawnXMin, spawnXMax, spawnZMin, spawnZMax; //boundaries of spawn area


    private void Start()
    {
        waveLevel = 1;     
        asteroidSpawnWaitTime = 1.0f;
        waveStartWait = 2.0f;
        experience = 0;
        UpdateExperience(0);
        spawnXMin = -29.0f;
        spawnXMax = 29.0f; 
        spawnZMin = -29.0f;
        spawnZMax = 29.0f;
        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Asteroid") == null && waveSpawned == true)
        {
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        waveSpawned = false;
        waveText.text = "Wave " + waveLevel;
        yield return new WaitForSeconds(waveStartWait);
        waveText.text = "";
        List<Vector3> spawnList = new List<Vector3>();

         //make sure to spawn asteroids outside play area and make some space between spawn points
         for(int x = (int)spawnXMin; x < spawnXMax; x++)
         {
             for (int z = (int)spawnZMin; z <  spawnZMax; z++)
             {
                 if(x % 3 == 0 && z % 3 == 0)
                 {
                     if(x < -24 || x > 24 || z < -24 || z > 24)
                     {
                        spawnList.Add(new Vector3(x, 0.0f, z));
                     }
                 }
             }
         }

        //spawn more asteroids per wave
        int count = spawnList.Count - 1;
        for (int i = 0; i < waveLevel * 4 + 10; i++)
        {
            //spawn at random location
            Instantiate(asteroid, spawnList[Random.Range(0, count)], Quaternion.identity);
            yield return new WaitForSeconds(asteroidSpawnWaitTime);
        }

        waveLevel++;
        asteroidSpawnWaitTime -= 0.1f;
        waveSpawned = true;        
        
    }

    public void UpdateExperience(int expGain)
    {
        experience += expGain;
        experienceText.text = "SCORE: " + experience;
    }

    public int getWaveLevel()
    {
        return waveLevel;
    }

    IEnumerator GameOverWait ()
    {
        yield return new WaitForSeconds(3.0f);
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        waveText.text = "GAME OVER!";
        enabled = false;
        StartCoroutine (GameOverWait());
    }


}
