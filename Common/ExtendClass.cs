using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Newtonsoft.Json;
namespace Common
{
    public static class ExtendClass
    {
        public static string ToJson(this string para, bool value = true)
        {
            return JsonConvert.SerializeObject(new { sucess = value, msg = para });
        }
        public static bool IsNum(this string para)
        {
            try
            {
                int a = int.Parse(para);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static int ToInt(this long para)
        {
            try
            {
                return (int)para;
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static int ToInt(this string para)
        {
            try
            {
                return int.Parse(para);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static decimal Todbl(this string para)
        {
            try
            {
                return decimal.Parse(para);
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public static DateTime ToDate(this string para)
        {
            try
            {
                return DateTime.Parse(para);
            }
            catch (Exception)
            {
                return DateTime.Parse("1900-01-01");
                throw;
            }
        }
        public static string[] Split(this string para, string SplitStr)
        {
            return System.Text.RegularExpressions.Regex.Split(para, SplitStr);

        }
        public static string Filter(this string para, string FilterRule)
        {
            return Tool.MyFilter(para, FilterRule);
        }
        /// <summary>
        /// 替换/为\
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns>
        public static string ReplaceXg(this string para)
        {
            return para.Replace("/", "\\");
        }
        public static string ReplaceSql(this string para)
        {
            return para.Replace("'", "''");
        }
        public static string left(this string para, int len)
        {
            if (len > para.Length) len = para.Length;
            return para.Substring(0, len);
        }
        public static void ZipPic(this string para, string path)
        {
            string newPath = path + "Temp\\" + para;
            newPath = newPath.Replace("/", "\\");
            string oldPath = path + para;
            oldPath = oldPath.Replace("/", "\\");
            Tool.CreateFolder(newPath);
            if (ImageHelper.GetPicThumbnail(oldPath, newPath, 95))
            {
                try
                {
                    File.Copy(newPath, oldPath, true);
                    Tool.DelFile(newPath);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public static string ReplaceSymbols(this string para)
        {
            if (string.IsNullOrEmpty(para))
            {
                return "";
            }
            para = para.Replace("Α", "&Alpha;");
            para = para.Replace("Β", "&Beta;");
            para = para.Replace("Γ", "&Gamma;");
            para = para.Replace("Δ", "&Delta;");
            para = para.Replace("Ε", "&Epsilon;");
            para = para.Replace("Ζ", "&Zeta;");
            para = para.Replace("Η", "&Eta;");
            para = para.Replace("Θ", "&Theta;");
            para = para.Replace("Ι", "&Iota;");
            para = para.Replace("Κ", "&Kappa;");
            para = para.Replace("Λ", "&Lambda;");
            para = para.Replace("Μ", "&Mu;");
            para = para.Replace("Ν", "&Nu;");
            para = para.Replace("Ξ", "&Xi;");
            para = para.Replace("Ο", "&Omicron;");
            para = para.Replace("Π", "&Pi;");
            para = para.Replace("Ρ", "&Rho;");
            para = para.Replace("Σ", "&Sigma;");
            para = para.Replace("Τ", "&Tau;");
            para = para.Replace("Υ", "&Upsilon;");
            para = para.Replace("Φ", "&Phi;");
            para = para.Replace("Χ", "&Chi;");
            para = para.Replace("Ψ", "&Psi;");
            para = para.Replace("Ω", "&Omega;");
            para = para.Replace("α", "&alpha;");
            para = para.Replace("β", "&beta;");
            para = para.Replace("γ", "&gamma;");
            para = para.Replace("δ", "&delta;");
            para = para.Replace("ε", "&epsilon;");
            para = para.Replace("ζ", "&zeta;");
            para = para.Replace("η", "&eta;");
            para = para.Replace("θ", "&theta;");
            para = para.Replace("ι", "&iota;");
            para = para.Replace("κ", "&kappa;");
            para = para.Replace("λ", "&lambda;");
            para = para.Replace("μ", "&mu;");
            para = para.Replace("ν", "&nu;");
            para = para.Replace("ξ", "&xi;");
            para = para.Replace("ο", "&omicron;");
            para = para.Replace("π", "&pi;");
            para = para.Replace("ρ", "&rho;");
            para = para.Replace("ς", "&sigmaf;");
            para = para.Replace("σ", "&sigma;");
            para = para.Replace("τ", "&tau;");
            para = para.Replace("υ", "&upsilon;");
            para = para.Replace("φ", "&phi;");
            para = para.Replace("χ", "&chi;");
            para = para.Replace("ψ", "&psi;");
            para = para.Replace("ω", "&omega;");
            para = para.Replace("ϑ", "&thetasym;");
            para = para.Replace("ϒ", "&upsih;");
            para = para.Replace("ϖ", "&piv;");
            para = para.Replace("℘", "&weierp;");
            para = para.Replace("ℑ", "&image;");
            para = para.Replace("ℜ", "&real;");
            para = para.Replace("™", "&trade;");
            para = para.Replace("ℵ", "&alefsym;");
            para = para.Replace("←", "&larr;");
            para = para.Replace("↑", "&uarr;");
            para = para.Replace("→", "&rarr;");
            para = para.Replace("↓", "&darr;");
            para = para.Replace("↔", "&harr;");
            para = para.Replace("↵", "&crarr;");
            para = para.Replace("⇐", "&lArr;");
            para = para.Replace("⇑", "&uArr;");
            para = para.Replace("⇒", "&rArr;");
            para = para.Replace("⇓", "&dArr;");
            para = para.Replace("⇔", "&hArr;");
            para = para.Replace("∀", "&forall;");
            para = para.Replace("∂", "&part;");
            para = para.Replace("∃", "&exist;");
            para = para.Replace("∅", "&empty;");
            para = para.Replace("∇", "&nabla;");
            para = para.Replace("∈", "&isin;");
            para = para.Replace("∉", "&notin;");
            para = para.Replace("∋", "&ni;");
            para = para.Replace("∏", "&prod;");
            para = para.Replace("∑", "&sum;");
            para = para.Replace("−", "&minus;");
            para = para.Replace("∗", "&lowast;");
            para = para.Replace("√", "&radic;");
            para = para.Replace("∝", "&prop;");
            para = para.Replace("∞", "&infin;");
            para = para.Replace("∠", "&ang;");
            para = para.Replace("∧", "&and;");
            para = para.Replace("∨", "&or;");
            para = para.Replace("∩", "&cap;");
            para = para.Replace("∪", "&cup;");
            para = para.Replace("∫", "&int;");
            para = para.Replace("∴", "&there4;");
            para = para.Replace("∼", "&sim;");
            para = para.Replace("≅", "&cong;");
            para = para.Replace("≈", "&asymp;");
            para = para.Replace("≠", "&ne;");
            para = para.Replace("≡", "&equiv;");
            para = para.Replace("≤", "&le;");
            para = para.Replace("≥", "&ge;");
            para = para.Replace("⊂", "&sub;");
            para = para.Replace("⊃", "&sup;");
            para = para.Replace("⊄", "&nsub;");
            para = para.Replace("⊆", "&sube;");
            para = para.Replace("⊇", "&supe;");
            para = para.Replace("⊕", "&oplus;");
            para = para.Replace("⊗", "&otimes;");
            para = para.Replace("⊥", "&perp;");
            para = para.Replace("⋅", "&sdot;");
            para = para.Replace("⌈", "&lceil;");
            para = para.Replace("⌉", "&rceil;");
            para = para.Replace("⌊", "&lfloor;");
            para = para.Replace("⌋", "&rfloor;");
            para = para.Replace("◊", "&loz;");
            para = para.Replace("♠", "&spades;");
            para = para.Replace("♣", "&clubs;");
            para = para.Replace("♥", "&hearts;");
            para = para.Replace("♦", "&diams;");
            para = para.Replace("¡", "&iexcl;");
            para = para.Replace("¢", "&cent;");
            para = para.Replace("£", "&pound;");
            para = para.Replace("¤", "&curren;");
            para = para.Replace("¥", "&yen;");
            para = para.Replace("¦", "&brvbar;");
            para = para.Replace("§", "&sect;");
            para = para.Replace("©", "&copy;");
            para = para.Replace("ª", "&ordf;");
            para = para.Replace("«", "&laquo;");
            para = para.Replace("¬", "&not;");
            para = para.Replace("®", "&reg;");
            para = para.Replace("±", "&plusmn;");
            para = para.Replace("µ", "&micro;"); ;
            return para;
        }
    }
}
