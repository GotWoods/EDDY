using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C090Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:4:A:p:B:X";

		var expected = new C090_AddressDetails()
		{
			AddressFormatCoded = "w",
			AddressComponent = "4",
			AddressComponent2 = "A",
			AddressComponent3 = "p",
			AddressComponent4 = "B",
			AddressComponent5 = "X",
		};

		var actual = Map.MapComposite<C090_AddressDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredAddressFormatCoded(string addressFormatCoded, bool isValidExpected)
	{
		var subject = new C090_AddressDetails();
		//Required fields
		subject.AddressComponent = "4";
		//Test Parameters
		subject.AddressFormatCoded = addressFormatCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredAddressComponent(string addressComponent, bool isValidExpected)
	{
		var subject = new C090_AddressDetails();
		//Required fields
		subject.AddressFormatCoded = "w";
		//Test Parameters
		subject.AddressComponent = addressComponent;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
