using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class AK1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK1*kl*6*M";

		var expected = new AK1_FunctionalGroupResponseHeader()
		{
			FunctionalIdentifierCode = "kl",
			GroupControlNumber = 6,
			VersionReleaseIndustryIdentifierCode = "M",
		};

		var actual = Map.MapObject<AK1_FunctionalGroupResponseHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kl", true)]
	public void Validation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
	{
		var subject = new AK1_FunctionalGroupResponseHeader();
		subject.GroupControlNumber = 6;
		subject.FunctionalIdentifierCode = functionalIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new AK1_FunctionalGroupResponseHeader();
		subject.FunctionalIdentifierCode = "kl";
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
