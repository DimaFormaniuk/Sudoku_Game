using UnityEngine;

namespace Sudoku.Scripts.CodeBase.Data
{
    public static class DataExtention
    {
        public static T AsDeserelize<T>(this string json) => 
            JsonUtility.FromJson<T>(json);

        public static string ToJson(this object obj) =>
            JsonUtility.ToJson(obj);
    }
}