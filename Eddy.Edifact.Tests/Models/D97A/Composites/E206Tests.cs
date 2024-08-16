using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E206Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "G:r:O";

		var expected = new E206_IdentificationNumber()
		{
			IdentityNumber = "G",
			IdentityNumberQualifier = "r",
			StatusCoded = "O",
		};

		var actual = Map.MapComposite<E206_IdentificationNumber>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredIdentityNumber(string identityNumber, bool isValidExpected)
	{
		var subject = new E206_IdentificationNumber();
		//Required fields
		//Test Parameters
		subject.IdentityNumber = identityNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
