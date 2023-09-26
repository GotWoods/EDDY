using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class GFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GF*Bz*8*T*5*zg*v*R*N9*Y";

		var expected = new GF_FurnishedGoodsAndServices()
		{
			ReferenceNumberQualifier = "Bz",
			ReferenceNumber = "8",
			ContractNumber = "T",
			MonetaryAmount = 5,
			ReferenceNumberQualifier2 = "zg",
			ReferenceNumber2 = "v",
			ReleaseNumber = "R",
			ReferenceNumberQualifier3 = "N9",
			ReferenceNumber3 = "Y",
		};

		var actual = Map.MapObject<GF_FurnishedGoodsAndServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Bz", "8", true)]
	[InlineData("Bz", "", false)]
	[InlineData("", "8", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier(string referenceNumberQualifier, string referenceNumber, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "zg";
			subject.ReferenceNumber2 = "v";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier3 = "N9";
			subject.ReferenceNumber3 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zg", "v", true)]
	[InlineData("zg", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier2(string referenceNumberQualifier2, string referenceNumber2, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier2 = referenceNumberQualifier2;
		subject.ReferenceNumber2 = referenceNumber2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Bz";
			subject.ReferenceNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier3) || !string.IsNullOrEmpty(subject.ReferenceNumber3))
		{
			subject.ReferenceNumberQualifier3 = "N9";
			subject.ReferenceNumber3 = "Y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N9", "Y", true)]
	[InlineData("N9", "", false)]
	[InlineData("", "Y", false)]
	public void Validation_AllAreRequiredReferenceNumberQualifier3(string referenceNumberQualifier3, string referenceNumber3, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		//Required fields
		//Test Parameters
		subject.ReferenceNumberQualifier3 = referenceNumberQualifier3;
		subject.ReferenceNumber3 = referenceNumber3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier) || !string.IsNullOrEmpty(subject.ReferenceNumber))
		{
			subject.ReferenceNumberQualifier = "Bz";
			subject.ReferenceNumber = "8";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumberQualifier2) || !string.IsNullOrEmpty(subject.ReferenceNumber2))
		{
			subject.ReferenceNumberQualifier2 = "zg";
			subject.ReferenceNumber2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
