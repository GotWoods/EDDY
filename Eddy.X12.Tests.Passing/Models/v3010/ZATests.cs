using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class ZATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ZA*h3*2*cz*xxW*eCKWpf*Yu*O";

		var expected = new ZA_ProductActivityReporting()
		{
			ActivityCode = "h3",
			Quantity = 2,
			UnitOfMeasurementCode = "cz",
			DateTimeQualifier = "xxW",
			Date = "eCKWpf",
			ReferenceNumberQualifier = "Yu",
			ReferenceNumber = "O",
		};

		var actual = Map.MapObject<ZA_ProductActivityReporting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h3", true)]
	public void Validation_RequiredActivityCode(string activityCode, bool isValidExpected)
	{
		var subject = new ZA_ProductActivityReporting();
		//Required fields
		//Test Parameters
		subject.ActivityCode = activityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
