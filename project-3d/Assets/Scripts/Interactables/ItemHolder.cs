using Kp4wsGames.Weapons;
using UnityEngine;

namespace Kp4wsGames.Interactables
{
	public class ItemHolder : MonoBehaviour
	{
        [field: SerializeField] public Transform HoldingPosition { get; set; }
        public GameObject CurrentItem;

        private const string itemName = "Item";

        public void Spawn(GameObject itemPrefab)
        {
            if (itemPrefab == null)
                return;

            if (CurrentItem != null)
                DestroyOldItem(HoldingPosition);

            GameObject heldItem = Instantiate(itemPrefab, HoldingPosition);
            heldItem.gameObject.name = itemName;
            CurrentItem = heldItem;
        }

        private void DestroyOldItem(Transform ItemHolder)
        {
            Transform oldItem = ItemHolder.Find(itemName);
            if (oldItem == null) return;

            oldItem.name = "DESTROYING"; //Prevents frame issue if immediately picking up new weapon (differentiates between the name)
            Destroy(oldItem.gameObject);
        }

        //TODO
        public void DropItem(Transform itemHolder)
        {

        }
    }
}