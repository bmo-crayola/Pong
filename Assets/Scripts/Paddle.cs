using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed = 1f;
    public float forceStrength = 10f;
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
                Vector3 force = new Vector3(0f, 0f, forceStrength);
                Rigidbody rBody = GetComponent<Rigidbody>();
                rBody.AddForce(force, ForceMode.Force);

                // transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime * 7;
            } 
            else if (Keyboard.current.sKey.isPressed)
            {
                Vector3 force = new Vector3(0f, 0f, -forceStrength);
                Rigidbody rBody = GetComponent<Rigidbody>();
                rBody.AddForce(force, ForceMode.Force);

                // transform.position += new Vector3(0f, 0f, -paddleSpeed) * Time.deltaTime * 7;
            }
        }
        else
        {
            if (Keyboard.current.oKey.isPressed)
            {
                Vector3 force = new Vector3(0f, 0f, forceStrength);
                Rigidbody rBody = GetComponent<Rigidbody>();
                rBody.AddForce(force, ForceMode.Force);

                // transform.position += new Vector3(0f, 0f, paddleSpeed) * Time.deltaTime * 7;
            } 
            else if (Keyboard.current.lKey.isPressed)
            {
                Vector3 force = new Vector3(0f, 0f, -forceStrength);
                Rigidbody rBody = GetComponent<Rigidbody>();    
                rBody.AddForce(force, ForceMode.Force);

                // transform.position += new Vector3(0f, 0f, -paddleSpeed) * Time.deltaTime * 7;
            }
        }

        // Vector3 right = Vector3.right;
        // Quaternion rotation = Quaternion.Euler(0f, 60f, 0f);
        // Vector3 rotatedVector = rotation * right;
        // Debug.DrawRay(transform.position, rotatedVector * 5f, Color.red);

    }
}
