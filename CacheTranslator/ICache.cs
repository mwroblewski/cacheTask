using System.Collections.Generic;

namespace CacheTranslator
{
    public interface ICache
    {
        List<BlockRange> GetFileMapping(FileId fileIdentification);
        void CacheBlocks(List<BlockRange> blocks);
        void EvictBlocks(List<BlockRange> blocks);
    }
}
