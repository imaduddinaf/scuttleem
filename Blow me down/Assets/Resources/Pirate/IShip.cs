using UnityEngine;
using System.Collections;

public interface IShip 
{
    float Speed { get; set; }
    string ShipName { get; }
    string ShipDescription { get; }
    void Init();
    void Move();
    void Die();
    bool IsDestroyed();
    int MoneyWorth();
    int BulletDrop();
    void Destroy();
    void SetSpawner(PirateSpawnerController spawner);
    void GetDamage(int damage);
    void KillThePlayer();
    void SpawnBulletDropAmount();
}
