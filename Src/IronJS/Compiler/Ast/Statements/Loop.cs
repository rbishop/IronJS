﻿using Antlr.Runtime.Tree;

#if CLR2
using Microsoft.Scripting.Ast;
#else
using System.Linq.Expressions;
#endif

namespace IronJS.Compiler.Ast
{
    using AstUtils = Microsoft.Scripting.Ast.Utils;
    using Et = Expression;

    abstract public class Loop : Node, ILabelable
    {
        public string Label { get; protected set; }

        public Loop(NodeType type, ITree node)
            : base(type, node)
        {

        }

        public virtual Et LoopWalk(Function etgen)
        {
            return AstUtils.Empty();
        }

        #region ILabelableNode Members

        public void SetLabel(string label)
        {
            Label = label;
        }
        
        #endregion
    }
}