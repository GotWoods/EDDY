using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E970Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:7:e";

		var expected = new E970_FrequentTravellerIdentification()
		{
			PartyName = "t",
			FrequentTravellerIdentifier = "7",
			TravellerReferenceIdentifier = "e",
		};

		var actual = Map.MapComposite<E970_FrequentTravellerIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E970_FrequentTravellerIdentification();
		//Required fields
		subject.FrequentTravellerIdentifier = "7";
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredFrequentTravellerIdentifier(string frequentTravellerIdentifier, bool isValidExpected)
	{
		var subject = new E970_FrequentTravellerIdentification();
		//Required fields
		subject.PartyName = "t";
		//Test Parameters
		subject.FrequentTravellerIdentifier = frequentTravellerIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
