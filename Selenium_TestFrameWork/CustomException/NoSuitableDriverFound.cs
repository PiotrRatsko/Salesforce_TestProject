using System;

namespace Selenium_TestFrameWork.CustomException
{
    public class NoSuitableDriverFound: Exception
    {
        public NoSuitableDriverFound(string msg): base(msg)
        {

        }
    }
}
