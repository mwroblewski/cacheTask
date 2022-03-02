using System;
using System.Collections.Generic;

namespace CacheTranslator
{
    public class MemoryPersistence : IPersistence
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
    }
}
