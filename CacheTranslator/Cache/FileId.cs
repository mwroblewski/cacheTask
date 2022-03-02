using System;

namespace CacheTranslator
{
    public class FileId
    {
        Guid Value { get; } = Guid.NewGuid();
    }
}
