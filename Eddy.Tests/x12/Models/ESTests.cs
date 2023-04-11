using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ES*P*Fs*Z*M*4*91*X";

		var expected = new ES_EquipmentStatus()
		{
			BadOrderReasonCode = "P",
			HoldReasonCode = "Fs",
			AssociationOfAmericanRailroadsCarGradeCode = "Z",
			TimePeriodUnitQualifier = "M",
			Quantity = 4,
			SwitchTypeCode = "91",
			IndustryCode = "X",
		};

		var actual = Map.MapObject<ES_EquipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("M", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("M", 0, false)]
	public void Validation_AllAreRequiredTimePeriodUnitQualifier(string timePeriodUnitQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new ES_EquipmentStatus();
		subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
