using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030;
using Eddy.x12.Models.v6030.Composites;

namespace Eddy.x12.Tests.Models.v6030.Composites;

public class C007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "K*O*3*pT*M0*J*25*v*C*P";

		var expected = new C007_AmountQualifyingDescription()
		{
			AmountQualifierCode = "K",
			AmountQualifierCode2 = "O",
			ValueDetailCode = "3",
			MeasurementSignificanceCode = "pT",
			UnitOfTimePeriodOrIntervalCode = "M0",
			NetGrossCode = "J",
			MeasurementSignificanceCode2 = "25",
			Description = "v",
			IndustryCode = "C",
			CodeListQualifierCode = "P",
		};

		var actual = Map.MapObject<C007_AmountQualifyingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new C007_AmountQualifyingDescription();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IndustryCode) || !string.IsNullOrEmpty(subject.IndustryCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode))
		{
			subject.IndustryCode = "C";
			subject.CodeListQualifierCode = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("C", "P", true)]
	[InlineData("C", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredIndustryCode(string industryCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new C007_AmountQualifyingDescription();
		//Required fields
		subject.AmountQualifierCode = "K";
		//Test Parameters
		subject.IndustryCode = industryCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
