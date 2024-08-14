using Eddy.Core.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eddy.Edifact
{
    public abstract class EdifactSegment
    {
        public abstract ValidationResult Validate();
    }
}
