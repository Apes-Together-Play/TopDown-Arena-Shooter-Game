using System;
using UnityEngine;

namespace Ability
{
    public class AbilityHolder : MonoBehaviour
    {
        [SerializeField] private Ability ability;
        private float _cooldownTime;
        private float _acviteTime;
        
        [SerializeField] private KeyCode key;
        
        enum AbilityState
        {
            ready,
            active,
            cooldown
        }


        private AbilityState _state = AbilityState.ready;

        private void Update()
        {
            switch (_state)
            {
                case AbilityState.ready:
                    if (Input.GetKeyDown(key))
                    {
                        
                        ability.Active(gameObject);
                        _state = AbilityState.active;
                        _acviteTime = ability.activeTime;
                    }
                    
                    break;
                case AbilityState.active:
                    if (_acviteTime > 0)
                    {
                        _acviteTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.DeActive(gameObject);
                        _state = AbilityState.cooldown;
                        _cooldownTime = ability.cooldownTime;
                    }

                    break;
                case AbilityState.cooldown:
                    if (_cooldownTime > 0)
                    {
                        _cooldownTime -= Time.deltaTime;
                    }
                    else
                    {
                        _state = AbilityState.ready;
                    }

                    break;
                    
            }
        }
    }
}
