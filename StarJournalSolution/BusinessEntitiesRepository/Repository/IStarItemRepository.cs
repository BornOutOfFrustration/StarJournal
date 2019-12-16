namespace BusinessEntitiesRepository
{
    using System.Collections.Generic;
    using BusinessEntitiesRepository.DatabaseObjects;

    public interface IStarItemRepository : IRepository<StarItemDbo>
    {
        IEnumerable<StarItemDbo> FindAllStartingWithA();
    }
}
