using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RU3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU3*TdyJxuYz*OD*W*ob*O*Qw*c*Ro*W*S8*k*ki*T*VR*W*hP*u*kN*w*Ag*S*Zt*W*vt*D*xh*X*ah*J";

		var expected = new RU3_EmployingCarrierClaimProfile()
		{
			Date = "TdyJxuYz",
			PayrollStatusCode = "OD",
			WagesPaidCode = "W",
			PayrollStatusCode2 = "ob",
			WagesPaidCode2 = "O",
			PayrollStatusCode3 = "Qw",
			WagesPaidCode3 = "c",
			PayrollStatusCode4 = "Ro",
			WagesPaidCode4 = "W",
			PayrollStatusCode5 = "S8",
			WagesPaidCode5 = "k",
			PayrollStatusCode6 = "ki",
			WagesPaidCode6 = "T",
			PayrollStatusCode7 = "VR",
			WagesPaidCode7 = "W",
			PayrollStatusCode8 = "hP",
			WagesPaidCode8 = "u",
			PayrollStatusCode9 = "kN",
			WagesPaidCode9 = "w",
			PayrollStatusCode10 = "Ag",
			WagesPaidCode10 = "S",
			PayrollStatusCode11 = "Zt",
			WagesPaidCode11 = "W",
			PayrollStatusCode12 = "vt",
			WagesPaidCode12 = "D",
			PayrollStatusCode13 = "xh",
			WagesPaidCode13 = "X",
			PayrollStatusCode14 = "ah",
			WagesPaidCode14 = "J",
		};

		var actual = Map.MapObject<RU3_EmployingCarrierClaimProfile>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TdyJxuYz", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("OD", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("OD", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode(string payrollStatusCode, string wagesPaidCode, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode = payrollStatusCode;
		subject.WagesPaidCode = wagesPaidCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ob", "O", true)]
	[InlineData("", "O", false)]
	[InlineData("ob", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode2(string payrollStatusCode2, string wagesPaidCode2, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode2 = payrollStatusCode2;
		subject.WagesPaidCode2 = wagesPaidCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Qw", "c", true)]
	[InlineData("", "c", false)]
	[InlineData("Qw", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode3(string payrollStatusCode3, string wagesPaidCode3, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode3 = payrollStatusCode3;
		subject.WagesPaidCode3 = wagesPaidCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ro", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("Ro", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode4(string payrollStatusCode4, string wagesPaidCode4, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode4 = payrollStatusCode4;
		subject.WagesPaidCode4 = wagesPaidCode4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S8", "k", true)]
	[InlineData("", "k", false)]
	[InlineData("S8", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode5(string payrollStatusCode5, string wagesPaidCode5, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode5 = payrollStatusCode5;
		subject.WagesPaidCode5 = wagesPaidCode5;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ki", "T", true)]
	[InlineData("", "T", false)]
	[InlineData("ki", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode6(string payrollStatusCode6, string wagesPaidCode6, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode6 = payrollStatusCode6;
		subject.WagesPaidCode6 = wagesPaidCode6;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("VR", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("VR", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode7(string payrollStatusCode7, string wagesPaidCode7, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode7 = payrollStatusCode7;
		subject.WagesPaidCode7 = wagesPaidCode7;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("hP", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("hP", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode8(string payrollStatusCode8, string wagesPaidCode8, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode8 = payrollStatusCode8;
		subject.WagesPaidCode8 = wagesPaidCode8;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("kN", "w", true)]
	[InlineData("", "w", false)]
	[InlineData("kN", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode9(string payrollStatusCode9, string wagesPaidCode9, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode9 = payrollStatusCode9;
		subject.WagesPaidCode9 = wagesPaidCode9;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ag", "S", true)]
	[InlineData("", "S", false)]
	[InlineData("Ag", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode10(string payrollStatusCode10, string wagesPaidCode10, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode10 = payrollStatusCode10;
		subject.WagesPaidCode10 = wagesPaidCode10;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Zt", "W", true)]
	[InlineData("", "W", false)]
	[InlineData("Zt", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode11(string payrollStatusCode11, string wagesPaidCode11, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode11 = payrollStatusCode11;
		subject.WagesPaidCode11 = wagesPaidCode11;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("vt", "D", true)]
	[InlineData("", "D", false)]
	[InlineData("vt", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode12(string payrollStatusCode12, string wagesPaidCode12, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode12 = payrollStatusCode12;
		subject.WagesPaidCode12 = wagesPaidCode12;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("xh", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("xh", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode13(string payrollStatusCode13, string wagesPaidCode13, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode13 = payrollStatusCode13;
		subject.WagesPaidCode13 = wagesPaidCode13;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ah", "J", true)]
	[InlineData("", "J", false)]
	[InlineData("ah", "", false)]
	public void Validation_AllAreRequiredPayrollStatusCode14(string payrollStatusCode14, string wagesPaidCode14, bool isValidExpected)
	{
		var subject = new RU3_EmployingCarrierClaimProfile();
		subject.Date = "TdyJxuYz";
		subject.PayrollStatusCode14 = payrollStatusCode14;
		subject.WagesPaidCode14 = wagesPaidCode14;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
