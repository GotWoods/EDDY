using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class F02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F02*VZdeLBwc*9*m*gm*a*2M*v*V*pT";

		var expected = new F02_IdentificationOfShipment()
		{
			Date = "VZdeLBwc",
			EquipmentInitial = "9",
			EquipmentNumber = "m",
			ReferenceIdentificationQualifier = "gm",
			ReferenceIdentification = "a",
			ReferenceIdentificationQualifier2 = "2M",
			ReferenceIdentification2 = "v",
			VesselCode = "V",
			VesselName = "pT",
		};

		var actual = Map.MapObject<F02_IdentificationOfShipment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gm", "a", true)]
	[InlineData("gm", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new F02_IdentificationOfShipment();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "2M";
			subject.ReferenceIdentification2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2M", "v", true)]
	[InlineData("2M", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new F02_IdentificationOfShipment();
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "gm";
			subject.ReferenceIdentification = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
