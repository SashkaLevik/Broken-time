using Assets.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.AssetManagment
{
    public interface IAssetProvider : IService
    {
        //GameObject Instantiate(ToyStaticData toyStaticData, string path, Vector3 at);
        GameObject InstantiateAt(string path, Vector3 at);
        GameObject Instantiate(string path);
    }
}
