using UnityEngine;

public class Movement : MonoBehaviour
{
    // Player movement speed
    public float moveSpeed = 5f;

    void Update()
    {
        // Capture player input for movement
        float horizontalInput = Input.GetAxis("Horizantal");
        float verticalInput = Input.GetAxis("Vert");

        // Log input values (for debugging)
        Debug.Log("Horizontal Input: " + horizontalInput);
        Debug.Log("Vertical Input: " + verticalInput);

        // Move the player based on input
        Vector3 moveDir = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
