using System;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

public class Jump : MonoBehaviour
{
    [SerializeField] private UnityEvent onJump;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private float jumpForce;

    [SerializeField] private bool isGrounded;

    public void Jumper(CallbackContext context)
    {
        if (isGrounded)
        {
            onJump?.Invoke();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Piso");
            isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("No piso");
            isGrounded = false;
        }
    }
}
