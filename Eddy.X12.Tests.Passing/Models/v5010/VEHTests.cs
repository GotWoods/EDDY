using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class VEHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VEH*7*x*9415*2F*S*q*w*8*T*wb*F*b*l*t*p*i*DT*W*rW";

		var expected = new VEH_VehicleInformation()
		{
			AssignedNumber = 7,
			VehicleIdentificationNumber = "x",
			Year = 9415,
			AgencyQualifierCode = "2F",
			ReferenceIdentification = "S",
			ReferenceIdentification2 = "q",
			ReferenceIdentification3 = "w",
			Length = 8,
			ReferenceIdentification4 = "T",
			StateOrProvinceCode = "wb",
			LocationIdentifier = "F",
			YesNoConditionOrResponseCode = "b",
			Amount = "l",
			YesNoConditionOrResponseCode2 = "t",
			Amount2 = "p",
			ActionCode = "i",
			CountryCode = "DT",
			Name = "W",
			CountryCode2 = "rW",
		};

		var actual = Map.MapObject<VEH_VehicleInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("2F", "S", "w", true)]
	[InlineData("2F", "", "", false)]
	[InlineData("", "S", "w", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_AgencyQualifierCode(string agencyQualifierCode, string referenceIdentification, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//A Requires B
		if (referenceIdentification != "")
			subject.AgencyQualifierCode = "2F";
		if (referenceIdentification3 != "")
			subject.AgencyQualifierCode = "2F";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "W";
			subject.CountryCode2 = "rW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "2F", true)]
	[InlineData("S", "", false)]
	[InlineData("", "2F", true)]
	public void Validation_ARequiresBReferenceIdentification(string referenceIdentification, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "W";
			subject.CountryCode2 = "rW";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentification3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("w", "2F", true)]
	[InlineData("w", "", false)]
	[InlineData("", "2F", true)]
	public void Validation_ARequiresBReferenceIdentification3(string referenceIdentification3, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification3 = referenceIdentification3;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.Name) || !string.IsNullOrEmpty(subject.CountryCode2))
		{
			subject.Name = "W";
			subject.CountryCode2 = "rW";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentification = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "rW", true)]
	[InlineData("W", "", false)]
	[InlineData("", "rW", false)]
	public void Validation_AllAreRequiredName(string name, string countryCode2, bool isValidExpected)
	{
		var subject = new VEH_VehicleInformation();
		//Required fields
		//Test Parameters
		subject.Name = name;
		subject.CountryCode2 = countryCode2;
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.AgencyQualifierCode) || !string.IsNullOrEmpty(subject.ReferenceIdentification) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.AgencyQualifierCode = "2F";
			subject.ReferenceIdentification = "S";
			subject.ReferenceIdentification3 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
