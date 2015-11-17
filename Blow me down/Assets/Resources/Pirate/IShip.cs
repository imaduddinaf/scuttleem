using UnityEngine;
using System.Collections;

public interface IShip 
{
    void Init();
    void Move();
    void Die();
    bool IsDestroyed();
    int MoneyWorth();
    void Destroy();
    void SetSpawner(PirateSpawnerController spawner);
    void GetDamage(int damage);
}
