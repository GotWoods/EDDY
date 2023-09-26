using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class ESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ES*p*H6*g*s*1*Vf*8";

		var expected = new ES_EquipmentStatus()
		{
			BadOrderReasonCode = "p",
			HoldReasonCode = "H6",
			AssociationOfAmericanRailroadsCarGradeCode = "g",
			TimePeriodUnitQualifier = "s",
			Quantity = 1,
			SwitchTypeCode = "Vf",
			IndustryCode = "8",
		};

		var actual = Map.MapObject<ES_EquipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("s", 1, true)]
	[InlineData("s", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredTimePeriodUnitQualifier(string timePeriodUnitQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new ES_EquipmentStatus();
		//Required fields
		//Test Parameters
		subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
