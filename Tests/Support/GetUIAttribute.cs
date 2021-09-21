using System;

namespace Tests.Support
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class GetUIAttribute : Attribute, IAttribute, IGetAttribute
    {
    }
}
