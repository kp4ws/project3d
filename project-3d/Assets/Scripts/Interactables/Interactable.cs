using Kp4wsGames.Events;
using UnityEngine;

namespace Kp4wsGames.Interactables
{
    public class Interactable : MonoBehaviour
    {
        [SerializeField] private GameObject tooltipUI = null;
        [SerializeField] private GameEvent Event_Interact;

        public void OnStartLook()
        {
            ToggleTooltip(true);
        }

        public void OnInteract()
        {
            Event_Interact?.Raise();
        }

        public void OnEndLook()
        {
            ToggleTooltip(false);
        }

        private void ToggleTooltip(bool show)
        {
            if (tooltipUI == null)
                return;

            tooltipUI.SetActive(show);
        }
    }
}