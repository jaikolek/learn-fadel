using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Learn.Three
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private AssetReferenceT<GameObject> btnSkillPrefab;
        [SerializeField] private RectTransform rctTrfParent;
        
        [SerializeField] private List<ButtonSkill> btnSkillList = new List<ButtonSkill>();

        public static UIManager Instance;

        private IUseSkill player;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        public void SetPlayer(IUseSkill player)
        {
            this.player = player;
        }

        public void OnSkillChanged(List<Skill> skillList)
        {
            ReleaseAll(); // release

            foreach (Skill skill in skillList)
            {
                Init(skill, () =>
                {
                    player.UseSkill(skill.GetName());
                });
            }
        }

        public async void Init(Skill skill, UnityAction OnUse)
        {
            ButtonSkill btnSkill = GetButtonSkill();

            if (btnSkill == null)
            {
                if (btnSkillPrefab.Asset == null) await LoadAssetAsync();

                GameObject generatedBtn = Instantiate<GameObject>(btnSkillPrefab.Asset as GameObject, rctTrfParent);

                if (generatedBtn.TryGetComponent(out ButtonSkill generatedBtnSkill))
                {
                    generatedBtnSkill.name = "button " + skill.GetName();

                    generatedBtnSkill.SkillName = skill.GetName();
                    generatedBtnSkill.AddListener(OnUse);
                    generatedBtnSkill.UpdateVisual(false);

                    skill.OnUse += generatedBtnSkill.OnUse;
                    skill.OnCooldown += generatedBtnSkill.OnCooldown;
                    skill.OnSkillReady += generatedBtnSkill.OnSkillReady;

                    btnSkillList.Add(generatedBtnSkill);
                }
            }
            else
            {
                btnSkill.name = "button " + skill.GetName();

                btnSkill.SkillName = skill.GetName();
                btnSkill.AddListener(OnUse);
                btnSkill.UpdateVisual(false);

                skill.OnUse += btnSkill.OnUse;
                skill.OnCooldown += btnSkill.OnCooldown;
                skill.OnSkillReady += btnSkill.OnSkillReady;

                btnSkill.gameObject.SetActive(true);
            }
        }

        private async Task LoadAssetAsync()
        {
            try
            {
                AsyncOperationHandle<GameObject> handle = btnSkillPrefab.LoadAssetAsync();
                await handle.Task;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void ReleaseAll()
        {
            foreach (ButtonSkill btnSkill in btnSkillList)
            {
                btnSkill.Release();
            }
        }

        public ButtonSkill GetButtonSkill()
        {
            foreach (ButtonSkill btnSkill in btnSkillList)
            {
                if (!btnSkill.gameObject.activeInHierarchy)
                {
                    return btnSkill;
                }
            }

            return null;
        }
    }
}
