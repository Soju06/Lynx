using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lynx.Common {
    public class LynxVersion {
        public LynxVersion() {
            Version
        }

        public int Minor { get; }
        public int Major { get; }
        public int Build { get; }
        public int Revision { get; }
    }
}
