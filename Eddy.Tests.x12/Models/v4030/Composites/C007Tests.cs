using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4030;
using Eddy.x12.Models.v4030.Composites;

namespace Eddy.x12.Tests.Models.v4030.Composites;

public class C007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "x*Z*U*2J*JI*R*2B*0*S*r";

		var expected = new C007_AmountQualifyingDescription()
		{
			AmountQualifierCode = "x",
			AmountQualifierCode2 = "Z",
			ValueDetailCode = "U",
			MeasurementSignificanceCode = "2J",
			UnitOfTimePeriodOrInterval = "JI",
			NetGrossCode = "R",
			MeasurementSignificanceCode2 = "2B",
			Description = "0",
			IndustryCode = "S",
			CodeListQualifierCode = "r",
		};

		var actual = Map.MapObject<C007_AmountQualifyingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new C007_AmountQualifyingDescription();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.IndustryCode) || !string.IsNullOrEmpty(subject.IndustryCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode))
		{
			subject.IndustryCode = "S";
			subject.CodeListQualifierCode = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "r", true)]
	[InlineData("S", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredIndustryCode(string industryCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new C007_AmountQualifyingDescription();
		//Required fields
		subject.AmountQualifierCode = "x";
		//Test Parameters
		subject.IndustryCode = industryCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
