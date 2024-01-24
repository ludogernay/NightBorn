using UnityEngine;

namespace Platformer.View
{
    /// <summary>
    /// Used to move a transform relative to the main camera position with a scale factor applied.
    /// This is used to implement parallax scrolling effects on different branches of gameobjects.
    /// </summary>
    /// 
    public class ParallaxLayer : MonoBehaviour
    {
        /// <summary>
        /// Movement of the layer is scaled by this value.
        /// </summary>
        // public Vector3 movementScale = Vector3.one;

        // public float scrollspeed = 0.25f;
        // Transform _camera;

        // void Awake()
        // {
        //     _camera = Camera.main.transform;
        // }

        // void LateUpdate()
        // {
        //     Debug.Log(_camera.position);
        //     transform.position = Vector3.Scale(_camera.position, movementScale);
        // }

        public Vector3 movementScale = Vector3.one;
        public float scrollSpeed = 0.25f;
        public Transform ground; // Référence au sol ou à un autre objet que vous souhaitez suivre

        void LateUpdate()
        {
            if (ground == null)
            {
                Debug.LogError("Ground reference is not set in ParallaxLayer script!");
                return;
            }

            // Obtenez la position du sol et appliquez le facteur d'échelle et la vitesse de défilement
            Vector3 targetPosition = new Vector3(ground.position.x, 0, transform.position.z);
            transform.position = Vector3.Scale(targetPosition, movementScale) * scrollSpeed;
        }

    }
}