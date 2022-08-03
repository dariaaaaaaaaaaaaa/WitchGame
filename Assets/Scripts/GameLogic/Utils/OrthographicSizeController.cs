using UnityEngine;

namespace Utils
{
    [ExecuteInEditMode]
    public class OrthographicSizeController : MonoBehaviour
    {
#pragma warning disable
        [SerializeField] private float keyAspectRatio;
        [SerializeField] private float narrowSize;
        [SerializeField] private float wideSize;
        [SerializeField] private Camera mCamera;
#pragma warning restore
        
        public float CameraSize => mCamera.aspect <= keyAspectRatio ? narrowSize : wideSize;

        private void Awake()
        {
            ApplyMatch();
        }

#if UNITY_EDITOR
        private void Update()
        {
            ApplyMatch();
        }
#endif

        private void ApplyMatch()
        {
            if (mCamera == null)
            {
                return;
            }

            mCamera.orthographicSize = CameraSize;
        }
    }
}