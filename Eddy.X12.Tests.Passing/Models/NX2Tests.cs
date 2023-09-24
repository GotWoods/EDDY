using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NX2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NX2*Xr*r*TZhO4*qR*F";

		var expected = new NX2_LocationIDComponent()
		{
			AddressComponentQualifier = "Xr",
			AddressInformation = "r",
			CountyDesignatorCode = "TZhO4",
			AddressComponentQualifier2 = "qR",
			AddressInformation2 = "F",
		};

		var actual = Map.MapObject<NX2_LocationIDComponent>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xr", true)]
	public void Validation_RequiredAddressComponentQualifier(string addressComponentQualifier, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		subject.AddressInformation = "r";
		subject.AddressComponentQualifier = addressComponentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredAddressInformation(string addressInformation, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		subject.AddressComponentQualifier = "Xr";
		subject.AddressInformation = addressInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("qR", "F", true)]
	[InlineData("", "F", false)]
	[InlineData("qR", "", false)]
	public void Validation_AllAreRequiredAddressComponentQualifier2(string addressComponentQualifier2, string addressInformation2, bool isValidExpected)
	{
		var subject = new NX2_LocationIDComponent();
		subject.AddressComponentQualifier = "Xr";
		subject.AddressInformation = "r";
		subject.AddressComponentQualifier2 = addressComponentQualifier2;
		subject.AddressInformation2 = addressInformation2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
