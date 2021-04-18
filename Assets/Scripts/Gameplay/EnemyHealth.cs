using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject HealthBarContainerRef;
    public GameObject EnemyRef;
    GameObject CamRef;

    public float Health;

    //audio
    public AudioManagerScript ams;
    public AudioClip Destroyed;
    public AudioClip EnemyDamage;

    // Particle
    [Header("Particle")]
    public GameObject deathParticle;

    public float maxHealth;
    public float currentHealth;

    void Start()
    {
        CamRef = GameObject.FindGameObjectWithTag("MainCamera");
        Health = GameManager.Instance.pyramidHP;

        ams.DestroyedS = GetComponent<AudioSource>();
    }

    void Update()
    {
        //// test purpose
        //if (Time.frameCount % 120 == 0)
        //{
        //    TakeDamage(2);
        //    // AudioSource.PlayClipAtPoint(GenericDamageSFX, transform.position);
        //    // Debug.Log("Enemy pew!");
        

        //if (currentHealth <= maxHealth)
        //{
        //    AudioSource.PlayClipAtPoint(GenericDamageSFX, transform.position);
        //}

        // Roatate healthbar if its not parallel to canvas
        // if (transform.rotation != Quaternion.Euler(-45f, 90f, 0f))
        // {
        //     transform.rotation = Quaternion.Euler(
        //         -45f,
        //         90f,
        //         0f
        //     );
        // }
    }

    public bool TakeDamage(int damage)
    {


        if (Health > 0)
        {
            // reduce health and update healthbar length
            Health -= damage;
            HealthBarContainerRef.transform.localScale = new Vector3(1f * (Health / 100f), HealthBarContainerRef.transform.localScale.y, HealthBarContainerRef.transform.localScale.z);
            // AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            // ams.EnemyDamageS.Play();
            // AudioSource.PlayClipAtPoint(EnemyDamage, transform.position);
            // change health bar color along with current health
            if (Health <= 30)
                gameObject.transform.Find("Container").transform.Find("HealthBar").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            else if (Health <= 60 && Health > 30)
                gameObject.transform.Find("Container").transform.Find("HealthBar").GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
        }
        else
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
            return true; //enemy died
            
        }

        return false; //enemy still alive
    }
}
