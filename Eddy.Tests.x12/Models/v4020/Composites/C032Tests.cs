using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4020;
using Eddy.x12.Models.v4020.Composites;

namespace Eddy.x12.Tests.Models.v4020.Composites;

public class C032Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "J*Rx4*ocZ*K5R*T*FNS*f*j";

		var expected = new C032_EncryptionServiceInformation()
		{
			EncryptionServiceCode = "J",
			AlgorithmID = "Rx4",
			AlgorithmModeOfOperation = "ocZ",
			FilterIDCode = "K5R",
			VersionIdentifier = "T",
			CompressionID = "FNS",
			VersionIdentifier2 = "f",
			LengthOfInitializationVector = "j",
		};

		var actual = Map.MapObject<C032_EncryptionServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredEncryptionServiceCode(string encryptionServiceCode, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		//Test Parameters
		subject.EncryptionServiceCode = encryptionServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier))
		{
			subject.FilterIDCode = "K5R";
			subject.VersionIdentifier = "T";
		}
		if(!string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.VersionIdentifier2))
		{
			subject.CompressionID = "FNS";
			subject.VersionIdentifier2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K5R", "T", true)]
	[InlineData("K5R", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredFilterIDCode(string filterIDCode, string versionIdentifier, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		subject.EncryptionServiceCode = "J";
		//Test Parameters
		subject.FilterIDCode = filterIDCode;
		subject.VersionIdentifier = versionIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.VersionIdentifier2))
		{
			subject.CompressionID = "FNS";
			subject.VersionIdentifier2 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("FNS", "f", true)]
	[InlineData("FNS", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredCompressionID(string compressionID, string versionIdentifier2, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		subject.EncryptionServiceCode = "J";
		//Test Parameters
		subject.CompressionID = compressionID;
		subject.VersionIdentifier2 = versionIdentifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier))
		{
			subject.FilterIDCode = "K5R";
			subject.VersionIdentifier = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
