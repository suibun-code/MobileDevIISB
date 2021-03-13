using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject HealthBarContainerRef;
    public GameObject EnemyRef;
    GameObject CamRef;

    float Health;

    //audio
    [Header("Audio")]
    public AudioClip DestroyedSFX;
    public AudioClip EnemyHitWithArrowSFX;
    public AudioClip EnemyHitWithMagicSFX;
    public AudioClip EnemyHitWithPunchSFX;
    public AudioClip EnemyHitWithSwordSFX;
    public AudioClip GenericDamageSFX;

    void Start()
    {
        CamRef = GameObject.FindGameObjectWithTag("MainCamera");
        Health = 100f;
    }

    void Update()
    {
        // test purpose
        if (Time.frameCount % 120 == 0)
        {
            TakeDamage(2);
            AudioSource.PlayClipAtPoint(GenericDamageSFX, transform.position);
        }



        // Roatate healthbar if its not parallel to canvas
        if (transform.rotation != Quaternion.Euler(-45f, 90f, 0f))
        {
            transform.rotation = Quaternion.Euler(
                -45f,
                90f,
                0f
            );
        }
    }

    void TakeDamage(int damage)
    {
        if (Health > 1)
        {
            // reduce health and update healthbar length
            Health -= damage;
            HealthBarContainerRef.transform.localScale = new Vector3(
                1f * (Health / 100f),
                HealthBarContainerRef.transform.localScale.y,
                HealthBarContainerRef.transform.localScale.z
            );



            // change health bar color along with current health
            if(Health <= 30)
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
            // destroy enemy
            Destroy(EnemyRef);
            ResourceInventorySystem.bricks += 15;
            ResourceInventorySystem.gold += 9;
            ResourceInventorySystem.diamond += 3;

            AudioSource.PlayClipAtPoint(DestroyedSFX, transform.position);

            if (ResourceInventorySystem.bricks >= 10 && ResourceInventorySystem.gold >= 5 &&
                  ResourceInventorySystem.diamond >= 2)
            {
                ToggleBoard.buildText.color = Color.green;
                ToggleBoard.buildText.text = "Can build.";
            }
            else
            {
                ToggleBoard.buildText.color = Color.red;
                ToggleBoard.buildText.text = "Can not build.";
            }
        }
    }
}
