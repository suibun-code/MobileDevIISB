using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    
    public GameObject HealthBarContainerRef;
    public GameObject EnemyRef;
    GameObject CamRef;





    float Health;
    


    void Start()
    {
        CamRef = GameObject.FindGameObjectWithTag("MainCamera");
        Health = 100f;
    }


    void Update()
    {

        
        // test purpose
        if(Time.frameCount % 120 == 0)
        {
            TakeDamage(10);
        }

        // Roatate healthbar if its not facing the camera
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
        }
        else
        {
            // destroy enemy
            Destroy(EnemyRef);
        }
    }


}
