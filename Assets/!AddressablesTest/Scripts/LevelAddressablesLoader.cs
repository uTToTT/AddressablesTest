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

    private AssetReference _currLevelAssetReference;
    private GameObject _currLevel;

    public void LoadLevel(int id)
    {
        id -= 1;

        if (id < 0 || id > _levels.Length) return;

        if (_currLevelAssetReference != null)
        {
            _currLevelAssetReference?.ReleaseInstance(_currLevel);
        }

        _levels[id].Level.InstantiateAsync().Completed += (asyncOperation) => _currLevel = asyncOperation.Result;
        _currLevelAssetReference = _levels[id].Level;
    }
}
