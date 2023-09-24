using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class IDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ID*ub*LI*B";

		var expected = new ID_InspectionDetailSegment()
		{
			DamageAreaCode = "ub",
			DamageTypeCode = "LI",
			DamageSeverityCode = "B",
		};

		var actual = Map.MapObject<ID_InspectionDetailSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ub", true)]
	public void Validation_RequiredDamageAreaCode(string damageAreaCode, bool isValidExpected)
	{
		var subject = new ID_InspectionDetailSegment();
		subject.DamageTypeCode = "LI";
		subject.DamageSeverityCode = "B";
		subject.DamageAreaCode = damageAreaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LI", true)]
	public void Validation_RequiredDamageTypeCode(string damageTypeCode, bool isValidExpected)
	{
		var subject = new ID_InspectionDetailSegment();
		subject.DamageAreaCode = "ub";
		subject.DamageSeverityCode = "B";
		subject.DamageTypeCode = damageTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredDamageSeverityCode(string damageSeverityCode, bool isValidExpected)
	{
		var subject = new ID_InspectionDetailSegment();
		subject.DamageAreaCode = "ub";
		subject.DamageTypeCode = "LI";
		subject.DamageSeverityCode = damageSeverityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
