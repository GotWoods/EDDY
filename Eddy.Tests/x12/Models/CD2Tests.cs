using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CD2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CD2*kj*v6*p*r*s*0*S*8";

		var expected = new CD2_MultiValuedCharacteristics()
		{
			CodeCategory = "kj",
			ProductServiceIDQualifier = "v6",
			MedicalCodeValue = "p",
			MedicalCodeValue2 = "r",
			MedicalCodeValue3 = "s",
			MedicalCodeValue4 = "0",
			MedicalCodeValue5 = "S",
			MedicalCodeValue6 = "8",
		};

		var actual = Map.MapObject<CD2_MultiValuedCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kj", true)]
	public void Validatation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CD2_MultiValuedCharacteristics();
		subject.ProductServiceIDQualifier = "v6";
		subject.MedicalCodeValue = "p";
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v6", true)]
	public void Validatation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new CD2_MultiValuedCharacteristics();
		subject.CodeCategory = "kj";
		subject.MedicalCodeValue = "p";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validatation_RequiredMedicalCodeValue(string medicalCodeValue, bool isValidExpected)
	{
		var subject = new CD2_MultiValuedCharacteristics();
		subject.CodeCategory = "kj";
		subject.ProductServiceIDQualifier = "v6";
		subject.MedicalCodeValue = medicalCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
