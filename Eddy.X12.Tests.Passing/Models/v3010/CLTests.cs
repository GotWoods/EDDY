using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CL*Fj";

		var expected = new CL_Class()
		{
			FreightClassCode = "Fj",
		};

		var actual = Map.MapObject<CL_Class>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fj", true)]
	public void Validation_RequiredFreightClassCode(string freightClassCode, bool isValidExpected)
	{
		var subject = new CL_Class();
		subject.FreightClassCode = freightClassCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
