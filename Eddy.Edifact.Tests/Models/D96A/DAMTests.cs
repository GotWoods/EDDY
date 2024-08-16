using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class DAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DAM+E++++";

		var expected = new DAM_Damage()
		{
			DamageDetailsQualifier = "E",
			TypeOfDamage = null,
			DamageArea = null,
			DamageSeverity = null,
			Action = null,
		};

		var actual = Map.MapObject<DAM_Damage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredDamageDetailsQualifier(string damageDetailsQualifier, bool isValidExpected)
	{
		var subject = new DAM_Damage();
		//Required fields
		//Test Parameters
		subject.DamageDetailsQualifier = damageDetailsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
