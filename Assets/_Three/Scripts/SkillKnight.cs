using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    [CreateAssetMenu(fileName = "Knight Skill", menuName = "Skill/Knight")]
    public class SkillKnight : Skill
    {
        [Header("Skill Knight")]
        [SerializeField] private string abilityName;
        [SerializeField] private float neededSP;

        public override void Use()
        {
            base.Use();

            Debug.Log($"Abilty {abilityName} with sp consumtion {neededSP}");
        }
    }
}
