using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E001Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "g:h:E:W:e:w:5";

		var expected = new E001_AddressDetails()
		{
			AddressFormatCoded = "g",
			AddressComponent = "h",
			AddressComponent2 = "E",
			AddressComponent3 = "W",
			AddressComponent4 = "e",
			AddressComponent5 = "w",
			AddressComponent6 = "5",
		};

		var actual = Map.MapComposite<E001_AddressDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredAddressFormatCoded(string addressFormatCoded, bool isValidExpected)
	{
		var subject = new E001_AddressDetails();
		//Required fields
		subject.AddressComponent = "h";
		//Test Parameters
		subject.AddressFormatCoded = addressFormatCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredAddressComponent(string addressComponent, bool isValidExpected)
	{
		var subject = new E001_AddressDetails();
		//Required fields
		subject.AddressFormatCoded = "g";
		//Test Parameters
		subject.AddressComponent = addressComponent;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
