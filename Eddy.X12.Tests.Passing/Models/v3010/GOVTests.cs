using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class GOVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GOV*yp*u*7";

		var expected = new GOV_MilitaryStandard1840ARecordDefinition()
		{
			AssociationQualifierCode = "yp",
			RecordFileQualifier = "u",
			RecordFormatData = "7",
		};

		var actual = Map.MapObject<GOV_MilitaryStandard1840ARecordDefinition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yp", true)]
	public void Validation_RequiredAssociationQualifierCode(string associationQualifierCode, bool isValidExpected)
	{
		var subject = new GOV_MilitaryStandard1840ARecordDefinition();
		subject.AssociationQualifierCode = associationQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
