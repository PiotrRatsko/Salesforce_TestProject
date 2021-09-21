using System;

namespace Tests.Support
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class SetUIAttribute : Attribute, IAttribute, ISetAttribute
    {
    }
}
