using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E970Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "J:N:i";

		var expected = new E970_FrequentTravellerIdentification()
		{
			PartyName = "J",
			FrequentTravellerIdentification = "N",
			TravellerReferenceNumber = "i",
		};

		var actual = Map.MapComposite<E970_FrequentTravellerIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredPartyName(string partyName, bool isValidExpected)
	{
		var subject = new E970_FrequentTravellerIdentification();
		//Required fields
		subject.FrequentTravellerIdentification = "N";
		//Test Parameters
		subject.PartyName = partyName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredFrequentTravellerIdentification(string frequentTravellerIdentification, bool isValidExpected)
	{
		var subject = new E970_FrequentTravellerIdentification();
		//Required fields
		subject.PartyName = "J";
		//Test Parameters
		subject.FrequentTravellerIdentification = frequentTravellerIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
