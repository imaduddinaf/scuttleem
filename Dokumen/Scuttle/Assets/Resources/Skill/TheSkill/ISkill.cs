using UnityEngine;
using System.Collections;

public interface ISkill
{
    void Action();
    int Damage();
    Vector2 AreaOfEffect();
    void SetTarget(GameObject g);
    void Destroy();
}
