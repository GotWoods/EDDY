using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class RCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RC*vd*r*B*0f*Q*Q*S*N*4";

		var expected = new RC_RootCause()
		{
			ProductServiceIDQualifier = "vd",
			ProductServiceID = "r",
			Name = "B",
			AgencyQualifierCode = "0f",
			SourceSubqualifier = "Q",
			CasualPartConditionCode = "Q",
			Description = "S",
			FreeFormMessageText = "N",
			YesNoConditionOrResponseCode = "4",
		};

		var actual = Map.MapObject<RC_RootCause>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vd", "r", true)]
	[InlineData("vd", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.CasualPartConditionCode = "Q";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0f", "Q", true)]
	[InlineData("0f", "", false)]
	[InlineData("", "Q", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string casualPartConditionCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.CasualPartConditionCode = casualPartConditionCode;
		//At Least one
		subject.Description = "S";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vd";
			subject.ProductServiceID = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q", "0f", true)]
	[InlineData("Q", "", false)]
	[InlineData("", "0f", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.CasualPartConditionCode = "Q";
		//At Least one
		subject.CasualPartConditionCode = "Q";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vd";
			subject.ProductServiceID = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Q", "S", true)]
	[InlineData("Q", "", true)]
	[InlineData("", "S", true)]
	public void Validation_AtLeastOneCasualPartConditionCode(string casualPartConditionCode, string description, bool isValidExpected)
	{
		var subject = new RC_RootCause();
		//Required fields
		//Test Parameters
		subject.CasualPartConditionCode = casualPartConditionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vd";
			subject.ProductServiceID = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
