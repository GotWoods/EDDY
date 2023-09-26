using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class RTTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RTT*MM*1";

		var expected = new RTT_FreightRateInformation()
		{
			RateValueQualifier = "MM",
			FreightRate = 1,
		};

		var actual = Map.MapObject<RTT_FreightRateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MM", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RTT_FreightRateInformation();
		//Required fields
		subject.FreightRate = 1;
		//Test Parameters
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RTT_FreightRateInformation();
		//Required fields
		subject.RateValueQualifier = "MM";
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
