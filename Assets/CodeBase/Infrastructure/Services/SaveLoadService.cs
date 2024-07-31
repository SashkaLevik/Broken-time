using Assets.CodeBase.Data;
using Assets.CodeBase.Infrastructure.Factory;
using Assets.CodeBase.Infrastructure.SaveLoad;
using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";

        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISaveProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.Save(_progressService.Progress);

            PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?
                .ToDeserialized<PlayerProgress>();
        }

        public void ResetProgress()
        {
            PlayerPrefs.DeleteKey(ProgressKey);
            PlayerPrefs.Save();
            _gameFactory.ProgressWriters.Clear();
            _gameFactory.ProgressReaders.Clear();
        }
    }
}
