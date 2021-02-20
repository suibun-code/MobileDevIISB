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
    [Header("Audio")]
    public AudioClip SpendCurrencySFX;
    public AudioClip UpgradeTowerSFX;
    public AudioClip DestroyedSFX;
    

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
            TakeDamage(10.0f);
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


            // play damage sfx
            // AudioSource.PlayClipAtPoint(DestroyedSFX, transform.position);


            // set health value 
            Health -= damage;
            
            // set bar scale
            HealthBarContainer.transform.localScale = new Vector3(
                HealthBarContainer.transform.localScale.x,
                HealthBarContainer.transform.localScale.y,
                1f * (Health / 100f)
            );

            // update the new health value to the indicator
            HealthBarIndicator.GetComponent<TextMesh>().text = Health.ToString();


        }
        else
        {
            // Player Dies and goto the result screen
        }

    }




}
