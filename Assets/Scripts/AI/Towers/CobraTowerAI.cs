using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class CobraTowerAI : MonoBehaviour
{
    private List<GameObject> currentTargets = new List<GameObject>(10);
    public Transform sphereTransform;

    private SphereCollider colliderRange;

    public int damage;
    public float shotCoolDown;

    private float timer;
    private LineRenderer lineRender;

  
    //audio
    public AudioManagerScript ams;
    public AudioClip ShootMagic;
    void Awake()
    {
        colliderRange = GetComponent<SphereCollider>();
        lineRender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Target();

        //if (currentTargets.Count != 0)
        //FollowTarget();
        //else
        //    WanderAim();

        if (timer >= shotCoolDown)
        {
            Target();
            timer = 0;
        }
    }

    void OnCollisionEnter()
    {

    }

    private void Target()
    {
        Collider[] colliders = Physics.OverlapSphere(colliderRange.transform.position - (colliderRange.center * transform.localScale.x), colliderRange.radius * transform.localScale.x);
        float minSqrDistance = Mathf.Infinity;

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Enemy")
            {
                if (!currentTargets.Contains(colliders[i].gameObject))
                    currentTargets.Add(colliders[i].gameObject);
            }
        }

        if (currentTargets.Count != 0)
            Shoot();
    }

    //private void FollowTarget()
    //{
    //    Vector3 targetDir = currentTargets[0].transform.position - transform.position;
    //    sphereTransform.forward = targetDir;
    //    RaycastHit hit;

    //    if (Physics.Raycast(sphereTransform.forward, transform.forward, out hit))
    //        if (hit.collider)
    //            lineRender.SetPosition(1, new Vector3(0, 0, hit.distance));

    //    Debug.DrawLine(sphereTransform.transform.position, currentTargets[0].transform.position, Color.red);
    //}

    private void WanderAim()
    {
        sphereTransform.Rotate(0f, 35 * Time.deltaTime, 0f);
    }

    private void Shoot()
    {
        //audio
        AudioSource.PlayClipAtPoint(ShootMagic, transform.position);
        // ams.ShootingMagicS.Play();
        Debug.Log("Shoot");
        Debug.Log(currentTargets.Count);

        for (int i = 0; i < currentTargets.Count; i++)
            if (currentTargets[i] != null)
                currentTargets[i].transform.Find("EnemyHealthBar").GetComponent<EnemyHealth>().TakeDamage(damage);

        currentTargets.Clear();
    }

    public bool EmptyList()
    {
        for (int i = 0; i < currentTargets.Count; i++)
        {
            if (currentTargets[i] != null)
                return false;
        }

        return true;
    }
}
