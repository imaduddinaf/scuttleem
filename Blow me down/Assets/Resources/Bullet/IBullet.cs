using UnityEngine;
using System.Collections;

public interface IBullet
{
    void SetCannon(ICannon cannon);
    int Damage();
    void Shot(Vector2 direction, float speed);
    void SetDamage(int damage);
    void Die();
    void Destroy();
}
