using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIS*3p*XdyEWjCO*xH*F";

		var expected = new TIS_TitleInsuranceServices()
		{
			TitleInsuranceServicesCode = "3p",
			Date = "XdyEWjCO",
			ProductServiceIDQualifier = "xH",
			ProductServiceID = "F",
		};

		var actual = Map.MapObject<TIS_TitleInsuranceServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3p", true)]
	public void Validation_RequiredTitleInsuranceServicesCode(string titleInsuranceServicesCode, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		//Test Parameters
		subject.TitleInsuranceServicesCode = titleInsuranceServicesCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "xH";
			subject.ProductServiceID = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xH", "F", true)]
	[InlineData("xH", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		subject.TitleInsuranceServicesCode = "3p";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
