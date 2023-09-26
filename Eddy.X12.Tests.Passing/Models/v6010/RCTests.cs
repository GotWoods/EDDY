using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class RCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RC*0p*I*E*E6*a*b*y*S*Y";

		var expected = new RC_RootCause()
		{
			ProductServiceIDQualifier = "0p",
			ProductServiceID = "I",
			Name = "E",
			AgencyQualifierCode = "E6",
			SourceSubqualifier = "a",
			CausalPartConditionCode = "b",
			Description = "y",
			FreeFormMessageText = "S",
			YesNoConditionOrResponseCode = "Y",
		};

		var actual = Map.MapObject<RC_RootCause>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0p", "I", true)]
	[InlineData("0p", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.CausalPartConditionCode = "b";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E6", "b", true)]
	[InlineData("E6", "", false)]
	[InlineData("", "b", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string causalPartConditionCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.CausalPartConditionCode = causalPartConditionCode;
		//At Least one
		subject.Description = "y";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "0p";
			subject.ProductServiceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "E6", true)]
	[InlineData("a", "", false)]
	[InlineData("", "E6", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.CausalPartConditionCode = "b";
		//At Least one
		subject.CausalPartConditionCode = "b";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "0p";
			subject.ProductServiceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("b", "y", true)]
	[InlineData("b", "", true)]
	[InlineData("", "y", true)]
	public void Validation_AtLeastOneCausalPartConditionCode(string causalPartConditionCode, string description, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.CausalPartConditionCode = causalPartConditionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "0p";
			subject.ProductServiceID = "I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
