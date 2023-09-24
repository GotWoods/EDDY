using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LDT*Z6*1*b5*qMDvyirN";

		var expected = new LDT_LeadTime()
		{
			LeadTimeCode = "Z6",
			Quantity = 1,
			UnitOfTimePeriodOrIntervalCode = "b5",
			Date = "qMDvyirN",
		};

		var actual = Map.MapObject<LDT_LeadTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z6", true)]
	public void Validation_RequiredLeadTimeCode(string leadTimeCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.Quantity = 1;
		subject.UnitOfTimePeriodOrIntervalCode = "b5";
		subject.LeadTimeCode = leadTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "Z6";
		subject.UnitOfTimePeriodOrIntervalCode = "b5";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b5", true)]
	public void Validation_RequiredUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "Z6";
		subject.Quantity = 1;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
