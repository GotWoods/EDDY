using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030;
using Eddy.x12.Models.v6030.Composites;

namespace Eddy.x12.Tests.Models.v6030.Composites;

public class C032Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "U*gwn*Nu3*acP*b*UjF*y*6";

		var expected = new C032_EncryptionServiceInformation()
		{
			EncryptionServiceCode = "U",
			AlgorithmIDCode = "gwn",
			AlgorithmModeOfOperationCode = "Nu3",
			FilterIDCode = "acP",
			VersionIdentifier = "b",
			CompressionIDCode = "UjF",
			VersionIdentifier2 = "y",
			LengthOfInitializationVector = "6",
		};

		var actual = Map.MapObject<C032_EncryptionServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredEncryptionServiceCode(string encryptionServiceCode, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		//Test Parameters
		subject.EncryptionServiceCode = encryptionServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier))
		{
			subject.FilterIDCode = "acP";
			subject.VersionIdentifier = "b";
		}
		if(!string.IsNullOrEmpty(subject.CompressionIDCode) || !string.IsNullOrEmpty(subject.CompressionIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier2))
		{
			subject.CompressionIDCode = "UjF";
			subject.VersionIdentifier2 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("acP", "b", true)]
	[InlineData("acP", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredFilterIDCode(string filterIDCode, string versionIdentifier, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		subject.EncryptionServiceCode = "U";
		//Test Parameters
		subject.FilterIDCode = filterIDCode;
		subject.VersionIdentifier = versionIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CompressionIDCode) || !string.IsNullOrEmpty(subject.CompressionIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier2))
		{
			subject.CompressionIDCode = "UjF";
			subject.VersionIdentifier2 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("UjF", "y", true)]
	[InlineData("UjF", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredCompressionIDCode(string compressionIDCode, string versionIdentifier2, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		subject.EncryptionServiceCode = "U";
		//Test Parameters
		subject.CompressionIDCode = compressionIDCode;
		subject.VersionIdentifier2 = versionIdentifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier))
		{
			subject.FilterIDCode = "acP";
			subject.VersionIdentifier = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
