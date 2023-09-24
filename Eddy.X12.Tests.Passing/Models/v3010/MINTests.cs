using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class MINTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MIN*V*P*n*0*S*o*O*R*r*p*U*f*y*w*q*0";

		var expected = new MIN_MinimumDetail()
		{
			LoadingRestriction = "V",
			LoadingRestriction2 = "P",
			LoadingRestriction3 = "n",
			LoadingRestriction4 = "0",
			LoadingRestriction5 = "S",
			LoadingRestriction6 = "o",
			LoadingRestriction7 = "O",
			LoadingRestriction8 = "R",
			LoadingRestriction9 = "r",
			LoadingRestriction10 = "p",
			LoadingRestriction11 = "U",
			LoadingRestriction12 = "f",
			LoadingRestriction13 = "y",
			LoadingRestriction14 = "w",
			LoadingRestriction15 = "q",
			LoadingRestriction16 = "0",
		};

		var actual = Map.MapObject<MIN_MinimumDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredLoadingRestriction(string loadingRestriction, bool isValidExpected)
	{
		var subject = new MIN_MinimumDetail();
		subject.LoadingRestriction = loadingRestriction;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
