using System;
using System.Collections.Generic;

namespace CacheTranslator
{
    internal class MemoryPersistence : IPersistence
    {
        readonly Dictionary<FileId, List<BlockRange>> _inMemory = new();

        public void Add(FileId fileIdentification, List<BlockRange> blocks)
        {
            if (_inMemory.ContainsKey(fileIdentification))
            {
                return;
            }
            _inMemory.Add(fileIdentification, blocks);
        }

        public void Remove(FileId fileIdentifiaction)
        {
            _inMemory.Remove(fileIdentifiaction);
        }

        public bool Contains(FileId fileIdentification)
        {
            return _inMemory.ContainsKey(fileIdentification);
        }

        public void Update(FileId fileIdentification, List<BlockRange> newBlocks)
        {
            _inMemory[fileIdentification] = newBlocks;
        }

        public List<BlockRange> Get(FileId fileIdentification)
        {
            return _inMemory[fileIdentification];
        }
    }
}
