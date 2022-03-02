﻿namespace CacheTranslator
{
    public class CacheTranslator : ICacheTranslator
    {
        private readonly IDisk _disk;
        private readonly IPersistence _persistence;

        public CacheTranslator(IDisk cache = null, IPersistence persistence = null)
        {
            _disk = cache ?? new FirmwareCache();
            _persistence = persistence ?? new MemoryPersistence();
        }

        public void Add(FileId fileIdentification)
        {
            if (_persistence.Contains(fileIdentification))
            {
                return;
            }
            var blocks = _disk.GetFileMapping(fileIdentification);
            _disk.CacheBlocks(blocks);
            _persistence.Add(fileIdentification, blocks);
        }

        public void Remove(FileId fileIdentification)
        {
            if (_persistence.Contains(fileIdentification) == false)
            {
                return;
            }
            Synchronize(fileIdentification);
            //NOTE this still can desynchronize between these calls
            var blocks = _persistence.Get(fileIdentification);
            _disk.EvictBlocks(blocks);
            _persistence.Remove(fileIdentification);
        }

        public void Synchronize(FileId fileIdentification)
        {
            if (_persistence.Contains(fileIdentification) == false)
            {
                return;
            }
            var blocksFromCache = _disk.GetFileMapping(fileIdentification);
            _persistence.Update(fileIdentification, blocksFromCache);
        }
    }
}
