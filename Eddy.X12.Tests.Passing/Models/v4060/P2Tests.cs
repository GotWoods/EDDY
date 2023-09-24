using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class P2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P2*X*2NGlVwxL*xXT";

		var expected = new P2_DeliveryDateInformation()
		{
			PickupOrDeliveryCode = "X",
			DeliveryDate = "2NGlVwxL",
			DateTimeQualifier = "xXT",
		};

		var actual = Map.MapObject<P2_DeliveryDateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2NGlVwxL", true)]
	public void Validation_RequiredDeliveryDate(string deliveryDate, bool isValidExpected)
	{
		var subject = new P2_DeliveryDateInformation();
		subject.DateTimeQualifier = "xXT";
		subject.DeliveryDate = deliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xXT", true)]
	public void Validation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
	{
		var subject = new P2_DeliveryDateInformation();
		subject.DeliveryDate = "2NGlVwxL";
		subject.DateTimeQualifier = dateTimeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
