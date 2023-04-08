using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class B9ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B9A*wZ";

		var expected = new B9A_ServiceRequest()
		{
			ServiceRequestCode = "wZ",
		};

		var actual = Map.MapObject<B9A_ServiceRequest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wZ", true)]
	public void Validatation_RequiredServiceRequestCode(string serviceRequestCode, bool isValidExpected)
	{
		var subject = new B9A_ServiceRequest();
		subject.ServiceRequestCode = serviceRequestCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
