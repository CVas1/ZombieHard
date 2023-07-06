using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform gunTip;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 40f;

    private void Start()
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => Shoot())
            .AddTo(this); // Add subscription to the Gun class's composite disposable to automatically unsubscribe when the Gun object is destroyed
    }

    private void Shoot()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 50))
        {
            // Handle raycast hit
            Debug.Log("Raycast hit object: " + hit.collider.gameObject.name);

            // Example: If the hit object has a Rigidbody component, apply a force
            Zombie zombie = hit.collider.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.Die();
            }
        }


        /*
        GameObject newBullet = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
        Rigidbody bulletRigidbody = newBullet.GetComponent<Rigidbody>();
        // Bullet bullet= newBullet.GetComponent<Bullet>();
        bulletRigidbody.velocity = newBullet.transform.forward * bulletSpeed;

        Observable.Timer(TimeSpan.FromSeconds(10))
        .Subscribe(_ => Destroy(newBullet))
        .AddTo(newBullet);
        */
    }
}

/*
 * Bullet bullet = Bullet(bulletPrefab, gunTip.position, transform.rotation);

GameObject bullet = Instantiate(bulletPrefab, gunTip.position, transform.rotation);

Transform bulletTransform = bullet.GetComponent<Transform>();

bulletTransform.position += transform.forward * bulletSpeed * Time.deltaTime;
*/