using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projecileParticleSystem;


    Transform target;

    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FindClosetTarget();

        AimWeapon();
    }

    private void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if(targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range) { Attack(true);  }
        else                        { Attack(false); }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projecileParticleSystem.emission;
        emissionModule.enabled = isActive;
    }
}
