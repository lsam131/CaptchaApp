using BotDetect.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CaptchaApp.App_Code;


namespace CaptchaApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Captcha1.ImageStyle = BotDetect.ImageStyle.Negative;
            //Captcha1.CustomDarkColor = Color.White;
            //Captcha1.CustomLightColor = Color.FromArgb(72, 72, 72);
            
            if (Page.IsPostBack)
            {
                // validate the Captcha to check we're not dealing with a bot 
                //bool isHuman = Captcha1.Validate(CaptchaControl1.Text);

                //CaptchaControl1.Text = null; // clear previous user input 

                //if (!isHuman)
                //{
                //    // TODO: Captcha validation failed, show error message  
                //    Label_ErrorMsg.Text = "驗證碼錯誤!";
                //}
                //else
                //{
                //    // TODO: Captcha validation passed, proceed with protected action 
                //    //MvcCaptcha.ResetCaptcha("ExampleCaptcha");
                //    Label_ErrorMsg.Text = "";
                //}


                bool isHuman = Session["CAPTCHA"].ToString().Equals(CaptchaControl1.Text);

                CaptchaControl1.Text = null; // clear previous user input 

                if (!isHuman)
                {
                    // TODO: Captcha validation failed, show error message  
                    Label_ErrorMsg.Text = "驗證碼錯誤!";
                }
                else
                {
                    // TODO: Captcha validation passed, proceed with protected action 
                    //MvcCaptcha.ResetCaptcha("ExampleCaptcha");
                    Label_ErrorMsg.Text = "";
                }
                CaptchaBLL captchaBll = new CaptchaBLL();
                string captcha = captchaBll.GenerateRandomText(5);
                byte[] arr = captchaBll.GenerateCaptchaImage(captcha);
                
                Session["CAPTCHA"] = captcha;
                Image1.ImageUrl = "data:image;base64," + Convert.ToBase64String(arr);
                CaptchaCode.Text = captcha;
            }
            else 
            {
                CaptchaBLL captchaBll = new CaptchaBLL();
                string captcha = captchaBll.GenerateRandomText(5);
                byte[] arr = captchaBll.GenerateCaptchaImage(captcha);
                Session["CAPTCHA"] = captcha;
                Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(arr);
                CaptchaCode.Text = captcha;
            }
        }
    }
}