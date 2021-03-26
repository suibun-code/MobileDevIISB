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


    // clock ui reference
    Text SecondsUI;
    Text MinutesUI;
    GameObject BreakText;


    void Start()
    {
        isInWave = true;


        // get reference to UI text
        SecondsUI = GameObject.FindGameObjectWithTag("Seconds").GetComponent<Text>();
        MinutesUI = GameObject.FindGameObjectWithTag("Minutes").GetComponent<Text>();
        UpdateUIText();

        // get break indicator UI
        BreakText = GameObject.FindGameObjectWithTag("PauseIndicator");
        BreakText.SetActive(false);
    }

    void Update() {
        
        ClockTick();
        WaveEvent();
        
    }





    void ClockTick()
    {
        if (Time.frameCount % 60 == 0)
        {
            Clock_Seconds++;
            if (Clock_Seconds == 60)
            {
                Clock_Minutes++;
                Clock_Seconds = 0;
            }
            UpdateUIText();
            // print(Clock_Minutes + " : " + Clock_Seconds);
        }
    }

    void WaveEvent()
    {
        if (Time.frameCount % (60*WaveEventInterval) == 0 && isInWave)
        {


            // print("Run wave event");

            // spawn enemy
            GetComponent<EnemyPooler>().SpawnEnemy();
            
            // increment wave count
            TotalWave++;

            // print(TotalWave);
            // take a break every 5 wave
            if (TotalWave % 2 == 0)
            {
                isInWave = false;
                BreakText.gameObject.SetActive(true);
            }

        }


        // if not in wave, take break
        if (!isInWave)
        {
            if (Time.frameCount % 60 == 0)
            {
                int temp = GameObject.FindGameObjectsWithTag("Enemy").Length;

                BreakTime--;
                if (BreakTime <= 0 && temp <= 0)
                {
                    isInWave = true;
                    BreakTime = 20;
                    BreakText.SetActive(false);
                }
            }
        }

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
    }
}
