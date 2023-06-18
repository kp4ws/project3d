using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public void OnFire(InputValue value)
    {
        if (value.isPressed)
            Debug.Log("shot fired");
    }
}
