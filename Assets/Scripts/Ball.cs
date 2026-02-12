using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float startSpeed = 8f;
    public float speedIncreasePerHit = 0.75f;
    public float paddleMaxAngle = 60f;
    public AudioClip paddleCollision;

    private float currentSpeed;

    float pitch;
    AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        pitch = 1f;

        Vector3 leftServeDir = Quaternion.Euler(0, Random.Range(-paddleMaxAngle, paddleMaxAngle), 0) * Vector3.left;
        Vector3 rightServeDir = Quaternion.Euler(0, Random.Range(-paddleMaxAngle, paddleMaxAngle), 0) * Vector3.right;

        Vector3 dirrection = (serveDirX < 0) ? leftServeDir : rightServeDir;
        rBody.linearVelocity = dirrection * currentSpeed;
    }

    public void OnCollisionEnter(Collision collision) 
    {
        audioSource.pitch = pitch * (1f + (currentSpeed - startSpeed) / startSpeed);
        audioSource.PlayOneShot(paddleCollision);
        
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

    // Ball hitting trigger causes speed up or size up, and turns off trigger for 5 seconds before it can be hit again
    public void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("SpeedUp"))
        {
            Rigidbody rBody = GetComponent<Rigidbody>();

            rBody.linearVelocity += rBody.linearVelocity * speedIncreasePerHit;
            currentSpeed += currentSpeed * speedIncreasePerHit;

            other.gameObject.SetActive(false);
            StartCoroutine(ReactivateTrigger(other.gameObject));
        }
        else if (other.CompareTag("SizeUp"))
        {
            transform.localScale *= 2f;
            other.gameObject.SetActive(false);
            StartCoroutine(ReactivateTrigger(other.gameObject));
        }
    }

    IEnumerator ReactivateTrigger(GameObject trigger)
    {
        yield return new WaitForSeconds(5f);
        trigger.SetActive(true);
        transform.localScale = Vector3.one;
    }
}
