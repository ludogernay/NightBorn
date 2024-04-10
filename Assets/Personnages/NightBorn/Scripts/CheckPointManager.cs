using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    private static CheckPointManager instance;

    public static CheckPointManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CheckPointManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject("CheckPointManager");
                    instance = obj.AddComponent<CheckPointManager>();
                }
            }
            return instance;
        }
    }

    private Vector3 lastCheckPointPosition;

    void Start()
    {
        // Initialise la dernière position du checkpoint à la position de départ du joueur
        lastCheckPointPosition = transform.position;
    }

    // Fonction pour enregistrer la position du dernier checkpoint touché
    public void SetCheckPoint(Vector3 checkpointPosition)
    {
        lastCheckPointPosition = checkpointPosition;
    }

    // Fonction pour récupérer la dernière position du checkpoint touché
    public Vector3 GetLastCheckPointPosition()
    {
        return lastCheckPointPosition;
    }
}
