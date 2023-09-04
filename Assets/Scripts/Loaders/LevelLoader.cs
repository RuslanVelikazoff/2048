using UnityEngine;

namespace Loader
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private CameraScaller cameraScaller;

        void Start()
        {
            cameraScaller.Initialize();
        }
    }
}
