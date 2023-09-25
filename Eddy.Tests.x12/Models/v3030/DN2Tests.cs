using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DN2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DN2*x*u*2";

		var expected = new DN2_ToothSummary()
		{
			ReferenceNumber = "x",
			ToothStatusCode = "u",
			Quantity = 2,
		};

		var actual = Map.MapObject<DN2_ToothSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new DN2_ToothSummary();
		//Required fields
		subject.ToothStatusCode = "u";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredToothStatusCode(string toothStatusCode, bool isValidExpected)
	{
		var subject = new DN2_ToothSummary();
		//Required fields
		subject.ReferenceNumber = "x";
		//Test Parameters
		subject.ToothStatusCode = toothStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
