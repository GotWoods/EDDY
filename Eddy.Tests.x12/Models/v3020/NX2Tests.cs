using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class NX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX2*hW*p";

		var expected = new NX2_RealEstatePropertyIDComponent()
		{
			AddressComponentQualifier = "hW",
			AddressInformation = "p",
		};

		var actual = Map.MapObject<NX2_RealEstatePropertyIDComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hW", true)]
	public void Validation_RequiredAddressComponentQualifier(string addressComponentQualifier, bool isValidExpected)
	{
		var subject = new NX2_RealEstatePropertyIDComponent();
		//Required fields
		subject.AddressInformation = "p";
		//Test Parameters
		subject.AddressComponentQualifier = addressComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new NX2_RealEstatePropertyIDComponent();
		//Required fields
		subject.AddressComponentQualifier = "hW";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
