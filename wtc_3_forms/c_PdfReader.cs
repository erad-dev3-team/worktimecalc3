using PdfSharp.Pdf;
using PdfSharp.Pdf.Content;
using PdfSharp.Pdf.Content.Objects;
using PdfSharp.Pdf.IO;
using System.Collections.Generic;
using System.Text;

namespace wtc_3_forms
{
	public static class c_PdfReader
	{
		public static string readPdfDocument(PdfDocument document)
		{
			StringBuilder sb = new StringBuilder();

			foreach (var p in document.Pages)
			{
				CObject content = ContentReader.ReadContent(p);
				sb.Append(string.Join(" ", ExtractText(content)));
			}

			return sb.ToString();
		}

		public static string readPdfDocument(string path)
		{
			PdfDocument pd = PdfReader.Open(path, PdfDocumentOpenMode.ReadOnly);
			return readPdfDocument(pd);
		}

		private static IEnumerable<string> ExtractText(CObject cObject)
		{
			List<string> textList = new List<string>();

			if (cObject is CSequence)
			{
				var cSequence = cObject as CSequence;
				foreach (var element in cSequence)
				{
					textList.AddRange(extract(element));
				}
			}

			return textList;
		}

		private static IEnumerable<string> extract(CObject cObject)
		{
			List<string> lst = new List<string>();

			if (cObject is COperator)
			{
				var cOperator = cObject as COperator;
				if (cOperator.OpCode.Name == OpCodeName.Tj.ToString() ||
					cOperator.OpCode.Name == OpCodeName.TJ.ToString())
				{
					foreach (var cOperand in cOperator.Operands)
					{
						lst.Add(extract2(cOperand));
					}
				}
			}

			return lst;
		}

		private static string extract2(CObject cObject)
		{
			if (cObject is CString)
			{
				var cString = cObject as CString;
				return (cString.Value);
			}

			return "";
		}
	}
}