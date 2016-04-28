using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nl.NeoRenaissance.StarJournal.StarBusinessEntities {
    public class SituationData : ISituationData {
        public SituationData(DateTime situationDateTime, string description) {
            // Assert paramaters.
            if(situationDateTime.Kind == DateTimeKind.Unspecified) { throw new ArgumentException(message: "Argument for parameter must have a valid DateTime, and cannot be Unspecified.", paramName: nameof(situationDateTime)); }
            
            // Set members.
            this.Description = description;
            this.SituationDateTimeMember = situationDateTime;            
        }

        /// <summary>
        /// The moment at which the situation occured, started to be significant or I became involved with.
        /// </summary>
        public DateTime SituationDateTime { get { return this.SituationDateTimeMember.Date; } }
        private readonly DateTime SituationDateTimeMember;

        /// <summary>
        /// The description of the situation.
        /// </summary>
        public string Description {
            get {
                return this.DescriptionMember;
            }
            set {
                if (value == null) { throw new ArgumentNullException(message: "Argument for parameter cannot be null.", paramName: nameof(value)); }
                this.DescriptionMember = value;
            }
        }
        private string DescriptionMember;
    
    }
}
