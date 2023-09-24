using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class EFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EFI*o7*O*5E*4*P*t*T*v*n*sj*q*d*T*J";

		var expected = new EFI_ElectronicFormatIdentification()
		{
			SecurityLevelCode = "o7",
			FreeFormMessageText = "O",
			SecurityTechniqueCode = "5E",
			VersionIdentifier = "4",
			ProgramIdentifier = "P",
			VersionIdentifier2 = "t",
			InterchangeFormat = "T",
			VersionIdentifier3 = "v",
			CompressionTechnique = "n",
			DrawingSheetSizeCode = "sj",
			FileName = "q",
			BlockType = "d",
			RecordLength = "T",
			BlockLength = "J",
		};

		var actual = Map.MapObject<EFI_ElectronicFormatIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o7", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = securityLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("P", "4", true)]
	[InlineData("P", "", false)]
	[InlineData("", "4", true)]
	public void Validation_ARequiresBProgramIdentifier(string programIdentifier, string versionIdentifier, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = "o7";
		subject.ProgramIdentifier = programIdentifier;
		subject.VersionIdentifier = versionIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("T", "t", true)]
	[InlineData("T", "", false)]
	[InlineData("", "t", true)]
	public void Validation_ARequiresBInterchangeFormat(string interchangeFormat, string versionIdentifier2, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = "o7";
		subject.InterchangeFormat = interchangeFormat;
		subject.VersionIdentifier2 = versionIdentifier2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "v", true)]
	[InlineData("n", "", false)]
	[InlineData("", "v", true)]
	public void Validation_ARequiresBCompressionTechnique(string compressionTechnique, string versionIdentifier3, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = "o7";
		subject.CompressionTechnique = compressionTechnique;
		subject.VersionIdentifier3 = versionIdentifier3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
