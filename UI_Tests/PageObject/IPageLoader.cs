namespace UI_Tests.PageObject
{
    public interface IPageLoader<T>
    {
        public string PageUrl { get; set; }
        public T LoadPageByUrl();
    }
}
