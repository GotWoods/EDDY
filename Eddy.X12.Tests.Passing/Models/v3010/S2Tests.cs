using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class S2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2*6*x*r";

		var expected = new S2_StopOffAddress()
		{
			StopSequenceNumber = 6,
			AdditionalNameAddressData = "x",
			AdditionalNameAddressData2 = "r",
		};

		var actual = Map.MapObject<S2_StopOffAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S2_StopOffAddress();
		subject.AdditionalNameAddressData = "x";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredAdditionalNameAddressData(string additionalNameAddressData, bool isValidExpected)
	{
		var subject = new S2_StopOffAddress();
		subject.StopSequenceNumber = 6;
		subject.AdditionalNameAddressData = additionalNameAddressData;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
