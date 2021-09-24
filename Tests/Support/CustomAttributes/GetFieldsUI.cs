using System;

namespace Tests.Support.CustomAttributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class GetFieldsUI : Attribute, IAttributeUI
    {
    }
}
