using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Forms
{
    public partial class DigitConvert_E_BN_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }        
        public static  String  getDigitEnglishToBangal(String number)
        {        
            try
            {
                if (number != "")
                {
                    number = number.Replace("0", "০").Replace("1", "১").Replace("2", "২").Replace("3", "৩").Replace("4", "৪").Replace("5", "৫").Replace("6", "৬").Replace("7", "৭").Replace("8", "৮").Replace("9", "৯");
                }                            
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return number;
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
           lblNum.Text= getDigitEnglishToBangal(txtNum.Text);
        }


        //private static final char[] banglaDigits = { '০', '১', '২', '৩', '৪', '৫', '৬', '৭', '৮', '৯' };
        //private static final char[] englishDigits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        //public static final String  getDigitBanglaFromEnglish(String number)
        //{
        //    if (number == null)
        //        return new String("");
        //    StringBuilder builder = new StringBuilder();
        //    try
        //    {
        //        for (int i = 0; i < number.length(); i++)
        //        {
        //            if (Character.isDigit(number.charAt(i)))
        //            {
        //                if (((int)(number.charAt(i)) - 48) <= 9)
        //                {
        //                    builder.append(banglaDigits[(int)(number.charAt(i)) - 48]);
        //                }
        //                else
        //                {
        //                    builder.append(number.charAt(i));
        //                }
        //            }
        //            else
        //            {
        //                builder.append(number.charAt(i));
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //logger.debug("getDigitBanglaFromEnglish: ",e);
        //        return new String("");
        //    }
        //    return builder.toString();
        //}



    }
}