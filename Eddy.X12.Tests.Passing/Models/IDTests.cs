using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID*ye*6O*c";

		var expected = new ID_InspectionDetailSegment()
		{
			DamageAreaCode = "ye",
			DamageTypeCode = "6O",
			DamageSeverityCode = "c",
		};

		var actual = Map.MapObject<ID_InspectionDetailSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ye", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new ID_InspectionDetailSegment();
		subject.DamageTypeCode = "6O";
		subject.DamageSeverityCode = "c";
		subject.DamageAreaCode = damageAreaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6O", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new ID_InspectionDetailSegment();
		subject.DamageAreaCode = "ye";
		subject.DamageSeverityCode = "c";
		subject.DamageTypeCode = damageTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new ID_InspectionDetailSegment();
		subject.DamageAreaCode = "ye";
		subject.DamageTypeCode = "6O";
		subject.DamageSeverityCode = damageSeverityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
