using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class REPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "REP*a*Ye*8*f0*n*zJ*v*u*Q*vj*f*C*au*w*u*E*dt*J*p*B";

		var expected = new REP_RepairAction()
		{
			AssignedIdentification = "a",
			ProductServiceIDQualifier = "Ye",
			ProductServiceID = "8",
			ProductServiceIDQualifier2 = "f0",
			ProductServiceID2 = "n",
			AgencyQualifierCode = "zJ",
			SourceSubqualifier = "v",
			RepairActionCode = "u",
			Description = "Q",
			AgencyQualifierCode2 = "vj",
			SourceSubqualifier2 = "f",
			RepairComplexityCode = "C",
			ProductServiceIDQualifier3 = "au",
			ProductServiceID3 = "w",
			RepairActionCode2 = "u",
			Description2 = "E",
			AgencyQualifierCode3 = "dt",
			SourceSubqualifier3 = "J",
			ReferenceNumber = "p",
			AuthorizationIdentification = "B",
		};

		var actual = Map.MapObject<REP_RepairAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ye", "8", true)]
	[InlineData("Ye", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f0", "n", true)]
	[InlineData("f0", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//A Requires B
		if (productServiceID2 != "")
			subject.ProductServiceID = "8";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "8", true)]
	[InlineData("n", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBProductServiceID2(string productServiceID2, string productServiceID, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceID2 = productServiceID2;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zJ", "u", true)]
	[InlineData("zJ", "", false)]
	[InlineData("", "u", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string repairActionCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.RepairActionCode = repairActionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v", "zJ", true)]
	[InlineData("v", "", false)]
	[InlineData("", "zJ", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.RepairActionCode = "u";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vj", "C", true)]
	[InlineData("vj", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string repairComplexityCode, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.RepairComplexityCode = repairComplexityCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "vj", true)]
	[InlineData("f", "", false)]
	[InlineData("", "vj", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.RepairComplexityCode = "C";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("au", "w", true)]
	[InlineData("au", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", "", true)]
	[InlineData("w", "u", "E", true)]
	[InlineData("", "u", "E", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_ProductServiceID3(string productServiceID3, string repairActionCode2, string description2, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.ProductServiceID3 = productServiceID3;
		subject.RepairActionCode2 = repairActionCode2;
		subject.Description2 = description2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}

        if (subject.ProductServiceID3 != "")
            subject.ProductServiceIDQualifier3 = "Kc";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);

       
    }

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "w", true)]
	[InlineData("u", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredRepairActionCode2(string repairActionCode2, string productServiceID3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.RepairActionCode2 = repairActionCode2;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dt", "p", true)]
	[InlineData("dt", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBAgencyQualifierCode3(string agencyQualifierCode3, string referenceNumber, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("J", "dt", true)]
	[InlineData("J", "", false)]
	[InlineData("", "dt", true)]
	public void Validation_ARequiresBSourceSubqualifier3(string sourceSubqualifier3, string agencyQualifierCode3, bool isValidExpected)
	{
		var subject = new REP_RepairAction();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier3 = sourceSubqualifier3;
		subject.AgencyQualifierCode3 = agencyQualifierCode3;
		//A Requires B
		if (agencyQualifierCode3 != "")
			subject.ReferenceNumber = "p";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ye";
			subject.ProductServiceID = "8";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "f0";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "au";
			subject.ProductServiceID3 = "w";
		}
		if(!string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.RepairActionCode2 = "u";
			subject.ProductServiceID3 = "w";
		}
		//If one, at least one
		if(!string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.ProductServiceID3) || !string.IsNullOrEmpty(subject.RepairActionCode2) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.ProductServiceID3 = "w";
			subject.RepairActionCode2 = "u";
			subject.Description2 = "E";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
