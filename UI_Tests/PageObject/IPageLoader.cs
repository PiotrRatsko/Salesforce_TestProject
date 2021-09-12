namespace UI_Tests.PageObject
{
    interface IPageLoader<T>
    {
        string PageUrl { get; set; }
        T LoadPageByUrl();
    }
}
