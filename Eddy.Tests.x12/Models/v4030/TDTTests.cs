using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TDT*j*1*P4*y";

		var expected = new TDT_TaxDelinquencyStatus()
		{
			RealEstateTaxDelinquencyTypeCode = "j",
			ReferenceIdentification = "1",
			StatusCode = "P4",
			ActionCode = "y",
		};

		var actual = Map.MapObject<TDT_TaxDelinquencyStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredRealEstateTaxDelinquencyTypeCode(string realEstateTaxDelinquencyTypeCode, bool isValidExpected)
	{
		var subject = new TDT_TaxDelinquencyStatus();
		//Required fields
		subject.ReferenceIdentification = "1";
		//Test Parameters
		subject.RealEstateTaxDelinquencyTypeCode = realEstateTaxDelinquencyTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new TDT_TaxDelinquencyStatus();
		//Required fields
		subject.RealEstateTaxDelinquencyTypeCode = "j";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
