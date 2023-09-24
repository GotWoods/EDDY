using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class V5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "V5*G*u*bT";

		var expected = new V5_VesselIdentification()
		{
			VesselCodeQualifier = "G",
			VesselCode = "u",
			CountryCode = "bT",
		};

		var actual = Map.MapObject<V5_VesselIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredVesselCodeQualifier(string vesselCodeQualifier, bool isValidExpected)
	{
		var subject = new V5_VesselIdentification();
		subject.VesselCode = "u";
		subject.CountryCode = "bT";
		subject.VesselCodeQualifier = vesselCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new V5_VesselIdentification();
		subject.VesselCodeQualifier = "G";
		subject.CountryCode = "bT";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bT", true)]
	public void Validation_RequiredCountryCode(string countryCode, bool isValidExpected)
	{
		var subject = new V5_VesselIdentification();
		subject.VesselCodeQualifier = "G";
		subject.VesselCode = "u";
		subject.CountryCode = countryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
