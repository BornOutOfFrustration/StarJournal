namespace StarJournalUseCases.Dto
{
    using System;

    public class StarItemDto
    {
        public Guid Id { get; set; }
        public bool IsNew { get; set; }
        public string ItemName { get; set; }
    }
}
