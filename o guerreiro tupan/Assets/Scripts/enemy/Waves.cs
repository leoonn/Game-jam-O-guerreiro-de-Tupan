using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waves : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;

    }


    public Wave[] waves;
    private int nextWave = 0;

    public TMP_Text TextWave;
    public TMP_Text WaveCompletedText;
    string WaveCompletedWrite = "WAVE COMPLETED ";
    public TMP_Text TextTimeNextWave;
    int wavecount = 1;

    public Transform[] SpawnPoints;

    float timeBetweenWaves = 2f;
    public float waveCountdown;

    private float searchCoutdown = 1f;

    public SpawnState state = SpawnState.COUNTING;





    void Start()
    {
        waveCountdown = timeBetweenWaves;
        TimeTextWave();

    }

    // Update is called once per frame
    void Update()
    {

        //TextTimeNextWave.text = "Time for next wave:" + waveCountdown.ToString("f0");
        //TextWave.text = "Wave: " + wavecount;
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {

                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }

        }
        else
        {
            waveCountdown -= Time.deltaTime % 1000;
        }

        void WaveCompleted()
        {
            Debug.Log("wave Completed");

            state = SpawnState.COUNTING;
            waveCountdown = timeBetweenWaves;
            ShowWaveCompleted();
            TimeTextWave();
            if (nextWave + 1 > waves.Length - 1)
            {
                nextWave = 0;
                wavecount = 0;
                Debug.Log("ALL waves Completed ! looping...");
            }
            else
            {
                nextWave++;
                wavecount++;
            }

        }
    }
    bool EnemyIsAlive()
    {
        searchCoutdown -= Time.deltaTime;
        if (searchCoutdown <= 0)
        {
            searchCoutdown = 1f;
            if (GameObject.FindGameObjectWithTag("Chase") == null && GameObject.FindGameObjectWithTag("Shooter") == null)
            {

                return false;
            }

        }
        return true;
    }

    IEnumerator SpawnWave(Wave waves)
    {
        Debug.Log("Wave: " + waves.name);
        state = SpawnState.SPAWNING;
        //WaveCompletedText.gameObject.SetActive(false);
        //TextTimeNextWave.gameObject.SetActive(false);
        for (int i = 0; i < waves.count; i++)
        {
            int rand = Random.Range(0, waves.enemy.Length);
            SpawnEnemy(waves.enemy[rand]);
            yield return new WaitForSeconds(1f * waves.rate);
        }
        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Debug.Log("Spawning enemy" + enemy.name);

        Transform sp = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
        Instantiate(enemy, sp.transform.position, sp.transform.rotation);
    }
    void ShowWaveCompleted()
    {
       // WaveCompletedText.gameObject.SetActive(true);
       // WaveCompletedText.text = WaveCompletedWrite;
    }

    void TimeTextWave()
    {
       // TextTimeNextWave.gameObject.SetActive(true);

    }

}
