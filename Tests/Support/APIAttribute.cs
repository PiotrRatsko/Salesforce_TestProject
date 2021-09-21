using System;

namespace Tests.Support
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class APIAttribute : Attribute, IAttribute, IGetAttribute, ISetAttribute
    {
    }
}
