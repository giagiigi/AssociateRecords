using System;
using System.Collections.Generic;
using System.Linq;
using AssociateRecords.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AssociateRecords.Domain.Tests
{
    [TestClass]
    public class AssociateTests
    {
        private Mock<IReferenceDataService> _referenceDataService;


        [TestMethod]
        public void TestCreateNewAssociate()
        {
            //Assemble
            _referenceDataService = new Mock<IReferenceDataService>();
            _referenceDataService.Setup(_ => _.GetReferenceDataItemsByType<Language>())
                .Returns(new List<Language>() { new Language() { Code = "en", Id =1, LanguageName = "English"} });

            _referenceDataService.Setup(_ => _.GetReferenceDataItemsByType<LanguageSkillRating>())
                .Returns(new List<LanguageSkillRating>() { new LanguageSkillRating() { Code = "Basic", Id = 1, } });


            string firstName = "Jim";
            string lastName = "Jones";

            var languages = new List<Language>(_referenceDataService.Object.GetReferenceDataItemsByType<Language>());
            var languageSkills =
                new List<LanguageSkillRating>(
                    _referenceDataService.Object.GetReferenceDataItemsByType<LanguageSkillRating>());
            var language = languages.First();
            language.AddLanguageSkillLevel(languageSkills.First());
            languages.Add(languages.FirstOrDefault());

            Associate associate = Associate.CreateNew(firstName, lastName, languages);


            //Act


            //Assert
        }
    }
}
