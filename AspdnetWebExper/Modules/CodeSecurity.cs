using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspdnetWebExper.Modules {
    public class CodeSecurity {
        public static int EasyEncodeRowIndex(int row) {
            return row << 4 | 3;
        }

        public static int EasyDecodeRowIndex(int row) {
            return row >> 4;
        }
    }
}