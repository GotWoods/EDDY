using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TDT*g*2*S1*s";

		var expected = new TDT_TaxDelinquencyStatus()
		{
			RealEstateTaxDelinquencyTypeCode = "g",
			ReferenceIdentification = "2",
			StatusCode = "S1",
			ActionCode = "s",
		};

		var actual = Map.MapObject<TDT_TaxDelinquencyStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredRealEstateTaxDelinquencyTypeCode(string realEstateTaxDelinquencyTypeCode, bool isValidExpected)
	{
		var subject = new TDT_TaxDelinquencyStatus();
		//Required fields
		subject.ReferenceIdentification = "2";
		//Test Parameters
		subject.RealEstateTaxDelinquencyTypeCode = realEstateTaxDelinquencyTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TDT_TaxDelinquencyStatus();
		//Required fields
		subject.RealEstateTaxDelinquencyTypeCode = "g";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
