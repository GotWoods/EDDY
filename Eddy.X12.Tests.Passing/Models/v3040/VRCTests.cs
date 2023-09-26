using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class VRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VRC*CJ*j*4*B*Z";

		var expected = new VRC_VehicleRecovery()
		{
			DateTimePeriodFormatQualifier = "CJ",
			DateTimePeriod = "j",
			Quantity = 4,
			RecoveryConditionCode = "B",
			RecoveryClassificationCode = "Z",
		};

		var actual = Map.MapObject<VRC_VehicleRecovery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CJ", "j", true)]
	[InlineData("CJ", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new VRC_VehicleRecovery();
		//Required fields
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
