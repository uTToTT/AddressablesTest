using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelAddressablesLoader : MonoBehaviour
{
    [Serializable]
    private struct LevelInfo
    {
        public int Id;
        public AssetReference Level;
    }

    [SerializeField] private LevelInfo[] _levels;

    private GameObject _currLevel;

    public void LoadLevel(int id)
    {
        id -= 1;

        if (id < 0 || id > _levels.Length) return;

        Destroy(_currLevel?.gameObject);
         _levels[id].Level.InstantiateAsync().Completed += (asyncOperation) => _currLevel = asyncOperation.Result;
    }
}
