using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class IDHTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IDH*JKGifc*YILtGE";

		var expected = new IDH_IncreaseDecreaseHeader()
		{
			Date = "JKGifc",
			Date2 = "YILtGE",
		};

		var actual = Map.MapObject<IDH_IncreaseDecreaseHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JKGifc", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new IDH_IncreaseDecreaseHeader();
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
