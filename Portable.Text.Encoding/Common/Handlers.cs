/*
 * Handlers.cs - Implementation of the "I18N.Common.Handlers" class.
 *
 * Copyright (c) 2002  Southern Storm Software, Pty Ltd
 *
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the "Software"),
 * to deal in the Software without restriction, including without limitation
 * the rights to use, copy, modify, merge, publish, distribute, sublicense,
 * and/or sell copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
 * THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR
 * OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
 * ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.Collections.Generic;

namespace Portable.Text {
	// This class provides an internal list of handlers, for runtime
	// engines that do not implement the altered "GetFile" semantics.
	// The list must be kept up to date manually.
	static sealed class Handlers
	{
		public static readonly string[] List = {
			// CJK
			"Portable.Text.CP932",
			"Portable.Text.CP936",
			"Portable.Text.CP949",
			"Portable.Text.CP950",
			"Portable.Text.CP50220",
			"Portable.Text.CP50221",
			"Portable.Text.CP50222",
			"Portable.Text.CP51932",
			"Portable.Text.CP51949",
			"Portable.Text.CP54936",
			"Portable.Text.ENCbig5",
			"Portable.Text.ENCgb2312",
			"Portable.Text.ENCshift_jis",
			"Portable.Text.ENCiso_2022_jp",
			"Portable.Text.ENCeuc_jp",
			"Portable.Text.ENCeuc_kr",
			"Portable.Text.ENCuhc",
			"Portable.Text.ENCgb18030",

			// MidEast
			"Portable.Text.CP1254",
			"Portable.Text.ENCwindows_1254",
			"Portable.Text.CP1255",
			"Portable.Text.ENCwindows_1255",
			"Portable.Text.CP1256",
			"Portable.Text.ENCwindows_1256",
			"Portable.Text.CP28596",
			"Portable.Text.ENCiso_8859_6",
			"Portable.Text.CP28598",
			"Portable.Text.ENCiso_8859_8",
			"Portable.Text.CP28599",
			"Portable.Text.ENCiso_8859_9",
			"Portable.Text.CP38598",
			"Portable.Text.ENCwindows_38598",

			// Other
			"Portable.Text.CP1251",
			"Portable.Text.ENCwindows_1251",
			"Portable.Text.CP1257",
			"Portable.Text.ENCwindows_1257",
			"Portable.Text.CP1258",
			"Portable.Text.ENCwindows_1258",
			"Portable.Text.CP20866",
			"Portable.Text.ENCkoi8_r",
			"Portable.Text.CP21866",
			"Portable.Text.ENCkoi8_u",
			"Portable.Text.CP28594",
			"Portable.Text.ENCiso_8859_4",
			"Portable.Text.CP28595",
			"Portable.Text.ENCiso_8859_5",
			"Portable.Text.ISCIIEncoding",
			"Portable.Text.CP57002",
			"Portable.Text.CP57003",
			"Portable.Text.CP57004",
			"Portable.Text.CP57005",
			"Portable.Text.CP57006",
			"Portable.Text.CP57007",
			"Portable.Text.CP57008",
			"Portable.Text.CP57009",
			"Portable.Text.CP57010",
			"Portable.Text.CP57011",
			"Portable.Text.ENCx_iscii_de",
			"Portable.Text.ENCx_iscii_be",
			"Portable.Text.ENCx_iscii_ta",
			"Portable.Text.ENCx_iscii_te",
			"Portable.Text.ENCx_iscii_as",
			"Portable.Text.ENCx_iscii_or",
			"Portable.Text.ENCx_iscii_ka",
			"Portable.Text.ENCx_iscii_ma",
			"Portable.Text.ENCx_iscii_gu",
			"Portable.Text.ENCx_iscii_pa",
			"Portable.Text.CP874",
			"Portable.Text.ENCwindows_874",

			// Rare
			"Portable.Text.CP1026",
			"Portable.Text.ENCibm1026",
			"Portable.Text.CP1047",
			"Portable.Text.ENCibm1047",
			"Portable.Text.CP1140",
			"Portable.Text.ENCibm01140",
			"Portable.Text.CP1141",
			"Portable.Text.ENCibm01141",
			"Portable.Text.CP1142",
			"Portable.Text.ENCibm01142",
			"Portable.Text.CP1143",
			"Portable.Text.ENCibm01143",
			"Portable.Text.CP1144",
			"Portable.Text.ENCibm1144",
			"Portable.Text.CP1145",
			"Portable.Text.ENCibm1145",
			"Portable.Text.CP1146",
			"Portable.Text.ENCibm1146",
			"Portable.Text.CP1147",
			"Portable.Text.ENCibm1147",
			"Portable.Text.CP1148",
			"Portable.Text.ENCibm1148",
			"Portable.Text.CP1149",
			"Portable.Text.ENCibm1149",
			"Portable.Text.CP20273",
			"Portable.Text.ENCibm273",
			"Portable.Text.CP20277",
			"Portable.Text.ENCibm277",
			"Portable.Text.CP20278",
			"Portable.Text.ENCibm278",
			"Portable.Text.CP20280",
			"Portable.Text.ENCibm280",
			"Portable.Text.CP20284",
			"Portable.Text.ENCibm284",
			"Portable.Text.CP20285",
			"Portable.Text.ENCibm285",
			"Portable.Text.CP20290",
			"Portable.Text.ENCibm290",
			"Portable.Text.CP20297",
			"Portable.Text.ENCibm297",
			"Portable.Text.CP20420",
			"Portable.Text.ENCibm420",
			"Portable.Text.CP20424",
			"Portable.Text.ENCibm424",
			"Portable.Text.CP20871",
			"Portable.Text.ENCibm871",
			"Portable.Text.CP21025",
			"Portable.Text.ENCibm1025",
			"Portable.Text.CP37",
			"Portable.Text.ENCibm037",
			"Portable.Text.CP500",
			"Portable.Text.ENCibm500",
			"Portable.Text.CP708",
			"Portable.Text.ENCasmo_708",
			"Portable.Text.CP852",
			"Portable.Text.ENCibm852",
			"Portable.Text.CP855",
			"Portable.Text.ENCibm855",
			"Portable.Text.CP857",
			"Portable.Text.ENCibm857",
			"Portable.Text.CP858",
			"Portable.Text.ENCibm00858",
			"Portable.Text.CP862",
			"Portable.Text.ENCibm862",
			"Portable.Text.CP864",
			"Portable.Text.ENCibm864",
			"Portable.Text.CP866",
			"Portable.Text.ENCibm866",
			"Portable.Text.CP869",
			"Portable.Text.ENCibm869",
			"Portable.Text.CP870",
			"Portable.Text.ENCibm870",
			"Portable.Text.CP875",
			"Portable.Text.ENCibm875",

			// Western
			"Portable.Text.CP10000",
			"Portable.Text.ENCmacintosh",
			"Portable.Text.CP10079",
			"Portable.Text.ENCx_mac_icelandic",
			"Portable.Text.CP1250",
			"Portable.Text.ENCwindows_1250",
			"Portable.Text.CP1252",
			"Portable.Text.ENCwindows_1252",
			"Portable.Text.CP1253",
			"Portable.Text.ENCwindows_1253",
			"Portable.Text.CP28592",
			"Portable.Text.ENCiso_8859_2",
			"Portable.Text.CP28593",
			"Portable.Text.ENCiso_8859_3",
			"Portable.Text.CP28597",
			"Portable.Text.ENCiso_8859_7",
			"Portable.Text.CP28605",
			"Portable.Text.ENCiso_8859_15",
			"Portable.Text.CP437",
			"Portable.Text.ENCibm437",
			"Portable.Text.CP850",
			"Portable.Text.ENCibm850",
			"Portable.Text.CP860",
			"Portable.Text.ENCibm860",
			"Portable.Text.CP861",
			"Portable.Text.ENCibm861",
			"Portable.Text.CP863",
			"Portable.Text.ENCibm863",
			"Portable.Text.CP865",
			"Portable.Text.ENCibm865"
		};
		static Dictionary<string, string> aliases;

		public static string GetAlias (string name)
		{
			if (aliases == null)
				BuildHash ();

			string v;
			aliases.TryGetValue (name, out v);
			return v;
		}

		static void BuildHash ()
		{
			aliases = new Dictionary<string, string> (StringComparer.OrdinalIgnoreCase);

			aliases.Add ("arabic", "iso_8859_6");
			aliases.Add ("csISOLatinArabic", "iso_8859_6");
			aliases.Add ("ECMA_114", "iso_8859_6");
			aliases.Add ("ISO_8859_6:1987", "iso_8859_6");
			aliases.Add ("iso_ir_127", "iso_8859_6");

			aliases.Add ("cp1256", "windows_1256");

			aliases.Add ("csISOLatin4", "iso_8859_4");
			aliases.Add ("ISO_8859_4:1988", "iso_8859_4");
			aliases.Add ("iso_ir_110", "iso_8859_4");
			aliases.Add ("l4", "iso_8859_4");
			aliases.Add ("latin4", "iso_8859_4");

			aliases.Add ("cp852", "ibm852");

			aliases.Add ("csISOLatin2", "iso_8859_2");
			aliases.Add ("iso_8859_2:1987", "iso_8859_2");
			aliases.Add ("iso8859_2", "iso_8859_2");
			aliases.Add ("iso_ir_101", "iso_8859_2");
			aliases.Add ("l2", "iso_8859_2");
			aliases.Add ("latin2", "iso_8859_2");

			aliases.Add ("x-cp1250", "windows_1250");

			aliases.Add ("chinese", "gb2312");
			aliases.Add ("CN-GB", "gb2312");
			aliases.Add ("csGB2312", "gb2312");
			aliases.Add ("csGB231280", "gb2312");
			aliases.Add ("csISO58GB231280", "gb2312");
			aliases.Add ("GB_2312_80", "gb2312");
			aliases.Add ("GB231280", "gb2312");
			aliases.Add ("GB2312_80", "gb2312");
			aliases.Add ("GBK", "gb2312");
			aliases.Add ("iso_ir_58", "gb2312");

			aliases.Add ("cn-big5", "big5");
			aliases.Add ("csbig5", "big5");
			aliases.Add ("x-x-big5", "big5");

			aliases.Add ("cp866", "ibm866");

			aliases.Add ("csISOLatin5", "iso_8859_5");
			aliases.Add ("csISOLatinCyrillic", "iso_8859_5");
			aliases.Add ("cyrillic", "iso_8859_5");
			aliases.Add ("ISO_8859_5:1988", "iso_8859_5");
			aliases.Add ("iso_ir_144", "iso_8859_5");
			aliases.Add ("l5", "iso_8859_5");

			aliases.Add ("csKOI8R", "koi8_r");
			aliases.Add ("koi", "koi8_r");
			aliases.Add ("koi8", "koi8_r");
			aliases.Add ("koi8r", "koi8_r");

			aliases.Add ("koi8ru", "koi8_u");

			aliases.Add ("x-cp1251", "windows_1251");

			aliases.Add ("csISOLatinGreek", "iso_8859_7");
			aliases.Add ("ECMA_118", "iso_8859_7");
			aliases.Add ("ELOT_928", "iso_8859_7");
			aliases.Add ("greek", "iso_8859_7");
			aliases.Add ("greek8", "iso_8859_7");
			aliases.Add ("ISO_8859_7:1987", "iso_8859_7");
			aliases.Add ("iso_ir_126", "iso_8859_7");

			aliases.Add ("csISOLatinHebrew", "iso_8859_8");
			aliases.Add ("hebrew", "iso_8859_8");
			aliases.Add ("ISO_8859_8:1988", "iso_8859_8");
			aliases.Add ("iso_ir_138", "iso_8859_8");

			aliases.Add ("csShiftJIS", "shift_jis");
			aliases.Add ("csWindows31J", "shift_jis");
			aliases.Add ("ms_Kanji", "shift_jis");
			aliases.Add ("shift-jis", "shift_jis");
			aliases.Add ("x-ms-cp932", "shift_jis");
			aliases.Add ("x-sjis", "shift_jis");

			aliases.Add ("iso_2022_kr", "euc_kr");

			aliases.Add ("csISOLatin3", "iso_8859_3");
			aliases.Add ("ISO_8859_3:1988", "iso_8859_3");
			aliases.Add ("iso_ir_109", "iso_8859_3");
			aliases.Add ("l3", "iso_8859_3");
			aliases.Add ("latin3", "iso_8859_3");

			aliases.Add ("csISOLatin9", "iso_8859_15");
			aliases.Add ("l9", "iso_8859_15");
			aliases.Add ("latin9", "iso_8859_15");

			aliases.Add ("cp437", "ibm437");
			aliases.Add ("csPC8", "ibm437");
			aliases.Add ("CodePage437", "ibm437");

			aliases.Add ("DOS_874", "windows_874");
			aliases.Add ("iso_8859_11", "windows_874");
			aliases.Add ("TIS_620", "windows_874");
		}
	}
}
