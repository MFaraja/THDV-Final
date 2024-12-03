using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    private Rigidbody rigidbody;

    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        // Only allow forward/backward movement based on a fixed direction (e.g., forward in the world).
        Vector3 forwardDirection = transform.forward;
        forwardDirection.y = 0; // Ensure the movement is only on the XZ plane
        forwardDirection.Normalize();

        Vector3 targetVelocity = forwardDirection * (Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement while preserving the Y component of the velocity.
        rigidbody.velocity = new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.z);
    }
}
