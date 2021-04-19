using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject HealthBarContainerRef;
    public GameObject EnemyRef;
    GameObject CamRef;

    float spawnHealth;
    float Health;

    //audio
    public AudioManagerScript ams;
    public AudioClip Destroyed;
    public AudioClip EnemyDamage;

    // Particle
    [Header("Particle")]
    public GameObject deathParticle;

    void Start()
    {
        CamRef = GameObject.FindGameObjectWithTag("MainCamera");

        // as wave increase, enemy size and health should increase
        var currWave = GameObject.FindGameObjectWithTag("WaveManager").GetComponent<WaveManager>().TotalWave;
        
        // print(currWave);
        if (currWave < 2)
        {
            // EnemyRef.transform.localScale = new Vector3(1,1,1);
            Health = 100.0f;
            
        }
        else if (currWave % 5 == 0)
        {
            EnemyRef.transform.localScale = new Vector3(4,4,4);
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            Health = 100.0f * currWave;
        }
        else
        {
            EnemyRef.transform.localScale = new Vector3(2,2,2);
            transform.localScale = new Vector3(0.5f,0.5f,0.5f);
            Health = 100.0f * currWave / 2;
        }

        spawnHealth = Health;
     
     
        ams.DestroyedS = GetComponent<AudioSource>();
    }

    void Update()
    {
        // if (Health <= 0)
        // {
        //     Death();
        // }
    }

    public bool TakeDamage(int damage)
    {
        if (Health - damage > 0)
        {
            // reduce health and update healthbar length
            Health -= damage;
            HealthBarContainerRef.transform.localScale = new Vector3(1f * (Health / spawnHealth), HealthBarContainerRef.transform.localScale.y, HealthBarContainerRef.transform.localScale.z);
            // AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            // ams.EnemyDamageS.Play();
            // AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            // change health bar color along with current health
            if (Health <= 30)
            {
                gameObject.transform.Find("Container").transform.Find("HealthBar").GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            }
            else if (Health <= 60 && Health > 30)
            {
                gameObject.transform.Find("Container").transform.Find("HealthBar").GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            }
        }
        else
        {

            Death();
            return true; //enemy died
            
        }

        return false; //enemy still alive
    }



    public void Death()
    {
        // enemy destroy particle
        Instantiate(deathParticle, EnemyRef.transform.position, Quaternion.identity);

        // destroy enemy
        Destroy(EnemyRef);
        ResourceInventorySystem.bricks += 2;
        ResourceInventorySystem.gold += 1;
        ResourceInventorySystem.diamond += 1;

        // AudioSource.PlayClipAtPoint(Destroyed, transform.position);
        // ams.DestroyedS.Play();

        // ams.DestroyedS.Play();
        // AudioSource.PlayClipAtPoint(Destroyed, transform.position);
    }
}
