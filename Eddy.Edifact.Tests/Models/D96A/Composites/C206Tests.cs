using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C206Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "I:S:N";

		var expected = new C206_IdentificationNumber()
		{
			IdentityNumber = "I",
			IdentityNumberQualifier = "S",
			StatusCoded = "N",
		};

		var actual = Map.MapComposite<C206_IdentificationNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredIdentityNumber(string identityNumber, bool isValidExpected)
	{
		var subject = new C206_IdentificationNumber();
		//Required fields
		//Test Parameters
		subject.IdentityNumber = identityNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
