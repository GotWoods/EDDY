using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C090Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:N:V:e:o:0";

		var expected = new C090_AddressDetails()
		{
			AddressFormatCode = "a",
			AddressComponent = "N",
			AddressComponent2 = "V",
			AddressComponent3 = "e",
			AddressComponent4 = "o",
			AddressComponent5 = "0",
		};

		var actual = Map.MapComposite<C090_AddressDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredAddressFormatCode(string addressFormatCode, bool isValidExpected)
	{
		var subject = new C090_AddressDetails();
		//Required fields
		subject.AddressComponent = "N";
		//Test Parameters
		subject.AddressFormatCode = addressFormatCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredAddressComponent(string addressComponent, bool isValidExpected)
	{
		var subject = new C090_AddressDetails();
		//Required fields
		subject.AddressFormatCode = "a";
		//Test Parameters
		subject.AddressComponent = addressComponent;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
