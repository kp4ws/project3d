using UnityEngine;
using Kp4wsGames.Input;
using Kp4wsGames.Weapons;
using Kp4wsGames.Interactables;

namespace Kp4wsGames.Entities.Player
{
    //This class essentially acts as the Player
	public class PlayerController : MonoBehaviour
	{
        //Properties are usually PascalCase
        [field: SerializeField] public InputReader InputReader { get; set; }
        [field: SerializeField] public CharacterController Controller { get; set; }
        [field: SerializeField] public PlayerBrain Modifiers { get; set; }
        //[field: SerializeField] public Animator Animator { get; set; }
        public Transform MainCameraTransform { get; private set; }

        private Interactable currentInteractable;

        private void Start()
        {
            MainCameraTransform = Camera.main.transform;
        }

        private void Update()
        {
            //CheckInteractables();
            MovePlayer();
        }

        private void LateUpdate()
        {
            CameraRotation();
        }

        private void MovePlayer()
        {
            Vector3 movement = CalculateMovement();
            //Quaternion rotation = CalculateRotation();
            Controller.Move(movement * Modifiers.MoveSpeed * Time.deltaTime);

            if (InputReader.MovementValue == Vector2.zero)
            {
                //Set walking animation to 0
                return;
            }
        }

        public Vector3 CalculateMovement()
        {
            Vector3 forward = MainCameraTransform.forward;
            Vector3 right = MainCameraTransform.right;

            forward.y = 0f;
            right.y = 0f;

            forward.Normalize();
            right.Normalize();

            //TODO Figure out how this calculation works
            return forward * InputReader.MovementValue.y + right * InputReader.MovementValue.x;
        }

        private void CameraRotation()
        {
            //// if there is an input
            //if (_input.look.sqrMagnitude >= _threshold)
            //{
            //    //Don't multiply mouse input by Time.deltaTime
            //    float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

            //    _cinemachineTargetPitch += _input.look.y * RotationSpeed * deltaTimeMultiplier;
            //    _rotationVelocity = _input.look.x * RotationSpeed * deltaTimeMultiplier;

            //    // clamp our pitch rotation
            //    _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            //    // Update Cinemachine camera target pitch
            //    CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            //    // rotate the player left and right
            //    transform.Rotate(Vector3.up * _rotationVelocity);
            //}
        }

        //public void CheckInteractables()
        //{
        //    RaycastHit hit;

        //    if (Physics.Raycast(transform.position, MainCameraTransform.transform.forward, out hit, Modifiers.InteractableDistance))
        //    {
        //       //Debug.DrawRay(transform.position, MainCameraTransform.transform.forward * hit.distance, Color.yellow);
        //        Interactable interactable = hit.collider.gameObject.GetComponent<Interactable>();

        //        if (interactable != null)
        //        {
        //            if(currentInteractable != null)
        //            {
        //                currentInteractable.OnEndLook();
        //            }
        //            currentInteractable = interactable;
        //            currentInteractable.OnStartLook();
        //        }
        //        else
        //        {
        //            if (currentInteractable != null)
        //            {
        //                currentInteractable.OnEndLook();
        //                currentInteractable = null;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        //TODO remove repetitive code
        //        if (currentInteractable != null)
        //        {
        //            currentInteractable.OnEndLook();
        //            currentInteractable = null;
        //        }
        //    }
        //}

        //public void Interact()
        //{
        //    currentInteractable?.OnInteract();
        //}
    }
}