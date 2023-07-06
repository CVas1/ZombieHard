using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    [SerializeField] private Zombie zombieData;

    private int speed;
    private Vector3 distance;
    private void Start()
    {
        speed = zombieData.zombieSO.zombieSpeed;
    }


    private void Update()
    {
        
        distance = zombieData.player.transform.position - transform.position;
        transform.Translate(distance.normalized * Time.deltaTime * speed);
    }
}
