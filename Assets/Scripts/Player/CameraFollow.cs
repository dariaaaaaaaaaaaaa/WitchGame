using UnityEngine;

namespace Player
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform playerFollow;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float smoothness;

        void Update()
        {
            Vector3 target = playerFollow.position + offset;
            Vector3 pos = Vector3.Lerp(cameraTransform.position, target, smoothness * Time.deltaTime);

            transform.position = pos;
        }
    }
}
