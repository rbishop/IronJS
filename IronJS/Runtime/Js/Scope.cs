﻿using AstUtils = Microsoft.Scripting.Ast.Utils;
using Et = System.Linq.Expressions.Expression;
using EtParam = System.Linq.Expressions.ParameterExpression;

namespace IronJS.Runtime.Js
{

    public class Scope
    {
        IObj _obj;
        Scope _parent;
        Context _context;
        bool _privateObj = false;

        public IObj Value { get { return _obj; } }

        public Scope(Context context, Scope parent, IObj values)
        {
            _parent = parent;
            _obj = values;
            _context = context;
        }

        public Scope(Context context, Scope parent)
            : this(context)
        {
            _parent = parent;
        }

        public Scope(Context context)
        {
            _privateObj = true;
            _context = context;
            _obj = context.CreateObject();
            (_obj as Obj).Prototype = null;
        }

        public object Delete(object name)
        {
            if(_obj.Delete(name))
                return true;

            if (_parent != null)
                return _parent.Delete(name);

            return false;
        }

        public object Local(object name, object value)
        {
            if (_privateObj || _obj.HasProperty(name))
                return _obj.Put(name, value);

            return _parent.Local(name, value);
        }

        public object Global(object name, object value)
        {
            if (_parent == null || _obj.HasProperty(name))
                return _obj.Put(name, value);

            return _parent.Global(name, value);
        }

        public object Pull(object name)
        {
            var value = _obj.Get(name);

            if (value is Undefined)
            {
                if(_parent != null)
                    return _parent.Pull(name);

                if(name is string && (string)name != "undefined")
                    throw new InternalRuntimeError("Variable '" + name + "' is not defined");
            }

            return value;
        }

        public Scope Enter()
        {
            return new Scope(_context, this);
        }

        #region Expression Tree

        internal static Et EtDelete(EtParam scope, string name)
        {
            return Et.Call(
                scope,
                typeof(Scope).GetMethod("Delete"),
                Et.Constant(name)
            );
        }

        internal static Et EtValue(EtParam scope)
        {
            return Et.Property(
                scope,
                "Value"
            );
        }

        internal static Et EtLocal(EtParam scope, string name, Et value)
        {
            return Et.Call(
                scope,
                typeof(Scope).GetMethod("Local"),
                Et.Constant(name, typeof(object)),
                value
            );
        }

        internal static Et EtGlobal(EtParam scope, string name, Et value)
        {
            return Et.Call(
                scope,
                typeof(Scope).GetMethod("Global"),
                Et.Constant(name, typeof(object)),
                value
            );
        }

        internal static Et EtPull(EtParam scope, string name)
        {
            return Et.Call(
                scope,
                typeof(Scope).GetMethod("Pull"),
                Et.Constant(name, typeof(object))
            );
        }

        internal static Et EtNew(Et context, Et parent)
        {
            return AstUtils.SimpleNewHelper(
                typeof(Scope).GetConstructor(new[]{ typeof(Context), typeof(Scope) }),
                context,
                parent
            );
        }

        #endregion

        #region Static

        public static Scope CreateGlobal(Context context)
        {
            return new Scope(context);
        }

        public static Scope CreateCallScope(Scope closure, IFunction callee, IObj that, object[] args)
        {
            return CreateCallScope(closure, callee, that, args, new string[] { }); // TODO: not necessary to create a new array here each time
        }

        public static Scope CreateCallScope(Scope closure, IFunction callee, IObj that, object[] args, string[] parms)
        {
            var callScope = closure.Enter();
            var argsObject = closure._context.ObjectConstructor.Construct();

            callScope.Local("this", that);
            callScope.Local("arguments", argsObject);
            argsObject.SetOwnProperty("length", args.Length);
            argsObject.SetOwnProperty("callee", callee);

            for (var i = 0; i < args.Length; ++i)
            {
                if (i < parms.Length)
                    callScope.Local(parms[i], args[i]);

                argsObject.SetOwnProperty((double)i, args[i]);
            }

            return callScope;
        }

        #endregion
    }
}