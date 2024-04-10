using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float horizontalSpeed;
    public Transform pointA;
    public Transform pointB;
    private Transform targetPoint;

    void Start()
    {
        targetPoint = pointB; // Commence par se diriger vers le point B
    }

    void Update()
    {
        // Détermine la direction du déplacement
        Vector3 direction = (targetPoint.position - transform.position).normalized;

        // Déplacement de l'ennemi
        transform.Translate(direction * horizontalSpeed * Time.deltaTime);

        // Vérifie si l'ennemi est proche du point cible
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            // Inverse la cible : pointA devient pointB et vice versa
            if (targetPoint == pointA)
                targetPoint = pointB;
            else
                targetPoint = pointA;
        }
    }
}
