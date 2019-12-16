namespace StarJournalEntities.StarBusinessEntities
{
    using Utilities.DateTime;
    using Utilities.IdGenerator;

    public class StarBusinessEntityFactory
    {
        public IStarBusinessEntity Create()
        {
            return new StarBusinessEntity();
        }
    }
}
