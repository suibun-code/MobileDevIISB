using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WaveManager : MonoBehaviour
{
  
   

    // 60 seconds = 1 minutes
    // when Clock_Seconds equals to 60 it resets it self to zero
    // and increase Clock_minutes by 1
    int Clock_Seconds = 0;
    int Clock_Minutes = 0;

    // this bool detemines is the wave ongoing
    // if false, player is in break between waves
    bool isInWave;


    // this will determine wave event will run every X seconds
    int WaveEventInterval = 8;

    // break time between rounds will be 30 seconds
    int BreakTime = 20;


    // wave spawned
    int TotalWave;
    int SmallWave;

    // clock ui reference
    Text SecondsUI;
    Text MinutesUI;
    GameObject BreakText;
    Text WaveText;

    // enemy spawner ref
    GameObject[] enemySpawner;


    void Start()
    {
        isInWave = true;
        TotalWave = GameManager.Instance.waveNum;
        SmallWave = 0;

        
        
        // get reference to UI text
        SecondsUI = GameObject.FindGameObjectWithTag("Seconds").GetComponent<Text>();
        MinutesUI = GameObject.FindGameObjectWithTag("Minutes").GetComponent<Text>();
        WaveText = GameObject.FindGameObjectWithTag("WaveText").GetComponent<Text>();
        UpdateUIText();

        // get break indicator UI
        BreakText = GameObject.FindGameObjectWithTag("PauseIndicator");
 
        // get enemy spawner
        enemySpawner = GameObject.FindGameObjectsWithTag("EnemySpawner");


        // start clock
        InvokeRepeating(nameof(ClockTick), 0, 1);

        StartCoroutine(nameof(GameStart));


    }

    IEnumerator GameStart()
    {
        // BreakText.gameObject.SetActive(true);

        yield return new WaitForSeconds(WaveEventInterval);
        // start Wave Event
        InvokeRepeating(nameof(WaveEvent), 0, WaveEventInterval);
        BreakText.gameObject.SetActive(false);
        TotalWave++;
        UpdateUIText();

    }


    void Update() 
    {
        
    }


    // spawn enemy from all enemy spawner
    void SpawnEnemyForAllEnemySpawner()
    {
        foreach (var item in enemySpawner)
        {
            item.GetComponent<EnemyPooler>().SpawnEnemy();
        }
    }



    void ClockTick()
    {
        // clock tick
        Clock_Seconds++;
        if (Clock_Seconds == 60)
        {
            Clock_Minutes++;
            Clock_Seconds = 0;
        }
        UpdateUIText();
        // print(Clock_Minutes + " : " + Clock_Seconds);
    }

    void WaveEvent()
    {
        // // runs every x seconds if in wave
        if (isInWave)
        {
            print("Run wave event");

            // spawn enemy
            SpawnEnemyForAllEnemySpawner();
            
            // increment wave count
            SmallWave++;

            // print(TotalWave);
            // take a break every 5 wave
            if (SmallWave % 4 == 0 && isInWave)
            {
                StartCoroutine(StartBreak());

            }

        }

    }
    

    IEnumerator StartBreak()
    {
        // go pause
        isInWave = false;
        BreakText.SetActive(true);

        yield return new WaitForSeconds(16);
        
        TotalWave++;
        // go in wave
        BreakText.gameObject.SetActive(false);
        isInWave = true;
    }



    void UpdateUIText()
    {
        if (Clock_Seconds < 10)
        {
            SecondsUI.text = "0" + Clock_Seconds.ToString();
        }
        else
        {
            SecondsUI.text = Clock_Seconds.ToString();
        }

    
        if (Clock_Minutes < 10)
        {
            MinutesUI.text = "0" + Clock_Minutes.ToString();
        }
        else
        {
            MinutesUI.text = Clock_Minutes.ToString();
        }

        WaveText.text = TotalWave.ToString();

    }
}
