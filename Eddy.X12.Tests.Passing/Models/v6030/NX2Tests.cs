using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class NX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX2*Kk*e*Q4kss*LF*F";

		var expected = new NX2_LocationIDComponent()
		{
			AddressComponentQualifier = "Kk",
			AddressInformation = "e",
			CountyDesignatorCode = "Q4kss",
			AddressComponentQualifier2 = "LF",
			AddressInformation2 = "F",
		};

		var actual = Map.MapObject<NX2_LocationIDComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kk", true)]
	public void Validation_RequiredAddressComponentQualifier(string addressComponentQualifier, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressInformation = "e";
		//Test Parameters
		subject.AddressComponentQualifier = addressComponentQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressInformation2))
		{
			subject.AddressComponentQualifier2 = "LF";
			subject.AddressInformation2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressComponentQualifier = "Kk";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressInformation2))
		{
			subject.AddressComponentQualifier2 = "LF";
			subject.AddressInformation2 = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LF", "F", true)]
	[InlineData("LF", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredAddressComponentQualifier2(string addressComponentQualifier2, string addressInformation2, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressComponentQualifier = "Kk";
		subject.AddressInformation = "e";
		//Test Parameters
		subject.AddressComponentQualifier2 = addressComponentQualifier2;
		subject.AddressInformation2 = addressInformation2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
