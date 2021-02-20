using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{

    private GameObject currentTarget;
    public Transform shot;
    public Transform Sphere;

    public float distance;
    public float damage;
    public float turnSpeed;
    public float shotCoolDown;

    public bool showRange;
    private float timer;

    //Audio
    [Header("Audio")]
    public AudioClip ShootingMagicSFX;
    public AudioClip ShootingArrowSFX;
    public AudioClip MeleeSwordSwingSFX;
    

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = GameObject.FindWithTag("Enemy");
        InvokeRepeating("Target", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
       if(currentTarget != null)
        {
            FollowTarget();
            
        }

        timer += Time.deltaTime;
        if (timer>= shotCoolDown)
        {
            if(currentTarget != null)
            {
                timer = 0;
                Shoot();

                
            }
        }
    }

    private void Target()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, distance);
        float distAway = Mathf.Infinity;
        for (int i = 0; i < colls.Length; i++)
        {
             if (colls [i].tag == "Enemy")
            {
                float d = Vector3.Distance(transform.position, colls[i].transform.position);

                if (d < distance)
                {
                    currentTarget = colls[i].gameObject;
                    distAway = distance;
                }
            }
        }
    }

    private void FollowTarget()
    {
        Vector3 targetDir = currentTarget.transform.position - transform.position;
        Sphere.forward = targetDir;
    }

    private void Shoot()
    {
        Debug.Log("shot");

        //audio
        //AudioSource.PlayClipAtPoint(ShootingArrowSFX, transform.position);
        Debug.Log("BANG");
        //AudioSource.PlayClipAtPoint(ShootingMagicSFX, transform.position);
    }

    private void OnDrawGizmos()
    {
        if (showRange)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, distance);
        }
    }
}
