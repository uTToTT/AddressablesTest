using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelAddressablesLoader : MonoBehaviour
{
    [Serializable]
    private struct LevelInfo
    {
        public int Index;
        public AssetReference Level;
    }

    [SerializeField] private LevelInfo[] _levels;

    private GameObject _currLevel;

    public void LoadLevel(int index)
    {
        if (index < 0 || index > _levels.Length) return;

        Destroy(_currLevel?.gameObject);
        _levels[index].Level.InstantiateAsync();
    }
}
