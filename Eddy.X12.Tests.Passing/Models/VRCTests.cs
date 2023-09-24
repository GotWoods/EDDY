using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VRC*GV*p*8*I*v";

		var expected = new VRC_VehicleRecovery()
		{
			DateTimePeriodFormatQualifier = "GV",
			DateTimePeriod = "p",
			Quantity = 8,
			RecoveryConditionCode = "I",
			RecoveryClassificationCode = "v",
		};

		var actual = Map.MapObject<VRC_VehicleRecovery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("GV", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("GV", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new VRC_VehicleRecovery();
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
