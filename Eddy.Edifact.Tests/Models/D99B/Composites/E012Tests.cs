using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E012Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "C:b:S:q";

		var expected = new E012_NameInformation()
		{
			PartyFunctionCodeQualifier = "C",
			PartyName = "b",
			PartyIdentifier = "S",
			NameStatusCoded = "q",
		};

		var actual = Map.MapComposite<E012_NameInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new E012_NameInformation();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
