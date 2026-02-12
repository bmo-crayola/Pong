using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    float paddleSpeed = 3f;
    // float forceStrength = 10f;
    float maxTravelHeight = 5.5f;
    float minTravelHeight = -5.5f;
    public enum Side { Left, Right }

    [Header("Paddle Side Choice")]
    public Side side;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (side == Side.Left)
        {
            if (Keyboard.current.wKey.isPressed)
            {
                Vector3 newPosition = transform.position + new Vector3(0, 0, 3) * paddleSpeed * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, minTravelHeight, maxTravelHeight);

                Rigidbody rBody = GetComponent<Rigidbody>();
                rBody.linearVelocity = Vector3.zero;
                rBody.transform.position = newPosition;
            } 
            else if (Keyboard.current.sKey.isPressed)
            {
                Vector3 newPosition = transform.position + new Vector3(0, 0, -3) * paddleSpeed * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, minTravelHeight, maxTravelHeight);

                Rigidbody rBody = GetComponent<Rigidbody>();
                rBody.linearVelocity = Vector3.zero;
                rBody.transform.position = newPosition;
            }
        }
        else
        {
            if (Keyboard.current.oKey.isPressed)
            {
                Vector3 newPosition = transform.position + new Vector3(0, 0, 3) * paddleSpeed * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, minTravelHeight, maxTravelHeight);

                Rigidbody rBody = GetComponent<Rigidbody>();
                rBody.linearVelocity = Vector3.zero;
                rBody.transform.position = newPosition;
            } 
            else if (Keyboard.current.lKey.isPressed)
            {
                Vector3 newPosition = transform.position + new Vector3(0, 0, -3) * paddleSpeed * Time.deltaTime;
                newPosition.z = Mathf.Clamp(newPosition.z, minTravelHeight, maxTravelHeight);

                Rigidbody rBody = GetComponent<Rigidbody>();
                rBody.linearVelocity = Vector3.zero;
                rBody.transform.position = newPosition;
            }
        }

        // Vector3 right = Vector3.right;
        // Quaternion rotation = Quaternion.Euler(0f, 60f, 0f);
        // Vector3 rotatedVector = rotation * right;
        // Debug.DrawRay(transform.position, rotatedVector * 5f, Color.red);

    }
}
