using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ES*X*IF*K*7*3*kh";

		var expected = new ES_EquipmentStatus()
		{
			BadOrderReasonCode = "X",
			HoldReasonCode = "IF",
			AssociationOfAmericanRailroadsCarGradeCode = "K",
			TimePeriodUnitQualifier = "7",
			Quantity = 3,
			SwitchTypeCode = "kh",
		};

		var actual = Map.MapObject<ES_EquipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7", 3, true)]
	[InlineData("7", 0, false)]
	[InlineData("", 3, false)]
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
