using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class V5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V5*w*p*0B";

		var expected = new V5_VesselCode()
		{
			VesselCodeQualifier = "w",
			VesselCode = "p",
			CountryCode = "0B",
		};

		var actual = Map.MapObject<V5_VesselCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredVesselCodeQualifier(string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new V5_VesselCode();
		//Required fields
		subject.VesselCode = "p";
		subject.CountryCode = "0B";
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new V5_VesselCode();
		//Required fields
		subject.VesselCodeQualifier = "w";
		subject.CountryCode = "0B";
		//Test Parameters
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0B", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new V5_VesselCode();
		//Required fields
		subject.VesselCodeQualifier = "w";
		subject.VesselCode = "p";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
