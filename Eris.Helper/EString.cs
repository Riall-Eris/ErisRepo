using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eris.Helper
{
    public class EString
    {
        public EString()
        {
        }

        public static string NumberToString(string Number)
        {
            try
            {
                //Variables
                string Number_Text = "";
                string part = "";

                int numberlen = Number.Length;
                int parts_number = numberlen / 3;
                int counter = 0;

                //cutting into diffrent parts LEN = 3
                for (int i = parts_number; i >= 0; i--)
                {

                    if ((counter) != numberlen)
                    {
                        if (((numberlen % 3) != 0) && (i == parts_number))
                        {
                            part = Number.Substring(0, (numberlen % 3));
                            counter = numberlen % 3;
                        }
                        else if (((numberlen % 3) == 0) && (i == parts_number))
                        {
                            part = Number.Substring(0, 3);
                            counter = 3;
                        }
                        else
                        {
                            part = Number.Substring(counter, 3);
                            counter += 3;
                        }

                        int len = part.Length;

                        string sadgan_text = "";
                        string sadgan = "0";
                        string dahgan_text = "";
                        string dahgan = "0";
                        string yekan_text = "";
                        string yekan = "0";

                        //OMIITING '0' (ZEROES) on each part
                        //EXAMPLE : 123 OR 023 or 03
                        if (len < 4)
                        {
                            if (len == 3)
                            {
                                sadgan = part.Substring(0, 1);
                                dahgan = part.Substring(1, 1);
                                yekan = part.Substring(2, 1);
                            }
                            else if (len == 2)
                            {
                                sadgan = "0";
                                dahgan = part.Substring(0, 1);
                                yekan = part.Substring(1, 1);
                            }
                            else if (len == 1)
                            {
                                sadgan = "0";
                                dahgan = "0";
                                yekan = part.Substring(0, 1);
                            }
                            else if (len == 0)
                            {
                                sadgan = "0";
                                dahgan = "0";
                                yekan = "0";
                            }
                        }

                        #region SADGAN
                        switch (sadgan)
                        {
                            case "0":
                                sadgan_text = "";
                                break;

                            case "1":
                                sadgan_text = "صد";
                                break;

                            case "2":
                                sadgan_text = "دويست";
                                break;

                            case "3":
                                sadgan_text = "سيصد";
                                break;

                            case "4":
                                sadgan_text = "چهارصد";
                                break;

                            case "5":
                                sadgan_text = "پانصد";
                                break;

                            case "6":
                                sadgan_text = "ششصد";
                                break;

                            case "7":
                                sadgan_text = "هفتصد";
                                break;

                            case "8":
                                sadgan_text = "هشتصد";
                                break;

                            case "9":
                                sadgan_text = "نهصد";
                                break;
                        }
                        #endregion
                        #region DAHGAN
                        switch (dahgan)
                        {
                            case "0":
                                dahgan_text = "";
                                break;

                            case "1":
                                {
                                    switch (yekan)
                                    {
                                        case "0":
                                            dahgan_text = "ده";
                                            break;
                                        case "1":
                                            dahgan_text = "يازده";
                                            break;
                                        case "2":
                                            dahgan_text = "دوازده";
                                            break;
                                        case "3":
                                            dahgan_text = "سيزده";
                                            break;
                                        case "4":
                                            dahgan_text = "چهارده";
                                            break;
                                        case "5":
                                            dahgan_text = "پانزده";
                                            break;
                                        case "6":
                                            dahgan_text = "شانزده";
                                            break;
                                        case "7":
                                            dahgan_text = "هفده";
                                            break;
                                        case "8":
                                            dahgan_text = "هجده";
                                            break;
                                        case "9":
                                            dahgan_text = "نوزده";
                                            break;
                                    }
                                    break;
                                }

                            case "2":
                                dahgan_text = "بيست";
                                break;

                            case "3":
                                dahgan_text = "سی";
                                break;

                            case "4":
                                dahgan_text = "چهل";
                                break;

                            case "5":
                                dahgan_text = "پنجاه";
                                break;

                            case "6":
                                dahgan_text = "شصت";
                                break;

                            case "7":
                                dahgan_text = "هفتاد";
                                break;

                            case "8":
                                dahgan_text = "هشتاد";
                                break;

                            case "9":
                                dahgan_text = "نود";
                                break;
                        }
                        #endregion
                        #region YEKAN
                        switch (yekan)
                        {
                            case "0":
                                yekan_text = "";
                                break;

                            case "1":
                                yekan_text = "يک";
                                break;

                            case "2":
                                yekan_text = "دو";
                                break;

                            case "3":
                                yekan_text = "سه";
                                break;

                            case "4":
                                yekan_text = "چهار";
                                break;

                            case "5":
                                yekan_text = "پنج";
                                break;

                            case "6":
                                yekan_text = "شش";
                                break;

                            case "7":
                                yekan_text = "هفت";
                                break;

                            case "8":
                                yekan_text = "هشت";
                                break;

                            case "9":
                                yekan_text = "نه";
                                break;

                        }
                        #endregion

                        //Creating appropriate text for each part LEN = 3
                        if (!sadgan.Equals("0") && (!(dahgan + yekan).Equals("00")))
                        { sadgan_text += " و "; }
                        if ((!dahgan.Equals("0")) && !(yekan.Equals("0")) && (!dahgan.Equals("1")))
                        { dahgan_text += " و "; }
                        else if ((!dahgan.Equals("0")) && (dahgan.Equals("1")))
                        { yekan_text = ""; }

                        Number_Text = Number_Text + sadgan_text + dahgan_text + yekan_text;


                        //Adding هزار،ميليون،^...^ After Text
                        int temp = i;
                        if (((numberlen % 3) == 0))
                        { temp -= 1; }

                        switch (temp)
                        {
                            case 1:
                                {
                                    if ((!part.Equals("000")) && (!part.Equals("00")) && (!part.Equals("0")))
                                    {
                                        Number_Text += " هزار و ";
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    if ((!part.Equals("000")) && (!part.Equals("00")) && (!part.Equals("0")))
                                    {
                                        Number_Text += " ميليون و ";
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    if ((!part.Equals("000")) && (!part.Equals("00")) && (!part.Equals("0")))
                                    {
                                        Number_Text += " ميليارد و ";
                                    }
                                    break;
                                }
                        }
                    }
                }

                //Triming "و"
                int lastlen = Number_Text.Length;
                string last = Number_Text.Substring((lastlen - 2), 1);
                if (last.Equals("و"))
                {
                    last = Number_Text.Substring(0, (lastlen - 3));
                    Number_Text = last;
                }
                return Number_Text;
            }
            catch
            {
            }
            return "";
            //Return Statement
        }

        public static string ShamsiDateToString(string ShamsiDate)
        {
            if (ShamsiDate.Length < 10)
                return "";
            return Number2FarsiDesc(ShamsiDate.Substring(8, 2)).Trim().Replace("سه", "سو").Replace("سی", "سی ا") + "م " + GetShamsiMoth(byte.Parse(ShamsiDate.Substring(5, 2))) + " " + Number2FarsiDesc(ShamsiDate.Substring(0, 4));
        }

        public static string GetShamsiMoth(byte Month)
        {
            switch (Month)
            {
                case 1: return "فروردین";
                case 2: return "اردیبهشت";
                case 3: return "خرداد";
                case 4: return "تیر";
                case 5: return "مرداد";
                case 6: return "شهریور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دی";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: return "";
            }
        }

        private static string Number2FarsiDesc(string Number)
        {
            int lngPos;
            string output = "";
            string LeftNumber;
            string RightNumber;
            if (Number.Length == 0)
            {
                return null;

            }
            else if (Number.Length > 12)
            {

                return null;

            }
            else
            {

                //-----------------------------

                if (Number == null)
                {
                    return null;
                }
                else
                {
                    lngPos = Number.IndexOf(".");
                    if ((lngPos == (Number.Length - 1)) && (Number.Length != 1))
                    {
                        output = inner_Number2FarsiDesc(Number.Substring(0, Number.Length - 1));
                    }
                    else if (lngPos == -1)
                    {
                        output = inner_Number2FarsiDesc(Number);
                    }
                    else
                    {

                        if (lngPos != 1)
                            LeftNumber = Number.Substring(0, lngPos);
                        else
                            LeftNumber = "";
                        if (lngPos != (Number.Length - 1))
                            RightNumber = Number.Substring(lngPos + 1);
                        else
                            RightNumber = "";

                        string[] strDigitPostfix = new string[10];
                        strDigitPostfix[0] = "دهم";
                        strDigitPostfix[1] = "صدم";
                        strDigitPostfix[2] = "هزارم";
                        strDigitPostfix[3] = "ده هزارم";
                        strDigitPostfix[4] = "صد هزارم";
                        strDigitPostfix[5] = "ميليونم";
                        strDigitPostfix[6] = "ميلياردم";
                        strDigitPostfix[7] = "تريليونم";
                        strDigitPostfix[8] = "تريلياردم";

                        if (LeftNumber != "")
                            output = inner_Number2FarsiDesc(LeftNumber);
                        if (RightNumber != "")
                            if (Convert.ToInt64(RightNumber) != 0)
                            {
                                output += " مميز " + inner_Number2FarsiDesc(RightNumber) + strDigitPostfix[(RightNumber.Length) - 1];
                            }
                    }
                }
            }
            return output;
        }

        private static string inner_Number2FarsiDesc(string Number)
        {
            string n2f;
            double RemNum;
            double ResNum;
            int DivNum;
            string strRes;
            int Position;

            if (Number.Trim() == "0")
            {
                n2f = "صفر";
                return n2f;
            }

            RemNum = Convert.ToDouble(Number.Trim());
            strRes = "";
            Position = 1;
            DivNum = 1000;

            while (RemNum > 0)
            {
                if (RemNum < DivNum)
                {
                    ResNum = RemNum;
                }
                else
                {
                    ResNum = ModEx(RemNum, DivNum);
                }
                //-----------------------
                RemNum = DivEx(RemNum, DivNum);

                strRes = Number2FarsiDescSub(ResNum, Position) + strRes;
                Position = Position + 1;

                if (ModEx(RemNum, 1000) != 0 && strRes != "")
                {
                    strRes = " و " + strRes;
                }
            }
            n2f = strRes;
            return n2f;
        }
        private static string Number2FarsiDescSub(double ResNum, int Position)
        {
            string y;
            string strRes;
            string[] strDigits1 = new string[20];
            strDigits1[0] = "";
            strDigits1[1] = "يک";
            strDigits1[2] = "دو";
            strDigits1[3] = "سه";
            strDigits1[4] = "چهار";
            strDigits1[5] = "پنج";
            strDigits1[6] = "شش";
            strDigits1[7] = "هفت";
            strDigits1[8] = "هشت";
            strDigits1[9] = "نه";
            strDigits1[10] = "ده";
            strDigits1[11] = "يازده";
            strDigits1[12] = "دوازده";
            strDigits1[13] = "سيزده";
            strDigits1[14] = "چهارده";
            strDigits1[15] = "پانزده";
            strDigits1[16] = "شانزده";
            strDigits1[17] = "هفده";
            strDigits1[18] = "هجده";
            strDigits1[19] = "نوزده";

            string[] strDigits10 = new string[10];
            strDigits10[0] = "";
            strDigits10[1] = "ده";
            strDigits10[2] = "بيست";
            strDigits10[3] = "سی";
            strDigits10[4] = "چهل";
            strDigits10[5] = "پنجاه";
            strDigits10[6] = "شصت";
            strDigits10[7] = "هفتاد";
            strDigits10[8] = "هشتاد";
            strDigits10[9] = "نود";


            string[] strDigits100 = new string[10];
            strDigits100[0] = "";
            strDigits100[1] = "يکصد";
            strDigits100[2] = "دويست";
            strDigits100[3] = "سيصد";
            strDigits100[4] = "چهارصد";
            strDigits100[5] = "پانصد";
            strDigits100[6] = "ششصد";
            strDigits100[7] = "هفتصد";
            strDigits100[8] = "هشتصد";
            strDigits100[9] = "نهصد";

            string[] strDigitPrefix = new string[10];
            strDigitPrefix[0] = "";
            strDigitPrefix[1] = "";
            strDigitPrefix[2] = "هزار";
            strDigitPrefix[3] = "ميليون";
            strDigitPrefix[4] = "ميليارد";
            strDigitPrefix[5] = "تريليون";
            strDigitPrefix[6] = "تريليارد";
            strDigitPrefix[7] = "ترا ميليون";
            strDigitPrefix[8] = "ترا ميليارد";


            strRes = strDigits100[(int)ResNum / 100];
            //----------------------------
            if (ResNum != 0)
            {
                ResNum = ResNum % 100;

                if (ResNum == 0)
                {
                    //'do nothing
                }
                else if (ResNum < 20)
                {
                    //----------
                    if (strRes == "")
                    {
                        strRes = strDigits1[(int)ResNum];
                    }
                    else
                    {
                        strRes = strRes + " و " + strDigits1[(int)ResNum];
                    }
                    //----------
                }
                else
                {
                    //------------------------
                    if (strRes == "")
                    {
                        strRes = strDigits10[(int)ResNum / 10];
                    }
                    else
                    {
                        strRes = strRes + " و " + strDigits10[(int)ResNum / 10];
                    }

                    if ((ResNum % 10) > 0)
                    {
                        strRes = strRes + " و " + strDigits1[(int)ResNum % 10];
                    }
                }

                strRes = strRes + " " + strDigitPrefix[Position];
            }
            //--------------------------
            y = strRes;
            return y;
        }

        private static double ModEx(double Opr1, double Opr2)
        {
            double x = 0;
            x = Opr1 - (Opr2 * (int)(Opr1 / Opr2));
            return x;
        }
        private static double DivEx(double Opr1, double Opr2)
        {
            double z;

            z = (int)(Opr1 / Opr2);
            return z;
        }

        static private char[] pwchr = new char[62] {
												'F' , 'x' ,'6' , 'u' , 'D' , 'O', 
												'Z' , '7' ,'G' , 'c' , 'B' , 'l',
												'L' , 't' ,'S' , 'j' , 'N' , 
												'i' , 'K' ,'2' , 'm' , 'v' , 
												'a' , 'o' ,'I' , '1' , 'X' , 
												'E' , 'p' ,'b' , 'M' , '8' , 
												'Y' , 'Q' ,'4' , 'V' , 'H' , 
												'd' , 'w' ,'g' , 'k' , '5' , 
												'z' , 'R' ,'f' , 'T' , 'r' , 
												'J' , 'h' ,'0' , 'n' , 'C' , 
												'W' , 'y' ,'s' , 'A' , '3' , 
												'P' , 'e' ,'9' , 'q' , 'U'  
											};

        static public string EncodePW(string upw)
        {
            int pwlen = upw.Length;
            string TempStr = "";
            int i = 0;
            while (i < pwlen)
            {
                TempStr += pwchr[(FindPWCharIndex(upw[i]) + (i + 1) * 6) % 62];
                i++;
            }

            return TempStr;
        }

        static public string DecodePW(string EncodeduPW)
        {
            int pwlen = EncodeduPW.Length;
            string TempStr = "";
            int i = 0;
            while (i < pwlen)
            {
                int Index = (FindPWCharIndex(EncodeduPW[i]) - (i + 1) * 6) % 62;
                if (Index < 0)
                    Index += 62;
                TempStr += pwchr[Index];
                i++;
            }

            return TempStr;
        }

        static private int FindPWCharIndex(char c)
        {
            int i = 0;
            while (i < 62)
            {
                if (c == pwchr[i])
                    return i;
                i++;
            }
            return -1;
        }
    }
}