﻿using OpenQA.Selenium;
using Selenium_TestFrameWork.WebDriverExtention;
using UI_Tests.BaseClass;

namespace UI_Tests.PageObject
{
    public class Login : BasePage
    {
        #region IWebElements
        By SignInWithFaceBookBtn = By.Id("e3login-facebook-button"); //Sign in with Facebook
        By LookingForSignInWithGoogleBtn = By.ClassName("googlelink"); //Looking for Sign In with Google?
        By EmailAddressTxtBox = By.Id("signin-loginid"); //Email Address textbox
        By PasswordTxtBox = By.Id("signin-password"); //Password textbox
        By ForgotYourPasswordLnk = By.Id("go-to-forgot-password"); //Forgot your password?
        By SignInBtn = By.Id("submitButton"); //Sign In button
        #endregion IWebElements
        public Login(IWebDriver _driver) : base(_driver)
        { }

        #region Action
        public void LogIn(string userName, string password)
        {
            driver.TypeInTextBox(EmailAddressTxtBox, userName);
            driver.TypeInTextBox(PasswordTxtBox, password);
            driver.ClickButton(SignInBtn);
        }

        #endregion Action
    }
}
