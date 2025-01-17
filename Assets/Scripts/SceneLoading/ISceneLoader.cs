using System.Collections;

namespace RopeGame.SceneLoading
{
    public interface ISceneLoader
    {
        public IEnumerator LoadSceneAfterDelay(string sceneName, float delay);
    }
}