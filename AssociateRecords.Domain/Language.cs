using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateRecords.Domain
{
    public class Language : ReferenceDataItem
    {
        public string LanguageName { get; set; }

        public LanguageSkillRating LanguageSkill { get; set; }

        public void AddLanguageSkillLevel(LanguageSkillRating skillRating)
        {
            LanguageSkill = skillRating;
        }
    }
}
