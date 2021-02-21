using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerScript : MonoBehaviour
{


    // Parameters
    float Health;
    //public int DiamondResourcesCount;
    //public int GoldResourcesCount;
    //public int BricksResourcesCount;


    // Health bar object
    public GameObject HealthBarContainer;
    public GameObject HealthBarIndicator;


    // Text UI references
    //public Text DiamondCountUI;
    //public Text GoldCountUI;
    //public Text BricksCountUI;

    //Audio
    //[Header("Audio")]
    //public AudioClip SpendCurrencySFX;
    //public AudioClip UpgradeTowerSFX;
    //public AudioClip DestroyedSFX;
    //public AudioClip TakeDamageSFX;
        

    void Start()
    {
        // set health to 100
        Health = 100;

        // set numeric health indicator's value to health value
        HealthBarIndicator.GetComponent<TextMesh>().text = Health.ToString();

        //DiamondResourcesCount = 0;
        //GoldResourcesCount = 0;
        //BricksResourcesCount = 0;


    }

    void Update()
    {
        
    }



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
           

            Destroy(other.gameObject);
//<<<<<<< Updated upstream
            TakeDamage(10.0f);
//=======
//<<<<<<< HEAD
            TakeDamage(20.0f);
            
//=======
            TakeDamage(10.0f);
//>>>>>>> fca8f2be300f9f05cb5714e6dd52be943355487f
//>>>>>>> Stashed changes
            print("Take 10 damage");

            
        }
        
    }

    private void OnCollisionStay(Collision other)
    {

    }



    // Method for manipulating player resource
    // Also updates the count to UI
    // gain can be positive for gain minus for loss
    //public void GainResource_Diamond(int gain)
    //{
    //    DiamondResourcesCount += gain;
    //    DiamondCountUI.text = DiamondResourcesCount.ToString();
    //}

    //public void GainResource_Gold(int gain)
    //{
    //    GoldResourcesCount += gain;
    //    GoldCountUI.text = GoldResourcesCount.ToString();
    //}

    //public void GainResource_Bricks(int gain)
    //{
    //    BricksResourcesCount += gain; 
    //    BricksCountUI.text = BricksResourcesCount.ToString();
    //}

    

    // Apply damage to player
    // Also updating the healthbar and trigger death event
    void TakeDamage(float damage)
    {
        

        if (Health > 0)
        {
//<<<<<<< Updated upstream

//=======
//<<<<<<< HEAD
            //audio
           // AudioSource.PlayClipAtPoint(TakeDamageSFX, transform.position);
           // Debug.Log("BOOM");

           // print("Take damage");

//=======

//>>>>>>> Stashed changes

            // play damage sfx
            // AudioSource.PlayClipAtPoint(DestroyedSFX, transform.position);
//>>>>>>> fca8f2be300f9f05cb5714e6dd52be943355487f


            // set health value 
            Health -= damage;
            
            // set bar scale
            HealthBarContainer.transform.localScale = new Vector3(
                HealthBarContainer.transform.localScale.x,
                HealthBarContainer.transform.localScale.y,
                1f * (Health / 100f)
            );
//<<<<<<< Updated upstream

            // update the new health value to the indicator
            HealthBarIndicator.GetComponent<TextMesh>().text = Health.ToString();
//=======
//>>>>>>> Stashed changes

            // update the new health value to the indicator
            HealthBarIndicator.GetComponent<TextMesh>().text = Health.ToString();
           

        }
        else
        {
//<<<<<<< Updated upstream
            // Player Dies and goto the result screen
//=======
//<<<<<<< HEAD
            // Player Dies
            //audio
            //AudioSource.PlayClipAtPoint(DestroyedSFX, transform.position);
//=======
            // Player Dies and goto the result screen
//>>>>>>> fca8f2be300f9f05cb5714e6dd52be943355487f
//>>>>>>> Stashed changes
        }

    }




}
