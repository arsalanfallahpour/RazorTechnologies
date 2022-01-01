using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RazorTechnologies.Core.Common
{
    public class AppInterface : AppType
    {
        public AppInterface(ref Type type, bool inherited)
            :base(ref type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (!type.IsInterface)
                throw new NotSupportedException("Interface Types Not Supported");
            _inherited = inherited;
        }
        public bool Inherited { get { return _inherited; } }
        private readonly bool _inherited;
    }
}
