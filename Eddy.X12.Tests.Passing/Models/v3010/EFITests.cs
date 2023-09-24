using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class EFITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EFI*K8*H*I9*y*E*o*4*A*i*J4*M*B*t*o";

		var expected = new EFI_ElectronicFormatIdentification()
		{
			SecurityLevelCode = "K8",
			FreeFormMessageText = "H",
			SecurityTechniqueCode = "I9",
			VersionIdentifier = "y",
			ProgramIdentifier = "E",
			VersionIdentifier2 = "o",
			InterchangeFormat = "4",
			VersionIdentifier3 = "A",
			CompressionTechnique = "i",
			DrawingSheetSizeCode = "J4",
			FileName = "M",
			BlockType = "B",
			RecordLength = "t",
			BlockLength = "o",
		};

		var actual = Map.MapObject<EFI_ElectronicFormatIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K8", true)]
	public void Validation_RequiredSecurityLevelCode(string securityLevelCode, bool isValidExpected)
	{
		var subject = new EFI_ElectronicFormatIdentification();
		subject.SecurityLevelCode = securityLevelCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
