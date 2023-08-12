using UnityEngine;

namespace Ability
{
    public class AbilityHolder : MonoBehaviour
    {
        public Ability ability;
        public KeyCode key;
        private float _activeTime;
        private float _cooldownTime;

        private AbilityState _state = AbilityState.Ready;

        public void StateTransition()
        {
            switch (_state)
            {
                case AbilityState.Ready:
                    if (Input.GetKeyDown(key))
                    {
                        ability.Active();
                        _state = AbilityState.Active;
                        _activeTime = ability.activeTime;
                    }

                    break;
                case AbilityState.Active:
                    if (_activeTime > 0)
                    {
                        _activeTime -= Time.deltaTime;
                    }
                    else
                    {
                        ability.DeActive();
                        _state = AbilityState.Cooldown;
                        _cooldownTime = ability.cooldownTime;
                    }

                    break;
                case AbilityState.Cooldown:
                    if (_cooldownTime > 0)
                        _cooldownTime -= Time.deltaTime;
                    else
                        _state = AbilityState.Ready;

                    break;
            }
        }

        private enum AbilityState
        {
            Ready,
            Active,
            Cooldown
        }
    }
}