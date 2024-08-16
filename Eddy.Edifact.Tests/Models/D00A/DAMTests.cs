using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DAM+W++++";

		var expected = new DAM_Damage()
		{
			DamageDetailsCodeQualifier = "W",
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
	[InlineData("W", true)]
	public void Validation_RequiredDamageDetailsCodeQualifier(string damageDetailsCodeQualifier, bool isValidExpected)
	{
		var subject = new DAM_Damage();
		//Required fields
		//Test Parameters
		subject.DamageDetailsCodeQualifier = damageDetailsCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
