namespace CacheTranslator
{
    public class CacheTranslator : ICacheTranslator
    {
        private readonly ICache _cache;
        private readonly IPersistence _persistence;

        public CacheTranslator(ICache cache, IPersistence persistence)
        {
            _cache = cache;
            _persistence = persistence;
        }

        public void Add(FileId fileIdentification)
        {
            if (_persistence.Contains(fileIdentification))
            {
                return;
            }
            var blocks = _cache.GetFileMapping(fileIdentification);
            _cache.CacheBlocks(blocks);
            _persistence.Add(fileIdentification, blocks);
        }

        public void Remove(FileId fileIdentification)
        {
            if (_persistence.Contains(fileIdentification) == false)
            {
                return;
            }
            Synchronize(fileIdentification);
            //NOTE this still can desynchronize between these 2 calls
            _persistence.Remove(fileIdentification);
        }

        public void Synchronize(FileId fileIdentification)
        {
            if (_persistence.Contains(fileIdentification) == false)
            {
                return;
            }
            var blocksFromCache = _cache.GetFileMapping(fileIdentification);
            _persistence.Update(fileIdentification, blocksFromCache);
        }
    }
}
