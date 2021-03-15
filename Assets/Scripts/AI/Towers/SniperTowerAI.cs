using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class SniperTowerAI : MonoBehaviour
{
    [SerializeField] private GameObject currentTarget;
    public Transform sphereTransform;

    private SphereCollider colliderRange;

    public int damage;
    public float shotCoolDown;

    private float timer;
    private LineRenderer lineRender;

    //Audio
    [Header("Audio")]
    public AudioClip ShootingMagicSFX;
    public AudioClip ShootingArrowSFX;
    public AudioClip MeleeSwordSwingSFX;

    void Awake()
    {
        colliderRange = GetComponent<SphereCollider>();
        lineRender = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (currentTarget == null)
            Target();

        if (currentTarget != null)
            FollowTarget();
        else
            WanderAim();

            if (timer >= shotCoolDown)
            if (currentTarget != null)
            {
                Shoot();
                timer = 0;
            }
    }

    private void Target()
    {
        Collider[] colliders = Physics.OverlapSphere(colliderRange.transform.position - (colliderRange.center * transform.localScale.x), colliderRange.radius * transform.localScale.x);
        float minSqrDistance = Mathf.Infinity;

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Enemy")
            {
                float sqrDistanceToCenter = ((colliderRange.transform.position - (colliderRange.center * transform.localScale.x)) - colliders[i].transform.position).sqrMagnitude;

                if (sqrDistanceToCenter < minSqrDistance)
                {
                    minSqrDistance = sqrDistanceToCenter;
                    currentTarget = colliders[i].gameObject;
                }
            }
        }
    }

    private void FollowTarget()
    {
        Vector3 targetDir = currentTarget.transform.position - transform.position;
        sphereTransform.forward = targetDir;
        RaycastHit hit;

        if (Physics.Raycast(sphereTransform.forward, transform.forward, out hit))
            if (hit.collider)
                lineRender.SetPosition(1, new Vector3(0, 0, hit.distance));

        Debug.DrawLine(sphereTransform.transform.position, currentTarget.transform.position, Color.red);
    }

    private void WanderAim()
    {
        sphereTransform.Rotate(0f, 35 * Time.deltaTime, 0f);
    }

    private void Shoot()
    {
        //audio
        AudioSource.PlayClipAtPoint(ShootingArrowSFX, transform.position);

        Debug.Log("Shoot");

        currentTarget.transform.Find("EnemyHealthBar").GetComponent<EnemyHealth>().TakeDamage(damage);
    }
}
