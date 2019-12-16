namespace StarJournalEntities.StarBusinessEntities
{
    using System;

    internal class StarBusinessEntity : IStarBusinessEntity
    {
        private Guid Id = default;
        private bool IsNew = false;
        private string ItemName = String.Empty;

        internal StarBusinessEntity()
        { }

        Guid IStarBusinessEntity.Id
        {
            get
            {
                return this.Id;
            }
        }

        bool IStarBusinessEntity.IsNew
        {
            get
            {
                return this.IsNew;
            }
        }

        string IStarBusinessEntity.ItemName
        {
            get
            {
                return this.ItemName;
            }
        }

        void IStarBusinessEntity.CreateNewStarItem(Guid id)
        {
            this.Id = id;
            this.IsNew = true;
            this.ItemName = String.Empty;
        }
    }
}
