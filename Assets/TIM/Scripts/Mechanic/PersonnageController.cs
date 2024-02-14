using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour
{
    public float vitesseDeplacement = 5.0f;
    public float inertie = 0.05f;
    private Vector3 vitesse = Vector3.zero;
    // private Animator animator; // Référence à l'Animator

    private void Start()
    {
        // Obtenez une référence à l'Animator attaché au GameObject
        // animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Obtenez les entrées de l'utilisateur
        float deplacementHorizontal = 0f;
        float deplacementVertical = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            deplacementHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            deplacementHorizontal = -1f;
        }

        // Calculez le vecteur de déplacement en fonction des entrées de l'utilisateur
        Vector3 deplacement = new Vector3(deplacementHorizontal, deplacementVertical, 0) * vitesseDeplacement * Time.deltaTime;

        // Appliquez l'inertie
        vitesse = Vector3.Lerp(vitesse, deplacement, inertie);

        // Appliquez le déplacement au personnage
        transform.Translate(vitesse);


    }
}