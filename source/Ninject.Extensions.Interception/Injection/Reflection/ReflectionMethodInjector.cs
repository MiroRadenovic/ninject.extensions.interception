#region License

// 
// Author: Nate Kohari <nate@enkari.com>
// Copyright (c) 2007-2009, Enkari, Ltd.
// 
// Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
// See the file LICENSE.txt for details.
// 

#endregion

#region Using Directives

using System.Reflection;

#endregion

namespace Ninject.Extensions.Interception.Injection.Reflection
{
    /// <summary>
    /// A method injector that uses reflection for invocation.
    /// </summary>
    public class ReflectionMethodInjector : InjectorBase<MethodInfo>, IMethodInjector
    {
        /// <summary>
        /// Creates a new ReflectionMethodInjector.
        /// </summary>
        /// <param name="member">The method that will be injected.</param>
        public ReflectionMethodInjector( MethodInfo member )
            : base( member )
        {
        }

        #region IMethodInjector Members

        /// <summary>
        /// Calls the method associated with the injector.
        /// </summary>
        /// <param name="target">The instance on which to call the method.</param>
        /// <param name="arguments">The arguments to pass to the method.</param>
        /// <returns>The return value of the method.</returns>
        public object Invoke( object target, params object[] arguments )
        {
            object result = null;

            try
            {
                result = Member.Invoke( target, arguments );
            }
            catch ( TargetInvocationException ex )
            {
                // If an exception occurs inside the called member, unwrap it and re-throw.
                //ExceptionThrower.RethrowPreservingStackTrace(ex.InnerException ?? ex);
                throw;
            }

            return result;
        }

        #endregion
    }
}