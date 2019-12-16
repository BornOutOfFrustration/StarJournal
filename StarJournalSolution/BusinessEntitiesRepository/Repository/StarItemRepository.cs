namespace BusinessEntitiesRepository
{
    using System.Collections.Generic;
    using System.Linq;
    using BusinessEntitiesRepository.DatabaseObjects;
    using Microsoft.EntityFrameworkCore;

    internal sealed class StarItemRepository : Repository<StarItemDbo>, IStarItemRepository
    {
        public StarItemRepository(DbContext context) : base(context)
        {
        }

        IEnumerable<StarItemDbo> IStarItemRepository.FindAllStartingWithA()
        {
            return base.Database.Set<StarItemDbo>().Where(a => a.ItemName.StartsWith("A"));
        }
    }
}
