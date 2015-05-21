using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GTLutils
{
    public enum Logics { AND, OR};
    public enum Operations { BIG, BIGEQ, EQ, LES, LESEQ, NEQ};

    public class LogicHelper 
    {
        public static Logics[] LogicEnums = new Logics[] { Logics.AND, Logics.OR};
        public static String getLogicString(Logics logic) 
        {
            switch (logic) 
            {
                case Logics.AND:
                    return "AND";
                case Logics.OR:
                    return "OR";
            }
            return null;
        }
    }

    public class OperationHelper
    {
        public static  Operations[] OpeEnums = new Operations[] { Operations.BIG, Operations.BIGEQ, Operations.EQ, Operations.LES, Operations.LESEQ, Operations.NEQ};
        public static String getOperationString(Operations op) 
        {
            switch (op) 
            {
                case Operations.BIGEQ:
                    return ">=";
                case Operations.BIG:
                    return ">";
                case Operations.EQ:
                    return "=";
                case Operations.LESEQ:
                    return "<=";
                case Operations.LES:
                    return "<";
                case Operations.NEQ:
                    return "!=";
            }
            return null;
        }

    }
}
