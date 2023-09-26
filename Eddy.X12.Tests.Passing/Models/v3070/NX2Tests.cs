using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class NX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX2*Qa*X*UAVSF";

		var expected = new NX2_LocationIDComponent()
		{
			AddressComponentQualifier = "Qa",
			AddressInformation = "X",
			CountyDesignator = "UAVSF",
		};

		var actual = Map.MapObject<NX2_LocationIDComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qa", true)]
	public void Validation_RequiredAddressComponentQualifier(string addressComponentQualifier, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressInformation = "X";
		//Test Parameters
		subject.AddressComponentQualifier = addressComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		//Required fields
		subject.AddressComponentQualifier = "Qa";
		//Test Parameters
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
