using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class Y3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Y3*j*ie*z89UCYU8*fMt0vngr*cpksyU*FB*IGYEU0lZ*2Ss0*v*ZG*aR";

		var expected = new Y3_SpaceConfirmation()
		{
			BookingNumber = "j",
			StandardCarrierAlphaCode = "ie",
			Date = "z89UCYU8",
			Date2 = "fMt0vngr",
			StandardPointLocationCode = "cpksyU",
			PierName = "FB",
			Date3 = "IGYEU0lZ",
			Time = "2Ss0",
			TransportationMethodTypeCode = "v",
			TariffServiceCode = "ZG",
			TimeCode = "aR",
		};

		var actual = Map.MapObject<Y3_SpaceConfirmation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredBookingNumber(string bookingNumber, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		//Test Parameters
		subject.BookingNumber = bookingNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aR", "2Ss0", true)]
	[InlineData("aR", "", false)]
	[InlineData("", "2Ss0", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new Y3_SpaceConfirmation();
		//Required fields
		subject.BookingNumber = "j";
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
