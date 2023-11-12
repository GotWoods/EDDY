using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070.Composites;

public class C007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "8*s*t*du*2j*P*66*1";

		var expected = new C007_AmountQualifyingDescription()
		{
			AmountQualifierCode = "8",
			AmountQualifierCode2 = "s",
			ValueDetailCode = "t",
			MeasurementSignificanceCode = "du",
			UnitOfTimePeriodOrInterval = "2j",
			NetGrossCode = "P",
			MeasurementSignificanceCode2 = "66",
			Description = "1",
		};

		var actual = Map.MapObject<C007_AmountQualifyingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new C007_AmountQualifyingDescription();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
