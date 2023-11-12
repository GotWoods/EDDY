using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CD2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD2*Re*A4*p*G*q*Y*m*H";

		var expected = new CD2_MultiValuedCharacteristics()
		{
			CodeCategory = "Re",
			ProductServiceIDQualifier = "A4",
			MedicalCodeValue = "p",
			MedicalCodeValue2 = "G",
			MedicalCodeValue3 = "q",
			MedicalCodeValue4 = "Y",
			MedicalCodeValue5 = "m",
			MedicalCodeValue6 = "H",
		};

		var actual = Map.MapObject<CD2_MultiValuedCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Re", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CD2_MultiValuedCharacteristics();
		//Required fields
		subject.ProductServiceIDQualifier = "A4";
		subject.MedicalCodeValue = "p";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A4", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new CD2_MultiValuedCharacteristics();
		//Required fields
		subject.CodeCategory = "Re";
		subject.MedicalCodeValue = "p";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredMedicalCodeValue(string medicalCodeValue, bool isValidExpected)
	{
		var subject = new CD2_MultiValuedCharacteristics();
		//Required fields
		subject.CodeCategory = "Re";
		subject.ProductServiceIDQualifier = "A4";
		//Test Parameters
		subject.MedicalCodeValue = medicalCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
