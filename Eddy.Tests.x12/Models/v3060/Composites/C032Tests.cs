using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060.Composites;

public class C032Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "m*HpE*7SJ*6lH*1*iWa*b";

		var expected = new C032_EncryptionServiceInformation()
		{
			EncryptionServiceCode = "m",
			AlgorithmID = "HpE",
			AlgorithmModeOfOperation = "7SJ",
			FilterIDCode = "6lH",
			VersionIdentifier = "1",
			CompressionID = "iWa",
			VersionIdentifier2 = "b",
		};

		var actual = Map.MapObject<C032_EncryptionServiceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredEncryptionServiceCode(string encryptionServiceCode, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		//Test Parameters
		subject.EncryptionServiceCode = encryptionServiceCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier))
		{
			subject.FilterIDCode = "6lH";
			subject.VersionIdentifier = "1";
		}
		if(!string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.VersionIdentifier2))
		{
			subject.CompressionID = "iWa";
			subject.VersionIdentifier2 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6lH", "1", true)]
	[InlineData("6lH", "", false)]
	[InlineData("", "1", false)]
	public void Validation_AllAreRequiredFilterIDCode(string filterIDCode, string versionIdentifier, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		subject.EncryptionServiceCode = "m";
		//Test Parameters
		subject.FilterIDCode = filterIDCode;
		subject.VersionIdentifier = versionIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.CompressionID) || !string.IsNullOrEmpty(subject.VersionIdentifier2))
		{
			subject.CompressionID = "iWa";
			subject.VersionIdentifier2 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iWa", "b", true)]
	[InlineData("iWa", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredCompressionID(string compressionID, string versionIdentifier2, bool isValidExpected)
	{
		var subject = new C032_EncryptionServiceInformation();
		//Required fields
		subject.EncryptionServiceCode = "m";
		//Test Parameters
		subject.CompressionID = compressionID;
		subject.VersionIdentifier2 = versionIdentifier2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.FilterIDCode) || !string.IsNullOrEmpty(subject.VersionIdentifier))
		{
			subject.FilterIDCode = "6lH";
			subject.VersionIdentifier = "1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
