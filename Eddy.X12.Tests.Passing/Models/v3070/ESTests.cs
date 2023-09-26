using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ES*P*Nc*u*B*6*It";

		var expected = new ES_EquipmentStatus()
		{
			BadOrderReasonCode = "P",
			HoldReasonCode = "Nc",
			AssociationOfAmericanRailroadsCarGradeCode = "u",
			TimePeriodQualifier = "B",
			Quantity = 6,
			SwitchTypeCode = "It",
		};

		var actual = Map.MapObject<ES_EquipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("B", 6, true)]
	[InlineData("B", 0, false)]
	[InlineData("", 6, false)]
	public void Validation_AllAreRequiredTimePeriodQualifier(string timePeriodQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new ES_EquipmentStatus();
		//Required fields
		//Test Parameters
		subject.TimePeriodQualifier = timePeriodQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
