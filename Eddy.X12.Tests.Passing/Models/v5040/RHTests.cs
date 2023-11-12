using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class RHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RH*qb*aZ*9";

		var expected = new RH_PersonalPropertyRate()
		{
			TariffServiceCode = "qb",
			RateValueQualifier = "aZ",
			FreightRate = 9,
		};

		var actual = Map.MapObject<RH_PersonalPropertyRate>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "aZ", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "aZ", true)]
	public void Validation_ARequiresBFreightRate(decimal freightRate, string rateValueQualifier, bool isValidExpected)
	{
		var subject = new RH_PersonalPropertyRate();
		//Required fields
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
