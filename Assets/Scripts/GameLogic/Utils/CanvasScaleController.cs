using UnityEngine;
using UnityEngine.UI;

namespace Core.Utils
{
    [ExecuteInEditMode]
    public class CanvasScaleController : MonoBehaviour
    {
#pragma warning disable
        [SerializeField] private CanvasScaler canvasScaler;
        [SerializeField] private float keyAspectRatio;
        [Range(0, 1)] [SerializeField] private float matchNarrowScreen;
        [Range(0, 1)] [SerializeField] private float matchWideScreen;
        [SerializeField] private Camera mCamera;
#pragma warning restore

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

            canvasScaler.matchWidthOrHeight = mCamera.aspect <= keyAspectRatio ? matchNarrowScreen : matchWideScreen;
        }

        public void SetCamera(Camera newCamera)
        {
            mCamera = newCamera;
            ApplyMatch();
        }
    }
}