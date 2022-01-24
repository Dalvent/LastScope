using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Services
{
    public class SceneLoader : ISceneLoader
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;
        private readonly ICoroutineRunner _coroutineRunner;

        public SceneLoader(ZenjectSceneLoader zenjectSceneLoader, ICoroutineRunner coroutineRunner)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
            _coroutineRunner = coroutineRunner;
        }
        
        public void Load(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadCoroutine(name, onLoaded));
        }

        private IEnumerator LoadCoroutine(string name, Action onLoaded)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }
      
            AsyncOperation loadSceneOperation = _zenjectSceneLoader.LoadSceneAsync(name);

            while (!loadSceneOperation.isDone)
                yield return null;
      
            onLoaded?.Invoke();
        }
    }
}