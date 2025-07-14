using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    [CreateAssetMenu(fileName = "Scout Skill", menuName = "Skill/Scout")]
    public class SkillScout : Skill
    {
        [Header("Skill Scout")]
        [SerializeField] private string abilityName;
        [SerializeField] private float neededSP;

        public override void Use()
        {
            base.Use();

            Debug.Log($"Abilty {abilityName} with sp consumtion {neededSP}");
        }
    }
}
