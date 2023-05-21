using System;
using UnityEngine;
using UnityEngine.Events;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

[Serializable] public class UnityFloatEvent : UnityEvent<float> { }

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector2 inputValue;
    [SerializeField] private Vector2 smoothInput;
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private UnityFloatEvent onMoved;

    public void Move(CallbackContext context)
    {
        inputValue = context.ReadValue<Vector2>();
    }
    public void Update()
    {
        smoothInput = Vector2.Lerp(smoothInput, inputValue, Time.deltaTime * 10);
        Vector3 forwardVector = Vector3.ProjectOnPlane(cameraTransform.forward, transform.up);
        Vector3 rightVector = cameraTransform.right;
        Vector3 motionVector = forwardVector * smoothInput.y + rightVector * smoothInput.x;
        transform.Translate(motionVector * (Time.deltaTime * speed), Space.World);

        onMoved?.Invoke(smoothInput.magnitude);
        if (motionVector.magnitude > 0.01f)
            transform.forward = motionVector.normalized;
    }
}
