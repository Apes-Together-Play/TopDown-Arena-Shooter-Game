using UnityEngine;

namespace Ability
{
    public class AbilityHolder : MonoBehaviour
    {
        public Ability ability;
        private float _cooldownTime;
        private float _activeTime;
        
        public KeyCode key;
        
        enum AbilityState
        {
            ready,
            active,
            cooldown
        }


        private AbilityState _state = AbilityState.ready;

        public void StateTransition()
        {
            switch (_state)
            {
                case AbilityState.ready:
                    if (Input.GetKeyDown(key))
                    {
                        
                        ability.Active();
                        _state = AbilityState.active;
                        _activeTime = ability.activeTime;
                    }
                    
                    break;
                case AbilityState.active:
                    if (_activeTime > 0)
                    {
                        _activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.DeActive();
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
