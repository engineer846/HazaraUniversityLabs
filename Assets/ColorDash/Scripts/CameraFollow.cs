using UnityEngine;

namespace ColorDash
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;  // Reference to the player's transform
        public float followDistance = 5f;  // Distance between the camera and the player
        public float heightOffset = 2f;    // Height offset from the player
        public float smoothSpeed = 0.125f;  // Smoothing factor for camera movement

        // LateUpdate is called after all Update functions have been called
        void LateUpdate()
        {
            // Calculate the desired position of the camera based on the player's position and the offset
            Vector3 targetPosition = target.position - target.forward * followDistance + Vector3.up * heightOffset;

            // Use Lerp to smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            // Update the camera's position
            transform.position = smoothedPosition;

            // Make the camera look at the player
            //transform.LookAt(target);
        }
    }
}

