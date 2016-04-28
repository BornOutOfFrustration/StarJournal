namespace nl.NeoRenaissance.StarJournal.StarBusinessEntities {
    public interface IStarData {
        ISituationData Situation { get; }
        string Title { get; set; }
    }
}