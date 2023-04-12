using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIS*xN*gZrtKmds*QN*g";

		var expected = new TIS_TitleInsuranceServices()
		{
			TitleInsuranceServicesCode = "xN",
			Date = "gZrtKmds",
			ProductServiceIDQualifier = "QN",
			ProductServiceID = "g",
		};

		var actual = Map.MapObject<TIS_TitleInsuranceServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xN", true)]
	public void Validation_RequiredTitleInsuranceServicesCode(string titleInsuranceServicesCode, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		subject.TitleInsuranceServicesCode = titleInsuranceServicesCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("QN", "g", true)]
	[InlineData("", "g", false)]
	[InlineData("QN", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		subject.TitleInsuranceServicesCode = "xN";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
