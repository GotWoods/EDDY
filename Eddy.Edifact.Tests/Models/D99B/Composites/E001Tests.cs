using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E001Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:i:u:T:d:Z:k";

		var expected = new E001_AddressDetails()
		{
			AddressFormatCode = "i",
			AddressComponent = "i",
			AddressComponent2 = "u",
			AddressComponent3 = "T",
			AddressComponent4 = "d",
			AddressComponent5 = "Z",
			AddressComponent6 = "k",
		};

		var actual = Map.MapComposite<E001_AddressDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAddressFormatCode(string addressFormatCode, bool isValidExpected)
	{
		var subject = new E001_AddressDetails();
		//Required fields
		subject.AddressComponent = "i";
		//Test Parameters
		subject.AddressFormatCode = addressFormatCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAddressComponent(string addressComponent, bool isValidExpected)
	{
		var subject = new E001_AddressDetails();
		//Required fields
		subject.AddressFormatCode = "i";
		//Test Parameters
		subject.AddressComponent = addressComponent;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
