using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RopeGame.SceneLoading
{
    public class SceneLoader : ISceneLoader
    {
        public IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(sceneName);
        }
    }
}