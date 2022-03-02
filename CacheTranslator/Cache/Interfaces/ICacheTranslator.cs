namespace CacheTranslator
{
    public interface ICacheTranslator
    {
        void Add(FileId fileIdentification);
        void Remove(FileId fileIdentification);
        void Synchronize(FileId fileIdentification);
    }
}
