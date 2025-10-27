using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class AssetReferenceLevel : AssetReferenceT<AudioClip>
{
    public AssetReferenceLevel(string guid) : base(guid) { }
}
