using TMPro;
using UnityEngine;

namespace Kp4wsGames.Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class WeaponStats : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; set; } = 5;
        [field: SerializeField] public bool IsAutomatic { get; set; } = false;
        [field: SerializeField] public float TimeBetweenShooting { get; set; } = 0.2f;
        [field: SerializeField] public float Spread { get; set; } = 0.2f;
        [field: SerializeField] public float Range { get; set; } = 10;
        [field: SerializeField] public float ReloadTime { get; set; } = 0.1f;
        [field: SerializeField] public int MagazineSize { get; set; } = 10;
        [field: SerializeField] public int AmountOfAmmo { get; set; } = 10;
        
        [field: SerializeField] 
        [field: Tooltip("How many bullets are fired per shot (use this to create burst weapons, etc)")] 
        public int BulletsPerShot { get; set; }
    }
}
