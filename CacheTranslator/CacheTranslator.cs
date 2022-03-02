namespace CacheTranslator
{
    public class CacheTranslator
    {
        private readonly IDisk _disk;
        private readonly IPersistence _persistence;

        public CacheTranslator(IDisk disk = null, IPersistence persistence = null)
        {
            _disk = disk ?? new FirmwareCache();
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
            var blocksFromDisk = _disk.GetFileMapping(fileIdentification);
            //NOTE this could be done with comparing which blocks got removed and then updating them in cache respectively
            _disk.EvictBlocks(_persistence.Get(fileIdentification));
            _disk.CacheBlocks(blocksFromDisk);
            _persistence.Update(fileIdentification, blocksFromDisk);
        }
    }
}
