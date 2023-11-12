// using Eddy.x12.Models;
//
// namespace Eddy.x12.DomainModels;
//
// public class Contact
// {
//     public static Contact FromG61(G61_Contact input)
//     {
//         var result = new Contact();
//         result.Name = input.Name;
//         result.ContactFunctionCode = input.ContactFunctionCode;
//         result.CommunicationNumberQualifier = input.CommunicationNumberQualifier;
//         result.CommunicationNumber = input.CommunicationNumber;
//         result.ContactInquiryReference = input.ContactInquiryReference;
//         return result;
//     }
//
//     public G61_Contact ToG61()
//     {
//         var result = new G61_Contact();
//         result.Name = Name;
//         result.ContactFunctionCode = ContactFunctionCode;
//         result.CommunicationNumberQualifier = CommunicationNumberQualifier;
//         result.CommunicationNumber = CommunicationNumber;
//         result.ContactInquiryReference = ContactInquiryReference;
//         return result;
//     }
//
//
//     public string ContactInquiryReference { get; set; }
//
//     public string CommunicationNumber { get; set; }
//
//     public string CommunicationNumberQualifier { get; set; }
//
//     public string ContactFunctionCode { get; set; }
//
//     public string Name { get; set; }
// }