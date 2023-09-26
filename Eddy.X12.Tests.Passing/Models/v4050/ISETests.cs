using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class ISETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISE*jptLhy*fkpx*Rz";

		var expected = new ISE_DeferredDeliveryRequestSegment()
		{
			InterchangeDeliveryDate = "jptLhy",
			InterchangeDeliveryTime = "fkpx",
			InterchangeDeliveryTimeCode = "Rz",
		};

		var actual = Map.MapObject<ISE_DeferredDeliveryRequestSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jptLhy", true)]
	public void Validation_RequiredInterchangeDeliveryDate(string interchangeDeliveryDate, bool isValidExpected)
	{
		var subject = new ISE_DeferredDeliveryRequestSegment();
		//Required fields
		subject.InterchangeDeliveryTime = "fkpx";
		//Test Parameters
		subject.InterchangeDeliveryDate = interchangeDeliveryDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fkpx", true)]
	public void Validation_RequiredInterchangeDeliveryTime(string interchangeDeliveryTime, bool isValidExpected)
	{
		var subject = new ISE_DeferredDeliveryRequestSegment();
		//Required fields
		subject.InterchangeDeliveryDate = "jptLhy";
		//Test Parameters
		subject.InterchangeDeliveryTime = interchangeDeliveryTime;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
