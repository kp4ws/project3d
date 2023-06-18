using Kp4wsGames.Entities.Player;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Kp4wsGames.Weapons
{
    public class Weapon : MonoBehaviour
    {
        [Header("Weapon Stats")]
        [SerializeField] private WeaponStats stats;


        //[field: SerializeField] public CamShake _CamShake { get; set; }
        //[field: SerializeField] public float CamShakeMagnitude { get; set; }
        //[field: SerializeField] public float CamShakeDuration { get; set; }
        [field: Header("Weapon References")]
        [field: SerializeField] public Transform WeaponMuzzle { get; set; }
        [field: SerializeField] public GameObject MuzzleFlash { get; set; }
        [field: SerializeField] public GameObject BulletHoleGraphic { get; set; }
        [field: SerializeField] public TextMeshProUGUI BulletCountText { get; set; }
        [field: SerializeField] public LayerMask WhatIsEnemy { get; set; }

        private bool isShooting = false;
        private bool isReloading = false;
        private int remainingBullets;
        private int ammoUsed = 0;

        private float nextTimeToFire = 0;

        private void PerformReload()
        {
            isReloading = false;
            ammoUsed += stats.MagazineSize - remainingBullets;
            Debug.Log($"ammo: {stats.AmountOfAmmo}, used: {ammoUsed}");
            ResetWeapon();
        }

        public void OnReload()
        {
            isReloading = true;
            Invoke("PerformReload", stats.ReloadTime);
        }

        public void OnShootPressed()
        {
            isShooting = true;
        }

        public void OnShootReleased()
        {
            isShooting = false;
        }

        private void Awake()
        {
            ResetWeapon();
        }

        private void UpdateBulletCountUI()
        {
            BulletCountText.SetText($"{remainingBullets} / {stats.MagazineSize}");
        }

        private void Update()
        {
            if(CanShoot())
            {
                PerformShot();
                nextTimeToFire = Time.time + 1f / stats.TimeBetweenShooting;
            }
        }

        private void ResetWeapon()
        {
            //TODO If reloading weapon takes more than remaining bullets, then only reload the remaining bullets
            remainingBullets = stats.MagazineSize;
            UpdateBulletCountUI();
        }

        private void PerformShot()
        {
            //TODO figure out more efficient way of doing this?
            GameObject muzzleFlash = Instantiate(MuzzleFlash, WeaponMuzzle.position, WeaponMuzzle.rotation);
            Destroy(muzzleFlash, 0.1f);

            RaycastHit hit;
            if (Physics.Raycast(WeaponMuzzle.position, WeaponMuzzle.forward, out hit, stats.Range))
            {
                //Debug.Log(hit.collider.gameObject.name);


                //TODO bullet hit graphic based on the objects normals
                //GameObject hitParticles = Instantiate(BulletHoleGraphic, hit.point, Quaternion.FromToRotation(Vector3.up, reflectVec));
                //Destroy(hitParticles, 5f);


                if(hit.collider.gameObject.GetComponent<Rigidbody>())
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().AddForce(WeaponMuzzle.forward * 15);
                }
            }

            if (!stats.IsAutomatic)
                isShooting = false;

            remainingBullets-= stats.BulletsPerShot;

            //TODO: Is there a better way of clamping this value?
            if (remainingBullets < 0)
                remainingBullets = 0;

            UpdateBulletCountUI();
        }

        private bool CanShoot()
        {
            //Add any necessary checks here for whether the weapon can shoot or not (reloading, out of bullets, etc)
            bool canShoot = isShooting && remainingBullets > 0 && ammoUsed < stats.AmountOfAmmo && Time.time >= nextTimeToFire &&!isReloading;
            return canShoot;
        }
    }
}
