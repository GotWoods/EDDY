using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class TISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIS*DR*Tnfh9KqZ*vb*N";

		var expected = new TIS_TitleInsuranceServices()
		{
			TitleInsuranceServicesCode = "DR",
			Date = "Tnfh9KqZ",
			ProductServiceIDQualifier = "vb",
			ProductServiceID = "N",
		};

		var actual = Map.MapObject<TIS_TitleInsuranceServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DR", true)]
	public void Validation_RequiredTitleInsuranceServicesCode(string titleInsuranceServicesCode, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		//Test Parameters
		subject.TitleInsuranceServicesCode = titleInsuranceServicesCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vb";
			subject.ProductServiceID = "N";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vb", "N", true)]
	[InlineData("vb", "", false)]
	[InlineData("", "N", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new TIS_TitleInsuranceServices();
		//Required fields
		subject.TitleInsuranceServicesCode = "DR";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
