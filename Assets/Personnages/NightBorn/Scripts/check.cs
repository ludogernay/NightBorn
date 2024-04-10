using UnityEngine;

public class check : MonoBehaviour
{
    private Rigidbody2D rb;
    private CheckPointManager checkPointManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        checkPointManager = FindObjectOfType<CheckPointManager>();
    }

    public void RespawnAtLastCheckPoint(Vector3 respawnPosition)
    {
        transform.position = respawnPosition;
        rb.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CheckPoint"))
        {
            // Récupérer la position du checkpoint
            Vector3 checkpointPosition = other.transform.position;
            Debug.Log("Position du checkpoint : " + checkpointPosition);

            // Enregistrer la position du checkpoint
            checkPointManager.SetCheckPoint(checkpointPosition);
        }
    }
}