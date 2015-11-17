using UnityEngine;
using System.Collections;

public interface ICannon 
{
    void Init();
    void Attack();
    void Upgrade();
    void LoadBullet();
    void DestroyBullet(GameObject obj);
    void Destroy();
}
