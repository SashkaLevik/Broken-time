﻿using CodeBase.Data;

namespace CodeBase.Infrastructure.Services
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}
