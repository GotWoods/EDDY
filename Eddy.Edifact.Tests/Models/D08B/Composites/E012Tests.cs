using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E012Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:N:Q:j";

		var expected = new E012_NameInformation()
		{
			PartyFunctionCodeQualifier = "k",
			PartyName = "N",
			PartyIdentifier = "Q",
			NameStatusCode = "j",
		};

		var actual = Map.MapComposite<E012_NameInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E012_NameInformation();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
