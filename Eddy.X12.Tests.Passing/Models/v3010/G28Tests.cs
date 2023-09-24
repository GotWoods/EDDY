using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G28Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G28*RWjXOJO1D9An*4eFdhCoAugBg*jO*5*qm*u";

		var expected = new G28_LineItemNumbers()
		{
			UPCCaseCode = "RWjXOJO1D9An",
			UPCConsumerPackageCode = "4eFdhCoAugBg",
			ProductServiceIDQualifier = "jO",
			ProductServiceID = "5",
			ProductServiceIDQualifier2 = "qm",
			ProductServiceID2 = "u",
		};

		var actual = Map.MapObject<G28_LineItemNumbers>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RWjXOJO1D9An", true)]
	public void Validation_RequiredUPCCaseCode(string uPCCaseCode, bool isValidExpected)
	{
		var subject = new G28_LineItemNumbers();
		subject.UPCCaseCode = uPCCaseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
