using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2*1*U*r";

		var expected = new S2_StopOffAddress()
		{
			StopSequenceNumber = 1,
			AddressInformation = "U",
			AddressInformation2 = "r",
		};

		var actual = Map.MapObject<S2_StopOffAddress>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S2_StopOffAddress();
		subject.AddressInformation = "U";
		if (stopSequenceNumber > 0)
		subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new S2_StopOffAddress();
		subject.StopSequenceNumber = 1;
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
