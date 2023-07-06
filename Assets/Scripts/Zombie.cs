using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public ZombieSO zombieSO;
    private int currentHealth;
    public SpawnZombies spawnZombiesSC;
    [SerializeField] public GameObject player;

    private void Start()
    {
        spawnZombiesSC = GameObject.FindWithTag("GameMaster").GetComponent<SpawnZombies>();
        player = GameObject.FindWithTag("Player");
        currentHealth = zombieSO.zombieHealth;
        Observable.EveryUpdate().Where(_ => currentHealth <= 0).Subscribe(_ => Die());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        zombieSO.zombieHealth -= damage;
    }

    public void Die()
    {
        spawnZombiesSC.ZombieCountDecrease();
        print("hi");
        Destroy(gameObject);
    }
}
