using System.Collections;
using UnityEngine;

namespace LastScope.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}