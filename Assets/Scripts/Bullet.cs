using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private float  velocity = 40f;
    private Vector3 gunTip;
    private Quaternion rotation;
    private GameObject bullet;



     public Bullet( Vector3 gunTip, Quaternion rotation )
    {
         this.gunTip = gunTip; this.rotation = rotation;
         bullet = Instantiate(bulletPrefab, gunTip, rotation);
    }
    
    private void Update()
    {
        Transform bulletTransform = bullet.GetComponent<Transform>();

        bulletTransform.position += transform.forward * velocity * Time.deltaTime;
    }
}
