using System.Collections.Generic;
using System.Text;

namespace Eddy.Core.Validation
{
    public class ValidationResult
    {
        public ValidationResult()
        {
        }

        public bool IsValid => Errors.Count == 0;
        public int LineNumber { get; set; }
        public List<Error> Errors { get; } = new();

        public void Add(Error error)
        {
            if (error != null)
                this.Errors.Add(error);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var error in Errors)
            {
                sb.AppendFormat(error.ErrorCode.Message, error.Data);
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
