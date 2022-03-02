﻿using System.Collections.Generic;

namespace CacheTranslator
{
    public interface IPersistence
    {
        void Add(FileId fileIdentification, List<BlockRange> blocks);

        void Remove(FileId fileIdentifiaction);
    }
}