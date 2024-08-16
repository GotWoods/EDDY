using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C090Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:q:i:a:n:C";

		var expected = new C090_AddressDetails()
		{
			AddressFormatCode = "H",
			AddressComponentDescription = "q",
			AddressComponentDescription2 = "i",
			AddressComponentDescription3 = "a",
			AddressComponentDescription4 = "n",
			AddressComponentDescription5 = "C",
		};

		var actual = Map.MapComposite<C090_AddressDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredAddressFormatCode(string addressFormatCode, bool isValidExpected)
	{
		var subject = new C090_AddressDetails();
		//Required fields
		subject.AddressComponentDescription = "q";
		//Test Parameters
		subject.AddressFormatCode = addressFormatCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredAddressComponentDescription(string addressComponentDescription, bool isValidExpected)
	{
		var subject = new C090_AddressDetails();
		//Required fields
		subject.AddressFormatCode = "H";
		//Test Parameters
		subject.AddressComponentDescription = addressComponentDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
