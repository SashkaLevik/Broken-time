using System.Collections.Generic;
using CodeBase.Infrastructure.SaveLoad;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        //GameObject CreateToy(ToyStaticData toyStaticData, GameObject at);

        GameObject CreteMenuHud();
        GameObject CreateTruckConstructor();
        GameObject CreateGarage();
        List<ISaveProgress> ProgressWriters { get; }
        List<ILoadProgress> ProgressReaders { get; }
    }
}