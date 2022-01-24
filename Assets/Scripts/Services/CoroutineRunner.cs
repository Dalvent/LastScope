using System.Collections;
using UnityEngine;

namespace CodeBase.Services
{
    public class CoroutineRunner : ICoroutineRunner
    {
        private readonly MonoBehaviour _monoBehaviour;

        public CoroutineRunner(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }

        public Coroutine StartCoroutine(IEnumerator coroutine)
        {
            return _monoBehaviour.StartCoroutine(coroutine);
        }
    }
}