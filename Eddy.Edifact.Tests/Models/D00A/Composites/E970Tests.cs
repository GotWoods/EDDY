using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E970Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "5:3:L";

		var expected = new E970_FrequentTravellerIdentification()
		{
			PartyName = "5",
			FrequentTravellerIdentifier = "3",
			TravellerReferenceIdentifier = "L",
		};

		var actual = Map.MapComposite<E970_FrequentTravellerIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E970_FrequentTravellerIdentification();
		//Required fields
		subject.FrequentTravellerIdentifier = "3";
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredFrequentTravellerIdentifier(string frequentTravellerIdentifier, bool isValidExpected)
	{
		var subject = new E970_FrequentTravellerIdentification();
		//Required fields
		subject.PartyName = "5";
		//Test Parameters
		subject.FrequentTravellerIdentifier = frequentTravellerIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
