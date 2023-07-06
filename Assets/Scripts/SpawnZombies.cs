using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UniRx;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public int zombieCount = 0;
    [SerializeField] private GameObject[] spawnLocations;
    [SerializeField] private GameObject zombie;



    void Start()
    {
        SpawnZombie();
        Observable.Interval(TimeSpan.FromSeconds(5)).Subscribe(_ => SpawnZombie());
        Observable.EveryUpdate().Where(_ => zombieCount <= 0).Subscribe(_  => SpawnZombie());

    }

    private void SpawnZombie()
    {
        Instantiate(zombie,GetRandomPositionBetweenObjects(),Quaternion.identity);
        zombieCount++;
    }

    private Vector3 GetRandomPositionBetweenObjects()
    {
        Vector3 position1 = spawnLocations[0].transform.position;
        Vector3 position2 = spawnLocations[1].transform.position;

        Vector3 randomPosition = Vector3.Lerp(position1, position2, UnityEngine.Random.Range(0f, 1f));

        return randomPosition;
    }
    public void ZombieCountDecrease()
    {
        zombieCount -= 1;
    }
}
