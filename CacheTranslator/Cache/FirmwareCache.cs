using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CacheTranslator
{
    //NOTE this class is not needed but is left on purpose to present how should it look to communicate with the firmware
    internal class FirmwareCache : IDisk
    {
        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void CacheBlocks(List<BlockRange> blocks);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern void EvictBlocks(List<BlockRange> blocks);

        [MethodImpl(MethodImplOptions.InternalCall)]
        public extern List<BlockRange> GetFileMapping(FileId fileIdentification);
    }
}
