using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;
using Eddy.x12.Models.v4010.Composites;

namespace Eddy.x12.Tests.Models.v4010.Composites;

public class C007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "3*h*D*OL*7a*k*lA*n";

		var expected = new C007_AmountQualifyingDescription()
		{
			AmountQualifierCode = "3",
			AmountQualifierCode2 = "h",
			ValueDetailCode = "D",
			MeasurementSignificanceCode = "OL",
			UnitOfTimePeriodOrInterval = "7a",
			NetGrossCode = "k",
			MeasurementSignificanceCode2 = "lA",
			Description = "n",
		};

		var actual = Map.MapObject<C007_AmountQualifyingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new C007_AmountQualifyingDescription();
		//Required fields
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
