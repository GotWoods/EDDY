using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class EFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EFI*jt*Z*m9*E*G*6*1*0*8*3e*W*6*y*s*A*4x9";

		var expected = new EFI_ElectronicFormatIdentification()
		{
			SecurityLevelCode = "jt",
			FreeFormMessageText = "Z",
			SecurityTechniqueCode = "m9",
			VersionIdentifier = "E",
			ProgramIdentifier = "G",
			VersionIdentifier2 = "6",
			InterchangeFormat = "1",
			VersionIdentifier3 = "0",
			CompressionTechnique = "8",
			DrawingSheetSizeCode = "3e",
			FileName = "W",
			BlockType = "6",
			RecordLength = "y",
			BlockLength = "s",
			VersionIdentifier4 = "A",
			FilterIDCode = "4x9",
		};

		var actual = Map.MapObject<EFI_ElectronicFormatIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jt", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = securityLevelCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.FilterIDCode))
		{
			subject.VersionIdentifier4 = "A";
			subject.FilterIDCode = "4x9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "E", true)]
	[InlineData("G", "", false)]
	[InlineData("", "E", true)]
	public void Validation_ARequiresBProgramIdentifier(string programIdentifier, string versionIdentifier, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = "jt";
		subject.ProgramIdentifier = programIdentifier;
		subject.VersionIdentifier = versionIdentifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.FilterIDCode))
		{
			subject.VersionIdentifier4 = "A";
			subject.FilterIDCode = "4x9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "6", true)]
	[InlineData("1", "", false)]
	[InlineData("", "6", true)]
	public void Validation_ARequiresBInterchangeFormat(string interchangeFormat, string versionIdentifier2, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = "jt";
		subject.InterchangeFormat = interchangeFormat;
		subject.VersionIdentifier2 = versionIdentifier2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.FilterIDCode))
		{
			subject.VersionIdentifier4 = "A";
			subject.FilterIDCode = "4x9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "0", true)]
	[InlineData("8", "", false)]
	[InlineData("", "0", true)]
	public void Validation_ARequiresBCompressionTechnique(string compressionTechnique, string versionIdentifier3, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = "jt";
		subject.CompressionTechnique = compressionTechnique;
		subject.VersionIdentifier3 = versionIdentifier3;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.VersionIdentifier4) || !string.IsNullOrEmpty(subject.FilterIDCode))
		{
			subject.VersionIdentifier4 = "A";
			subject.FilterIDCode = "4x9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "4x9", true)]
	[InlineData("A", "", false)]
	[InlineData("", "4x9", false)]
	public void Validation_AllAreRequiredVersionIdentifier4(string versionIdentifier4, string filterIDCode, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = "jt";
		subject.VersionIdentifier4 = versionIdentifier4;
		subject.FilterIDCode = filterIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
