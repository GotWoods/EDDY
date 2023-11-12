using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class NX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX2*6I*9*iAJVU*XG*T";

		var expected = new NX2_LocationIDComponent()
		{
			AddressComponentQualifier = "6I",
			AddressInformation = "9",
			CountyDesignator = "iAJVU",
			AddressComponentQualifier2 = "XG",
			AddressInformation2 = "T",
		};

		var actual = Map.MapObject<NX2_LocationIDComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6I", true)]
	public void Validation_RequiredAddressComponentQualifier(string addressComponentQualifier, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressInformation = "9";
		//Test Parameters
		subject.AddressComponentQualifier = addressComponentQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressInformation2))
		{
			subject.AddressComponentQualifier2 = "XG";
			subject.AddressInformation2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressComponentQualifier = "6I";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressComponentQualifier2) || !string.IsNullOrEmpty(subject.AddressInformation2))
		{
			subject.AddressComponentQualifier2 = "XG";
			subject.AddressInformation2 = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XG", "T", true)]
	[InlineData("XG", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredAddressComponentQualifier2(string addressComponentQualifier2, string addressInformation2, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressComponentQualifier = "6I";
		subject.AddressInformation = "9";
		//Test Parameters
		subject.AddressComponentQualifier2 = addressComponentQualifier2;
		subject.AddressInformation2 = addressInformation2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
