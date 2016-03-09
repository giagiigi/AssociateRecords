using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssociateRecords.Domain
{
    public class Associate
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public AssignmentHistory Assignements { get; set; } 

        public ConversationHistory Conversation { get; set; }


        public static Associate CreateNew(string firstName, string lastName, IEnumerable<Language> languages )
        {
            var associate = new Associate()
            {
                FirstName = firstName,
                LastName = lastName,
                Languages = new List<Language>()
            };

            foreach (var language in languages)
            {
                associate.AddLanguageAndSkillLevel(language);
            }
            

            return associate;

        }

        private void AddLanguageAndSkillLevel(Language language)
        {
            Languages.Add(language);
        }
    }
}
