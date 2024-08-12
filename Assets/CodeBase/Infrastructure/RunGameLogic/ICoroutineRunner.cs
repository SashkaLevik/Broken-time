using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.RunGameLogic
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
