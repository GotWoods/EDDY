using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TDT*W*v*3U*e";

		var expected = new TDT_TaxDelinquencyStatus()
		{
			RealEstateTaxDelinquencyTypeCode = "W",
			ReferenceIdentification = "v",
			StatusCode = "3U",
			ActionCode = "e",
		};

		var actual = Map.MapObject<TDT_TaxDelinquencyStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredRealEstateTaxDelinquencyTypeCode(string realEstateTaxDelinquencyTypeCode, bool isValidExpected)
	{
		var subject = new TDT_TaxDelinquencyStatus();
		subject.ReferenceIdentification = "v";
		subject.RealEstateTaxDelinquencyTypeCode = realEstateTaxDelinquencyTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TDT_TaxDelinquencyStatus();
		subject.RealEstateTaxDelinquencyTypeCode = "W";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
