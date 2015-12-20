using UnityEngine;
using System.Collections;

public interface ISkillController 
{
    void CooldownHandler();
    void SpawnSkill();
    void HandleDestroyedSkill(GameObject g);
    void DisableButton();
    void EnableButton();
}
