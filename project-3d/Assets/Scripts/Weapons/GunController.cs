using UnityEngine;
using UnityEngine.InputSystem;
using Kp4wsGames.Entities;

namespace Kp4wsGames.Weapons
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private Camera FPSCam;
        [SerializeField] private float range = 100f;
        [SerializeField] private float damage = 45f;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private GameObject hitEffect;

        //Game Event Listener Callback
        public void OnShoot()
        {
            HandleShoot();
        }

        private void HandleShoot()
        {
            PlayMuzzleFlash();
            ProcessRaycast();
        }

        private void PlayMuzzleFlash()
        {
            muzzleFlash.Play();
        }

        private void ProcessRaycast()
        {
            RaycastHit hit;
            Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range);

            if (hit.collider != null)
            {
                CreateHitImpact(hit);
                Debug.Log("Shot: " + hit.transform.name);
                Health target = hit.collider.GetComponent<Health>();
                target?.TakeDamage(damage);
            }
        }

        private void CreateHitImpact(RaycastHit hit)
        {
            GameObject hitFx = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitFx, 1f);
        }
    }
}
