using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E012Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "8:A:G:i";

		var expected = new E012_NameInformation()
		{
			PartyQualifier = "8",
			PartyName = "A",
			PartyIdentification = "G",
			NameStatusCoded = "i",
		};

		var actual = Map.MapComposite<E012_NameInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new E012_NameInformation();
		//Required fields
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
