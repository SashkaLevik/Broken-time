using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.RunGameLogic
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
