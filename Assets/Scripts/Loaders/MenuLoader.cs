using UnityEngine;

namespace Loader
{
    public class MenuLoader : MonoBehaviour
    {
        [SerializeField] private UI.ButtonManager buttonManager;
        
        void Start()
        {
            buttonManager.Initialize();
        }
    }
}
