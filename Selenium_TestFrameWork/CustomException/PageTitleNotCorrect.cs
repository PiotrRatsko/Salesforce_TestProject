using System;

namespace Selenium_TestFrameWork.CustomException
{
    public class PageTitleNotCorrect: Exception
    {
        public PageTitleNotCorrect(string msg): base(msg)
        {
            LogHelper.log.Error(msg);
        }
    }
}
