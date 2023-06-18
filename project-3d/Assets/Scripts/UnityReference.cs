using UnityEngine;

namespace _default
{
    public class UnityReference : MonoBehaviour
    {   /////////////////
        //Initialization
        /////////////////
        /// <summary>
        /// 
        /// Gets called when a scene starts
        /// 
        /// 
        /// </summary>
        private void Awake() { }

        /// <summary>
        /// 
        /// Gets called when a scene starts
        /// 
        /// 
        /// 
        /// </summary>
        private void OnEnable() { }

        /// <summary>
        /// 
        /// </summary>
        private void Reset() { }

        /// <summary>
        /// 
        /// </summary>
        private void Start() { }



        //////////
        //Physics
        /////////
        
        /// <summary>
        /// 
        /// Typically should be used for all physics data
        /// 
        /// **Read data in update and handle data in fixed update**
        /// 
        /// 
        /// </summary>
        private void FixedUpdate() { }


        /////////////
        //Game logic
        ////////////
        
        /// <summary>
        /// 
        /// Typically used for reading inputs (but should not actually move an object, do this in fixedupdate instead)
        /// 
        /// </summary>
        private void Update() { }

        /// <summary>
        /// 
        /// </summary>
        private void LateUpdate() { }



        //////////////////
        //Decommissioning
        //////////////////
        
        /// <summary>
        /// 
        /// When behaviour becomes disabled or inactive
        /// 
        /// </summary>
        private void OnDisable() { }

        /// <summary>
        /// 
        /// This function is called after all frame updates for the last frame of the object’s existence 
        /// (the object might be destroyed in response to Object.Destroy or at the closure of a scene).
        /// 
        /// </summary>
        private void OnDestroy() { }
    }
}