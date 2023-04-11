using System.Text.RegularExpressions;
using Eddy.Core.Attributes;
using EdiParser.ClassGenerator.Lib;

namespace Eddy.Tests
{

    public class TestModel
    {
        [Position(1)]
        public string Field1 { get; set; }

        [Position(2)]
        public string Field2 { get; set; }

        [Position(3)]
        public string Field3 { get; set; }
    }


    public class CodeGenTests
    {
        private Model _model;
        private CodeGenerator _subject;
        private Regex _elementNameRegEx;

        public CodeGenTests()
        {
            _model = new Model("T1-01", "Field1", "string", 0, 0);
            _subject = new CodeGenerator();
            _elementNameRegEx = new Regex("T1-\\d{2}");
        }

        [Fact]
        public void ExtractARequiresB()
        {
            //TODO: If MS1-01 is present, then at least one of MS1-02 or MS1-03 is required
            var text = "If T1-02 is present, then T1-01 is required"; //ARequiresB
            
            //var text3 = "If T1-01 is present, then at least one of T1-02 or T1-03 is required";
            _subject.ExtractValidations(text, _model, _elementNameRegEx);
            Assert.Single(_model.ARequiresBValidation);
            
            Assert.Empty(_model.IfOneIsFilledAllAreRequiredValidations);
            Assert.Empty(_model.AtLeastOneValidations);
            //Assert.Empty(_model.ARequiresBValidation);
            Assert.Empty(_model.OnlyOneOfValidations);

        //public List<ValidationData> IfPresentOthersRequiredValidations { get; set; } = new();
        }

        [Fact]
        public void ExtractIfAIsPresentThenAtLeastOneMoreIsRequired()
        {
            var text = "If T1-01 is present, then at least one of T1-02 or T1-03 is required"; //ARequiresB
            
            _subject.ExtractValidations(text, _model, _elementNameRegEx);
            //Assert.Single(_model.ARequiresBValidation);

            Assert.Empty(_model.IfOneIsFilledAllAreRequiredValidations);
            Assert.Empty(_model.AtLeastOneValidations);
            Assert.Empty(_model.ARequiresBValidation);
            Assert.Empty(_model.OnlyOneOfValidations);

            //public List<ValidationData> IfPresentOthersRequiredValidations { get; set; } = new();
        }




        [Fact]
        public void ExtractIfOneThenAllRequired()
        {
            var text = "If either T1-04 or T1-05 is present, then the other is required"; //IfOne_ThenAllRequired (this is basically ARequiresB and then the reverse of BRequiresA)
            _subject.ExtractValidations(text, _model, _elementNameRegEx);
            Assert.Single(_model.IfOneIsFilledAllAreRequiredValidations);

            //Assert.Empty(_model.IfOneIsFilledAllAreRequiredValidations);
            Assert.Empty(_model.AtLeastOneValidations);
            Assert.Empty(_model.ARequiresBValidation);
            Assert.Empty(_model.OnlyOneOfValidations);
        }

        [Fact]
        public void ExtractAtLeastOneIsRequired()
        {
            var text = "At least one of T1-01 or T1-03 is required";
            _subject.ExtractValidations(text, _model, _elementNameRegEx);
            Assert.Single(_model.AtLeastOneValidations);

            Assert.Empty(_model.IfOneIsFilledAllAreRequiredValidations);
            //Assert.Empty(_model.AtLeastOneValidations);
            Assert.Empty(_model.ARequiresBValidation);
            Assert.Empty(_model.OnlyOneOfValidations);
        }

        [Fact]
        public void ExtractOnlyOneOf()
        {
            var text = "Only one of T1-01 or T1-03 may be present"; 
            _subject.ExtractValidations(text, _model, _elementNameRegEx);
            Assert.Single(_model.OnlyOneOfValidations);

            Assert.Empty(_model.IfOneIsFilledAllAreRequiredValidations);
            Assert.Empty(_model.AtLeastOneValidations);
            Assert.Empty(_model.ARequiresBValidation);
            //Assert.Empty(_model.OnlyOneOfValidations);
        }


    }
}
