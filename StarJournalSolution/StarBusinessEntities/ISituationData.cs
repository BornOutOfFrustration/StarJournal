using System;

namespace nl.NeoRenaissance.StarJournal.StarBusinessEntities {
    public interface ISituationData {
        string Description { get; set; }
        DateTime SituationDateTime { get; }
    }
}