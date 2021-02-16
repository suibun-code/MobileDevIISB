using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This script adds resources to the player when attached gameobject destroy
public class OnEnemyDestroy : MonoBehaviour
{

    GameObject player;
    PlayerScript ps;

    //Audio
    [Header("Audio")]
    public AudioClip DestroyedSFX;
    public AudioClip EnemyHitWithArrowSFX;
    public AudioClip EnemyHitWithMagicSFX;
    public AudioClip EnemyHitWithPunchSFX;
    public AudioClip EnemyHitWithSwordSFX;

    private void Start()
    {
        // Get player reference
        player = GameObject.FindGameObjectWithTag("Player");
        ps = player.GetComponent<PlayerScript>();
    }


    
    private void OnDestroy()
    {
        // when enemy gets destroyed, add resource to player script
        // ps.GainResource_Gold(10);
        // ps.GainResource_Diamond(-10);
        // ps.GainResource_Bricks(10);

       
        //AudioSource.PlayClipAtPoint(DestroyedSFX, transform.position);
    }
}
