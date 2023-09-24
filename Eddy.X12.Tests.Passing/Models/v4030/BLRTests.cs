using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BLRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLR*rH*dqf8Eyf3*cZ6t";

		var expected = new BLR_TransportationCarrierIdentification()
		{
			StandardCarrierAlphaCode = "rH",
			Date = "dqf8Eyf3",
			Time = "cZ6t",
		};

		var actual = Map.MapObject<BLR_TransportationCarrierIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rH", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BLR_TransportationCarrierIdentification();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cZ6t", "dqf8Eyf3", true)]
	[InlineData("cZ6t", "", false)]
	[InlineData("", "dqf8Eyf3", true)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new BLR_TransportationCarrierIdentification();
		subject.StandardCarrierAlphaCode = "rH";
		subject.Time = time;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
