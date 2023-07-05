using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

namespace Kp4wsGames
{
	public class WeaponZoom : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera fpsCam;
		[SerializeField] private float zoomedInAmount;
		private float regularZoomAmount;
		private bool isZoomedIn = false;

        private void Start()
        {
           regularZoomAmount = fpsCam.m_Lens.FieldOfView;
            //fpsCam.m_Lens.FieldOfView = 0;
        }

        //Game Event Listener Callback
        public void OnZoom()
        {
            HandleZoom();
        }

		private void HandleZoom()
        {
   //         isZoomedIn = !isZoomedIn;
   //         if (isZoomedIn)
   //         {
			//	fpsCam.m_Lens.FieldOfView = zoomedInAmount;
   //         }
			//else
   //         {
   //             fpsCam.m_Lens.FieldOfView = regularZoomAmount;
   //         }
        }
	}
}