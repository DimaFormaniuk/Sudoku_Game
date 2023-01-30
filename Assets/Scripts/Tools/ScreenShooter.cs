using UnityEngine;

namespace Tools
{
    public class ScreenShooter : MonoBehaviour
    {
        [SerializeField] private string path;
        [SerializeField] private string format = ".png";

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                string pathScreenShoot = $"{path}{Time.deltaTime.GetHashCode()}{format}";
                ScreenCapture.CaptureScreenshot(pathScreenShoot);
                Debug.Log($"Screenshoot{pathScreenShoot}");
            }
        }
    }
}