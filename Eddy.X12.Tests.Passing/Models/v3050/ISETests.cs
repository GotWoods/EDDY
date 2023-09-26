using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ISETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISE*GUVhq6*jptS*DF";

		var expected = new ISE_DeferredDeliveryRequestSegment()
		{
			DeliveryDate = "GUVhq6",
			DeliveryTime = "jptS",
			DeliveryTimeCode = "DF",
		};

		var actual = Map.MapObject<ISE_DeferredDeliveryRequestSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GUVhq6", true)]
	public void Validation_RequiredDeliveryDate(string deliveryDate, bool isValidExpected)
	{
		var subject = new ISE_DeferredDeliveryRequestSegment();
		//Required fields
		subject.DeliveryTime = "jptS";
		//Test Parameters
		subject.DeliveryDate = deliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jptS", true)]
	public void Validation_RequiredDeliveryTime(string deliveryTime, bool isValidExpected)
	{
		var subject = new ISE_DeferredDeliveryRequestSegment();
		//Required fields
		subject.DeliveryDate = "GUVhq6";
		//Test Parameters
		subject.DeliveryTime = deliveryTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
