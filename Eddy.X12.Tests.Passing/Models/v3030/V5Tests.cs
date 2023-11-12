using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class V5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V5*1*2*ry";

		var expected = new V5_VesselCode()
		{
			VesselCodeQualifier = "1",
			VesselCode = "2",
			CountryCode = "ry",
		};

		var actual = Map.MapObject<V5_VesselCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredVesselCodeQualifier(string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new V5_VesselCode();
		//Required fields
		subject.VesselCode = "2";
		subject.CountryCode = "ry";
		//Test Parameters
		subject.VesselCodeQualifier = vesselCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new V5_VesselCode();
		//Required fields
		subject.VesselCodeQualifier = "1";
		subject.CountryCode = "ry";
		//Test Parameters
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ry", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new V5_VesselCode();
		//Required fields
		subject.VesselCodeQualifier = "1";
		subject.VesselCode = "2";
		//Test Parameters
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
