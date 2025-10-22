using UnityEngine;

namespace JYW.JewelPop.Camera
{
    public class CameraObject : MonoBehaviour
    {
        private UnityEngine.Camera cam;

        private void Awake()
        {
            cam = GetComponent<UnityEngine.Camera>();
        }

        private void Start()
        {
            float targetAspect = 9f / 19f;
            float windowAspect = (float)Screen.width / (float)Screen.height;
            float scale = windowAspect / targetAspect;

            if (scale < 1f)
            {
                Rect rect = cam.rect;
                rect.width = 1f;
                rect.height = scale;
                rect.x = 0f;
                rect.y = (1f - scale) / 2f;
                cam.rect = rect;
            }
            else
            {
                Rect rect = cam.rect;
                rect.width = 1f / scale;
                rect.height = 1f;
                rect.x = (1f - 1f / scale) / 2f;
                rect.y = 0f;
                cam.rect = rect;
            }

        }
    }
}
