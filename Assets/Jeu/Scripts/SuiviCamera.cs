using UnityEngine;

public class SuiviCamera : MonoBehaviour
{
    public Transform cible; // Référence au GameObject que la caméra doit suivre
    public float vitesseSuivi = 50f; // Vitesse de suivi de la caméra

    void FixedUpdate()
    {
        if (cible != null)
        {
            // Obtenir la position actuelle de la caméra
            Vector3 positionCamera = transform.position;

            // Suivre seulement l'axe Y de la cible
            positionCamera.y = Mathf.Lerp(positionCamera.y, cible.position.y, vitesseSuivi * Time.deltaTime);

            // Mettre à jour la position de la caméra
            transform.position = positionCamera;
        }
    }
}
