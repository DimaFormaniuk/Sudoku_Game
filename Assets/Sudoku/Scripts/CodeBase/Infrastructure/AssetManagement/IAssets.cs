using Sudoku.Scripts.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Sudoku.Scripts.CodeBase.Infrastructure.AssetManagement
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
    }
}