using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public bool isLeftGoal = true;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            gameManager.Goal(isLeftGoal);
        }
    }
}
