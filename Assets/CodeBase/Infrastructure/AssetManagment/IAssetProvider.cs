using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagment
{
    public interface IAssetProvider : IService
    {
        //GameObject Instantiate(ToyStaticData toyStaticData, string path, Vector3 at);
        GameObject Instantiate(string path);
        GameObject InstantiateAt(string path, Vector3 at);
        GameObject InstantiateInParent(string path, Transform parent);
    }
}
