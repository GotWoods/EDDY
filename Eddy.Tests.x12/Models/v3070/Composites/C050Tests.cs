using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3070;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Tests.Models.v3070.Composites;

public class C050Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "Ek*Jq2*4*V*Bj*YeD*m*2*dx*w3Q*y*j";

		var expected = new C050_CertificateLookUpInformation()
		{
			LookUpValueProtocolCode = "Ek",
			FilterIDCode = "Jq2",
			VersionIdentifier = "4",
			LookUpValue = "V",
			LookUpValueProtocolCode2 = "Bj",
			FilterIDCode2 = "YeD",
			VersionIdentifier2 = "m",
			LookUpValue2 = "2",
			LookUpValueProtocolCode3 = "dx",
			FilterIDCode3 = "w3Q",
			VersionIdentifier3 = "y",
			LookUpValue3 = "j",
		};

		var actual = Map.MapObject<C050_CertificateLookUpInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ek", true)]
	public void Validation_RequiredLookUpValueProtocolCode(string lookUpValueProtocolCode, bool isValidExpected)
	{
		var subject = new C050_CertificateLookUpInformation();
		//Required fields
		subject.FilterIDCode = "Jq2";
		subject.VersionIdentifier = "4";
		subject.LookUpValue = "V";
		//Test Parameters
		subject.LookUpValueProtocolCode = lookUpValueProtocolCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jq2", true)]
	public void Validation_RequiredFilterIDCode(string filterIDCode, bool isValidExpected)
	{
		var subject = new C050_CertificateLookUpInformation();
		//Required fields
		subject.LookUpValueProtocolCode = "Ek";
		subject.VersionIdentifier = "4";
		subject.LookUpValue = "V";
		//Test Parameters
		subject.FilterIDCode = filterIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredVersionIdentifier(string versionIdentifier, bool isValidExpected)
	{
		var subject = new C050_CertificateLookUpInformation();
		//Required fields
		subject.LookUpValueProtocolCode = "Ek";
		subject.FilterIDCode = "Jq2";
		subject.LookUpValue = "V";
		//Test Parameters
		subject.VersionIdentifier = versionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredLookUpValue(string lookUpValue, bool isValidExpected)
	{
		var subject = new C050_CertificateLookUpInformation();
		//Required fields
		subject.LookUpValueProtocolCode = "Ek";
		subject.FilterIDCode = "Jq2";
		subject.VersionIdentifier = "4";
		//Test Parameters
		subject.LookUpValue = lookUpValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
