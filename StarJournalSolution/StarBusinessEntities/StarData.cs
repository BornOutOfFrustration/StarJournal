namespace nl.NeoRenaissance.StarJournal.StarBusinessEntities{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StarData : IStarData {
        public StarData(string title, ISituationData situationData) {
            if(situationData == null) { throw new ArgumentNullException(message: "Argument for parameter cannot be null.", paramName: nameof(situationData)); }
            this.SituationData = situationData;
            this.Title = title;
        }

        public ISituationData Situation { get { return this.SituationData; } }
        private readonly ISituationData SituationData;
        
        public string Title {
            get { return this.StarTitle; }
            set { if (value == null) { throw new ArgumentNullException(message: "Argument for parameter cannot be null.", paramName: nameof(value)); }
                this.StarTitle = value;
            }
        }
        private string StarTitle;
    }
}
