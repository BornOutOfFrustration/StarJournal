namespace Utilities.IdGenerator
{
    using System;

    public sealed class IdGeneratorClass : IGenerateId
    {
        Guid IGenerateId.Unique()
        {
            return Guid.NewGuid();
        }
    }

    public interface IGenerateId
    {
        Guid Unique();
    }
}
