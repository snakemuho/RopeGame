using UnityEngine;
using UnityEngine.SceneManagement;

namespace RopeGame.SceneLoading
{
    public class RestartGameButton : MonoBehaviour
    {
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
        }
    }
}