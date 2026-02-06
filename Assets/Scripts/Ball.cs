using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 8f;
    public float speedIncreasePerHit = 0.75f;
    public float paddleMaxAngle = 60f;

    private float currentSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBall(int serveDirX)
    {
        transform.position = Vector3.zero;
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.linearVelocity = Vector3.zero;
        rBody.angularVelocity = Vector3.zero;

        currentSpeed = startSpeed;

        Vector3 dirrection = (serveDirX < 0) ? Vector3.left : Vector3.right;
        rBody.linearVelocity = dirrection * currentSpeed;
    }

    public void OnCollisionEnter(Collision collision) 
    {
        currentSpeed += speedIncreasePerHit;

        // bool hitPaddle = collision.collider.CompareTag("Paddle");
        // bool hitWall = collision.collider.CompareTag("Wall");

        Rigidbody rBody = GetComponent<Rigidbody>();
        Vector3 incoming = rBody.linearVelocity;
        Vector3 incomingDir = incoming.normalized;

        Vector3 normal = collision.GetContact(0).normal;
        Vector3 reflectedDir = Vector3.Reflect(incomingDir, normal).normalized;

        rBody.linearVelocity = reflectedDir * currentSpeed;
    }
}
