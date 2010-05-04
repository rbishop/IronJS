﻿namespace IronJS.Compiler

open IronJS
open IronJS.Aliases
open IronJS.Tools
open IronJS.Tools.Dlr
open IronJS.Compiler
open IronJS.Compiler.Types
open IronJS.Compiler.ExpressionState

module Utils = 

    let assign ctx (left:Et) (right:Et) =
      let l = Expr.expandStrongBox left
      let r = Expr.expandStrongBox right

      if l.Type = r.Type then Expr.assign l r
      else
        if l.Type = typeof<Runtime.Box> 
          then Box.assign ctx l r
          else failwith "Odd case not handled yet"