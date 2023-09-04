using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class ButtonManager : MonoBehaviour
    {
        [SerializeField] private Button playButton;

        public void Initialize()
        {
            ButtonFunc();

            Debug.Log("Button manager initialized");
        }

        private void ButtonFunc()
        {
            if (playButton != null)
            {
                playButton.onClick.RemoveAllListeners();
                playButton.onClick.AddListener(() =>
                {
                    SceneManager.LoadScene(1);
                });
            }
        }
    }
}
