using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TFSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFS*4M*s*AM*H*K*vg*RRsAbt*xM92";

		var expected = new TFS_TaxForm()
		{
			ReferenceNumberQualifier = "4M",
			ReferenceNumber = "s",
			ReferenceNumberQualifier2 = "AM",
			ReferenceNumber2 = "H",
			IdentificationCodeQualifier = "K",
			IdentificationCode = "vg",
			Date = "RRsAbt",
			InternalRevenueServiceRecordControlIdentifier = "xM92",
		};

		var actual = Map.MapObject<TFS_TaxForm>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4M", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceNumber = "s";
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new TFS_TaxForm();
		subject.ReferenceNumberQualifier = "4M";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
