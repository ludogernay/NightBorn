using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RandomGround : MonoBehaviour
{
    public Tilemap[] tilemaps; // Tableau contenant vos différentes Tilemaps
    public float vitesseDefilement; // Vitesse de défilement du sol

    public Transform playerTransform;
    private float tilemapLength = 1.28f; // Longueur d'une Tilemap

    void Update()
    {
        if (playerTransform.position.x > (tilemaps.Length - 3) * tilemapLength) // Si le joueur est proche de la fin de la Tilemap actuelle
        {
            FaireDefiler();
        }
    }

    void FaireDefiler()
    {
        foreach (Tilemap tilemap in tilemaps)
        {
            tilemap.transform.position += Vector3.left * vitesseDefilement * tilemapLength * Time.deltaTime; // Faire défiler chaque Tilemap vers la gauche
        }
    }
}
