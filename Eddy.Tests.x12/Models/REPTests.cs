using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class REPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REP*Q*LY*4*XR*7*4A*s*y*w*D4*F*G*vS*z*X*h*LL*D*i*F";

		var expected = new REP_RepairAction()
		{
			AssignedIdentification = "Q",
			ProductServiceIDQualifier = "LY",
			ProductServiceID = "4",
			ProductServiceIDQualifier2 = "XR",
			ProductServiceID2 = "7",
			AgencyQualifierCode = "4A",
			SourceSubqualifier = "s",
			RepairActionCode = "y",
			Description = "w",
			AgencyQualifierCode2 = "D4",
			SourceSubqualifier2 = "F",
			RepairComplexityCode = "G",
			ProductServiceIDQualifier3 = "vS",
			ProductServiceID3 = "z",
			RepairActionCode2 = "X",
			Description2 = "h",
			AgencyQualifierCode3 = "LL",
			SourceSubqualifier3 = "D",
			ReferenceIdentification = "i",
			AuthorizationIdentification = "F",
		};

		var actual = Map.MapObject<REP_RepairAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("LY", "4", true)]
	[InlineData("", "4", false)]
	[InlineData("LY", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("XR", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("XR", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "4", true)]
	[InlineData("7", "", false)]
	public void Validation_ARequiresBProductServiceID2(string productServiceID2, string productServiceID, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.ProductServiceID2 = productServiceID2;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "y", true)]
	[InlineData("4A", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string repairActionCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.RepairActionCode = repairActionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "4A", true)]
	[InlineData("s", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "G", true)]
	[InlineData("D4", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string repairComplexityCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.RepairComplexityCode = repairComplexityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "D4", true)]
	[InlineData("F", "", false)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("vS", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("vS", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("z", "X", true)]
	[InlineData("","X", true)]
	[InlineData("z", "", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ProductServiceID3(string productServiceID3, string repairActionCode2, string description2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.ProductServiceID3 = productServiceID3;
		subject.RepairActionCode2 = repairActionCode2;
		subject.Description2 = description2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("X", "z", true)]
	[InlineData("", "z", false)]
	[InlineData("X", "", false)]
	public void Validation_AllAreRequiredRepairActionCode2(string repairActionCode2, string productServiceID3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.RepairActionCode2 = repairActionCode2;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "i", true)]
	[InlineData("LL", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode3(string agencyQualifierCode3, string referenceIdentification, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "LL", true)]
	[InlineData("D", "", false)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
