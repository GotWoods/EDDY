using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E001Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:C:4:Y:f:y:C";

		var expected = new E001_AddressDetails()
		{
			AddressFormatCode = "W",
			AddressComponentDescription = "C",
			AddressComponentDescription2 = "4",
			AddressComponentDescription3 = "Y",
			AddressComponentDescription4 = "f",
			AddressComponentDescription5 = "y",
			AddressComponentDescription6 = "C",
		};

		var actual = Map.MapComposite<E001_AddressDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredAddressFormatCode(string addressFormatCode, bool isValidExpected)
	{
		var subject = new E001_AddressDetails();
		//Required fields
		subject.AddressComponentDescription = "C";
		//Test Parameters
		subject.AddressFormatCode = addressFormatCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredAddressComponentDescription(string addressComponentDescription, bool isValidExpected)
	{
		var subject = new E001_AddressDetails();
		//Required fields
		subject.AddressFormatCode = "W";
		//Test Parameters
		subject.AddressComponentDescription = addressComponentDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
