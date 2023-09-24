using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ISETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISE*iQKThz*cAQy*Vt";

		var expected = new ISE_DeferredDeliveryRequestSegment()
		{
			InterchangeDeliveryDate = "iQKThz",
			InterchangeDeliveryTime = "cAQy",
			InterchangeDeliveryTimeCode = "Vt",
		};

		var actual = Map.MapObject<ISE_DeferredDeliveryRequestSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iQKThz", true)]
	public void Validation_RequiredInterchangeDeliveryDate(string interchangeDeliveryDate, bool isValidExpected)
	{
		var subject = new ISE_DeferredDeliveryRequestSegment();
		subject.InterchangeDeliveryTime = "cAQy";
		subject.InterchangeDeliveryDate = interchangeDeliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cAQy", true)]
	public void Validation_RequiredInterchangeDeliveryTime(string interchangeDeliveryTime, bool isValidExpected)
	{
		var subject = new ISE_DeferredDeliveryRequestSegment();
		subject.InterchangeDeliveryDate = "iQKThz";
		subject.InterchangeDeliveryTime = interchangeDeliveryTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
