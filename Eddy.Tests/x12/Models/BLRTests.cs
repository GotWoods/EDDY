using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BLRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLR*i1*mGgnd1oF*7B02";

		var expected = new BLR_TransportationCarrierIdentification()
		{
			StandardCarrierAlphaCode = "i1",
			Date = "mGgnd1oF",
			Time = "7B02",
		};

		var actual = Map.MapObject<BLR_TransportationCarrierIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i1", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BLR_TransportationCarrierIdentification();
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "mGgnd1oF", true)]
	[InlineData("7B02", "", false)]
	public void Validation_ARequiresBTime(string time, string date, bool isValidExpected)
	{
		var subject = new BLR_TransportationCarrierIdentification();
		subject.StandardCarrierAlphaCode = "i1";
		subject.Time = time;
		subject.Date = date;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
