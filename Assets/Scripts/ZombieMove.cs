using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    [SerializeField] private Zombie zombieData;

    private int speed;
    private float distance;
    private Vector3 direction;
    private float angle;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        speed = zombieData.zombieSO.zombieSpeed;
    }


    private void Update()
    {
        distance = Vector3.Distance(zombieData.target.transform.position, transform.position);
        /*if (distance > 1) {
            Vector3 pos = Vector3.MoveTowards(transform.position, zombieData.target.transform.position, speed * Time.deltaTime);
            rb.MovePosition(pos);
            transform.LookAt(zombieData.target.transform);
        }*/
    }
}
