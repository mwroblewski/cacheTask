using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CacheTranslator
{
    internal class FirmwareCache : ICache
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void CacheBlocks(List<BlockRange> blocks);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void EvictBlocks(List<BlockRange> blocks);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern List<BlockRange> GetFileMapping(FileId fileIdentification);
    }
}
