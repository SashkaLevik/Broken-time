using Assets.CodeBase.Infrastructure.SaveLoad;
using Assets.CodeBase.Infrastructure.Services;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        //GameObject CreateToy(ToyStaticData toyStaticData, GameObject at);

        GameObject CreteMenuHud();
        //GameObject CreateBattleHud();
        //GameObject CreateSkillPanel();
        //GameObject CreateBattleSystem();
        //GameObject CreateArtifactsWatcher();
        List<ISaveProgress> ProgressWriters { get; }
        List<ILoadProgress> ProgressReaders { get; }
    }
}