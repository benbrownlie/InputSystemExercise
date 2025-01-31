﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawnerBehaviour : MonoBehaviour
{
    [Tooltip("A reference to the game object that the emitter will spawn. Must have BulletBehaviour attached to it.")]
    [SerializeField]
    private GameObject _bullet;
    [SerializeField]
    private float _bulletSpeed;
    [SerializeField]
    private GameObject _owner;

    /// <summary>
    /// Spawns a bullet and applies the given force.
    /// </summary>
    /// <param name="force"></param>
    public void Fire()
    {
        Vector3 force = transform.forward * _bulletSpeed;
        //Spawn a new bullet
        GameObject firedBullet = Instantiate(_bullet, transform.position, transform.rotation);
        //Get a reference to the attached bullet script
        BulletBehaviour bulletScript = firedBullet.GetComponent<BulletBehaviour>();

        bulletScript.Owner = _owner;

        //If the script isn't null, apply a force to its rigidbody
        if (bulletScript)
            bulletScript.Rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
