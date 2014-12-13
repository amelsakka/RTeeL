using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace RTeeL
{
    class RTeeL
    {
        // Developed by: Ahmad Sakka - http://ahmadelsakka.com
        // amelsakka@gmail.com
        private Letter[] letters;

        public string fixRTeeL(string s)
        {
            string pattern = "([^><\n\r]*[\u0600-\u06FF]+[^<\n\r]*)(?=[<\n\r]*)";
            return Regex.Replace(s, pattern, new MatchEvaluator(Replacer));
        }

        private string Replacer(Match m)
        {
            string[] textArr = m.ToString().Split(' ');
            Array.Reverse(textArr);
            string fixedT = "";
			for (int i = 0; i < textArr.Length; i++) {
		        fixedT = (i>0) ? fixedT + " " : fixedT;
                // fixedT = (Regex.IsMatch(textArr[i], @"[\u0600-\u06FF]")) ? fixedT + Connect(textArr[i]) : fixedT + textArr[i];
                string[] textArr2 = Regex.Split(textArr[i], @"([\u0600-\u06FF\(\)]+)");
                for (int j = (textArr2.Length - 1); j >= 0; j--)
                {
                    fixedT = (Regex.IsMatch(textArr2[j], @"[\u0600-\u06FF\(\)]"))
                        ? fixedT + Connect(textArr2[j])
                        : fixedT + textArr2[j];
                }
                    
	        }
			return fixedT;
		}


        private string Connect(string word)
        {
            string returnS = "";

            bool lamAlef = false;
	        // var wordArr = word.split('');
	        string lam = "u0644";
	        string L = "";
	        string Lprev = "";
	        string Lnext = "";
	        string form = ""; // first - mid - final - iso "isolated"

	        for (int j = (word.Length - 1); j >= 0; j--) { 
                
		        if(Regex.IsMatch(word[j].ToString(), @"[\u0621-\u064a]")){
			        L = (lamAlef) ? getS(L, "LA") : to16(word[j]);
                    lamAlef = false; // true means the alef part & write nothing || false=Lam part & write the lamalef

			        if(j == (word.Length - 1) || !getB(L, "ToNext")) { // if last letter or not connected to next or lam-alef (either final or iso)
				        if(j>0 && getB(L, "ToPrev")) {
					        Lprev = to16(word[j-1]);
					        // if previous letter connected to the next, then this one is final, otherwise it's isolated
					        if( (from r in letters where r.Id==Lprev select r.Id).Count()>0 ) // check if it's an arabic letter
						        form = (getB(Lprev, "ToNext")) ? "Final" : "Iso"; 
					        else
						        form = "Iso";
					
					        if(getS(L, "LA")!="" && Lprev == lam) { // lam alef condition
						        lamAlef = true; // this letter is lam alef
					        }
				        } // if not first letter and connected to prev (everyone but hamza)
				        else form = "Iso";
			        } // if final or iso

			        else {
				        Lnext = to16(word[j+1]);
				        bool nextConnected = getB(Lnext, "ToPrev");
				        
				        if(j>0) { // not first letter
					        Lprev = to16(word[j-1]);
                            if (getB(Lprev, "ToNext"))// if previous letter connected to the next, then this one is mid or final
                                form = (nextConnected) ? "Mid" : "Final";
                            else
                                form = (nextConnected) ? "First" : "Iso";
				        } else
					        form = (nextConnected) ? "First" : "Iso";
			        }
                    char rs = (char)int.Parse(getS(L, form).Substring(1), NumberStyles.AllowHexSpecifier); // remove leading 'u'
                    if (!lamAlef) returnS += rs.ToString();

		        } else {
			        if(word[j].ToString()=="(")	returnS += ")";
                    else if (word[j].ToString() == ")") returnS += "(";
                    else returnS += word[j].ToString();
		        }
            }
        
	        return returnS;
        }

        private string to16(char c) {
            return String.Format(@"u{0:x4}", (ushort)c);
        }

        private bool getB(string id, string field){
            switch (field) {
                case "ToPrev":
                    if( (from r in letters where r.Id==id select r.Id).Count()>0 )
					    return (from r in letters where r.Id==id select r.ToPrev).First();
                    else
                        return false;

                case "ToNext":
                    if( (from r in letters where r.Id==id select r.Id).Count()>0 )
					    return (from r in letters where r.Id==id select r.ToNext).First();
                    else
                        return false;
                default:
                        return false;
            }

        }

        private string getS(string id, string field){
            switch (field) {
                case "First":
                    if( (from r in letters where r.Id==id select r.Id).Count()>0 )
					    return (from r in letters where r.Id==id select r.First).First();
                    else
                        return "";

                case "Mid":
                    if( (from r in letters where r.Id==id select r.Id).Count()>0 )
					    return (from r in letters where r.Id==id select r.Mid).First();
                    else
                        return "";
                
                case "Final":
                    if( (from r in letters where r.Id==id select r.Id).Count()>0 )
					    return (from r in letters where r.Id==id select r.Final).First();
                    else
                        return "";

                case "Iso":
                    if( (from r in letters where r.Id==id select r.Id).Count()>0 )
					    return (from r in letters where r.Id==id select r.Iso).First();
                    else
                        return "";

                case "LA":
                    if( (from r in letters where r.Id==id select r.Id).Count()>0 )
					    return (from r in letters where r.Id==id select r.LA).First();
                    else
                        return "";

                default:
                        return "";
            }

        }

        public RTeeL()
        {
            letters = new[] {
                new Letter { Id="u0621", First="ufe80", Mid="ufe80", Final="ufe80", Iso="ufe80", ToPrev=false, ToNext=false, LA=""},
                new Letter { Id="u0622", First="ufe81", Mid="ufe82", Final="ufe82", Iso="ufe81", ToPrev=true, ToNext=false, LA="lamalef1"},
                new Letter { Id="u0623", First="ufe83", Mid="ufe84", Final="ufe84", Iso="ufe83", ToPrev=true, ToNext=false, LA="lamalef2"},
                new Letter { Id="u0624", First="ufe85", Mid="ufe86", Final="ufe86", Iso="ufe85", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="u0625", First="ufe87", Mid="ufe88", Final="ufe88", Iso="ufe87", ToPrev=true, ToNext=false, LA="lamalef3"},
                new Letter { Id="u0626", First="ufe8b", Mid="ufe8c", Final="ufe8a", Iso="ufe89", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0627", First="ufe8d", Mid="ufe8e", Final="ufe8e", Iso="ufe8d", ToPrev=true, ToNext=false, LA="lamalef4"},
                new Letter { Id="u0628", First="ufe91", Mid="ufe92", Final="ufe90", Iso="ufe8f", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0629", First="", Mid="", Final="ufe94", Iso="ufe93", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="u062a", First="ufe97", Mid="ufe98", Final="ufe96", Iso="ufe95", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u062b", First="ufe9b", Mid="ufe9c", Final="ufe9a", Iso="ufe99", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u062c", First="ufe9f", Mid="ufea0", Final="ufe9e", Iso="ufe9d", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u062d", First="ufea3", Mid="ufea4", Final="ufea2", Iso="ufea1", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u062e", First="ufea7", Mid="ufea8", Final="ufea6", Iso="ufea5", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u062f", First="ufea9", Mid="ufeaa", Final="ufeaa", Iso="ufea9", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="u0630", First="ufeab", Mid="ufeac", Final="ufeac", Iso="ufeab", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="u0631", First="ufead", Mid="ufeae", Final="ufeae", Iso="ufead", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="u0632", First="ufeaf", Mid="ufeb0", Final="ufeb0", Iso="ufeaf", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="u0633", First="ufeb3", Mid="ufeb4", Final="ufeb2", Iso="ufeb1", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0634", First="ufeb7", Mid="ufeb8", Final="ufeb6", Iso="ufeb5", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0635", First="ufebb", Mid="ufebc", Final="ufeba", Iso="ufeb9", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0636", First="ufebf", Mid="ufec0", Final="ufebe", Iso="ufebd", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0637", First="ufec3", Mid="ufec4", Final="ufec2", Iso="ufec1", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0638", First="ufec7", Mid="ufec8", Final="ufec6", Iso="ufec5", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0639", First="ufecb", Mid="ufecc", Final="ufeca", Iso="ufec9", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u063a", First="ufecf", Mid="ufed0", Final="ufece", Iso="ufecd", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0641", First="ufed3", Mid="ufed4", Final="ufed2", Iso="ufed1", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0642", First="ufed7", Mid="ufed8", Final="ufed6", Iso="ufed5", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0643", First="ufedb", Mid="ufedc", Final="ufeda", Iso="ufed9", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0644", First="ufedf", Mid="ufee0", Final="ufede", Iso="ufedd", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0645", First="ufee3", Mid="ufee4", Final="ufee2", Iso="ufee1", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0646", First="ufee7", Mid="ufee8", Final="ufee6", Iso="ufee5", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0647", First="ufeeb", Mid="ufeec", Final="ufeea", Iso="ufee9", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0648", First="ufeed", Mid="ufeee", Final="ufeee", Iso="ufeed", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="u0649", First="ufef3", Mid="ufef4", Final="ufef0", Iso="ufeef", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u064a", First="ufef3", Mid="ufef4", Final="ufef2", Iso="ufef1", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="u0640", First="u0640", Mid="u0640", Final="u0640", Iso="u0640", ToPrev=true, ToNext=true, LA=""},
                new Letter { Id="lamalef1", First="ufef5", Mid="ufef6", Final="ufef6", Iso="ufef5", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="lamalef2", First="ufef7", Mid="ufef8", Final="ufef8", Iso="ufef7", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="lamalef3", First="ufef9", Mid="ufefa", Final="ufefa", Iso="ufef9", ToPrev=true, ToNext=false, LA=""},
                new Letter { Id="lamalef4", First="ufefb", Mid="ufefc", Final="ufefc", Iso="ufefb", ToPrev=true, ToNext=false, LA=""}
            };
        }

    }
}
