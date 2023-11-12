using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ES*u*Sh*e*2*7";

		var expected = new ES_EquipmentStatus()
		{
			BadOrderReasonCode = "u",
			HoldReasonCode = "Sh",
			AssociationOfAmericanRailroadsCarGradeCode = "e",
			TimePeriodQualifier = "2",
			Quantity = 7,
		};

		var actual = Map.MapObject<ES_EquipmentStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 7, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 7, false)]
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
