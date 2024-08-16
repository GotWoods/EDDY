using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C208Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:K";

		var expected = new C208_IdentityNumberRange()
		{
			IdentityNumber = "3",
			IdentityNumber2 = "K",
		};

		var actual = Map.MapComposite<C208_IdentityNumberRange>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredIdentityNumber(string identityNumber, bool isValidExpected)
	{
		var subject = new C208_IdentityNumberRange();
		//Required fields
		//Test Parameters
		subject.IdentityNumber = identityNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
