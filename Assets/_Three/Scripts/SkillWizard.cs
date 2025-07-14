using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Learn.Three
{
    [CreateAssetMenu(fileName = "Wizard Skill", menuName = "Skill/Wizard")]
    public class SkillWizard : Skill
    {
        [Header("Skill Wizard")]
        [SerializeField] private string abilityName;
        [SerializeField] private float neededMP;

        public override void Use()
        {
            base.Use();

            Debug.Log($"Abilty {abilityName} with mp consumtion {neededMP}");
        }
    }
}
