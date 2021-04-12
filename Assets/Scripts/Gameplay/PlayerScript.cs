using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public AudioManagerScript ams;
    public AudioClip playerDamage;
    public AudioClip Destroyed;

    EnemyPooler enemyPool;

    void Start()
    {
        // set health to 100
        Health = 100;

        // set numeric health indicator's value to health value
        HealthBarIndicator.GetComponent<TextMesh>().text = Health.ToString();

        //DiamondResourcesCount = 0;
        //GoldResourcesCount = 0;
        //BricksResourcesCount = 0;

        enemyPool = EnemyPooler.Instance;
    }

    void Update()
    {
        //Go to Game Over Screen
        if (Health <= 0)
        {
            // when hp under 0, move to lose state
            GameManager.Instance.isWin = false;
            GameManager.Instance.ChangeScene("GameResult");

            //StartCoroutine(LoadAsynSceneCoroutine());
        }

        GameManager.Instance.pyramidHP = Health;
    }

    [Header("Scene")]
    public string SceneName;
    private float time;

    // Coroutine to go to the Game Over Screen
    IEnumerator LoadAsynSceneCoroutine()
    {
        // if loading already finish, wait until 5 second (too short).
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;


        while (!operation.isDone)
        {

            time += Time.deltaTime;

            //loadingBar.fillAmount = time / 3f;

            if (time > 2)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(playerDamage, transform.position);
            ams.PlayerDamageS.Play();
            

            Destroy(other.gameObject);

            //EnemyPooler.poolDictionary[Enemy].Enqueue(objectToSpawn);

            TakeDamage(10.0f);
            // print("Take 10 damage");
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
        AudioSource.PlayClipAtPoint(playerDamage, transform.position);
        ams.PlayerDamageS.Play();
        Debug.Log("WHACK");

        if (Health > 0)
        {
            //audio
            ams.PlayerDamageS.Play();
            AudioSource.PlayClipAtPoint(playerDamage, transform.position);
            Debug.Log("BOOM");

            // set health value 
            Health -= damage;

            // set bar scale
            HealthBarContainer.transform.localScale = new Vector3(
                HealthBarContainer.transform.localScale.x,
                HealthBarContainer.transform.localScale.y,
                1f * (Health / 100f)
            );

            // change health bar color
            if (Health <= 20)
            {
                gameObject.transform.Find("HealthBarContainer").gameObject.transform.Find("Container").gameObject.transform.Find("GreenBar").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                HealthBarIndicator.GetComponent<TextMesh>().color = Color.red;
            }
            else if (Health > 20 && Health <= 50)
            {
                gameObject.transform.Find("HealthBarContainer").gameObject.transform.Find("Container").gameObject.transform.Find("GreenBar").GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                HealthBarIndicator.GetComponent<TextMesh>().color = Color.yellow;

            }



            // update the new health value to the indicator
            HealthBarIndicator.GetComponent<TextMesh>().text = Health.ToString();

            // update the new health value to the indicator
            HealthBarIndicator.GetComponent<TextMesh>().text = Health.ToString();

            if (Health <= 0)
            {
                //audio
                ams.DestroyedS.Play();
                AudioSource.PlayClipAtPoint(Destroyed, transform.position);
                Debug.Log("Player DESTROYED!");
            }
            else
            {
                

                // Player Dies and goto the result screen
            }
        }
    }
}
