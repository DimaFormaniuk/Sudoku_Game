using System.Collections;
using UnityEngine;

namespace Sudoku.Scripts.CodeBase.Infrastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}