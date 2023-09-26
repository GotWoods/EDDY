using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class B9ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B9A*D4";

		var expected = new B9A_ServiceRequest()
		{
			ServiceRequestCode = "D4",
		};

		var actual = Map.MapObject<B9A_ServiceRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D4", true)]
	public void Validation_RequiredServiceRequestCode(string serviceRequestCode, bool isValidExpected)
	{
		var subject = new B9A_ServiceRequest();
		//Required fields
		//Test Parameters
		subject.ServiceRequestCode = serviceRequestCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
