using System.Collections;
using UnityEngine;

namespace CodeBase.Services
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}