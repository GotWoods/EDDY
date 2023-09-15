using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class LDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LDT*vy*3*OW*GcWpz4";

		var expected = new LDT_LeadTime()
		{
			LeadTimeCode = "vy",
			Quantity = 3,
			UnitOfTimePeriodOrInterval = "OW",
			Date = "GcWpz4",
		};

		var actual = Map.MapObject<LDT_LeadTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vy", true)]
	public void Validation_RequiredLeadTimeCode(string leadTimeCode, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.Quantity = 3;
		subject.UnitOfTimePeriodOrInterval = "OW";
		subject.LeadTimeCode = leadTimeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "vy";
		subject.UnitOfTimePeriodOrInterval = "OW";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OW", true)]
	public void Validation_RequiredUnitOfTimePeriodOrInterval(string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new LDT_LeadTime();
		subject.LeadTimeCode = "vy";
		subject.Quantity = 3;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
