using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace wtc_3_forms
{
	internal class c_File
	{
		private string	_filePath			{ get; set; }
		public string	FilePath			{ get { return _filePath; } set { _filePath = value; fileCretaed(); } }

		public string	FileExtension		{ get; set; }
		public string	FileName			{ get; set; }
		public long		FileSize			{ get; set; }

		public string	FileTextContents	{ get; set; } = "";
		public string	FileOriginalDataB64 { get; set; } = "";
		public string	FileMD5Checksum		{ get; set; } = "";

		public void fileCretaed()
		{
			FileInfo fi = new FileInfo(_filePath);
			FileExtension = fi.Extension.ToLower();
			FileName = fi.Name;
			FileSize = fi.Length;
		}

		public bool generateFileTextContents()
		{
			if (FileExtension == "" || FilePath == "") { return false; }

			try
			{
				if (FileExtension == ".pdf")	{ FileTextContents = c_PdfReader.readPdfDocument(FilePath); }
				else 
				if (FileExtension == ".txt")	{ FileTextContents = File.ReadAllText(FilePath);			}
				else 
				if (FileExtension == ".rtf")	{ FileTextContents = RtfToText(FilePath);					}
				else 
				if (FileExtension == ".html" || 
					FileExtension == ".htm")	{ FileTextContents = htmlToText(FilePath);					}
			}
			catch(Exception ex) { Console.Error.WriteLine(ex); return false; }
			return true;
		}

		public bool generateB64String()
		{
			if (FileName == "" || FileExtension == "" || FilePath == "") { return false; }

			List<byte> bytes = new List<byte>();

			try
			{
				ToBase64Transform tb64 = new ToBase64Transform();
				byte[] outBuffer = new byte[tb64.OutputBlockSize];
				using (MemoryStream outputFileStream = new MemoryStream(outBuffer))
				{
					using (FileStream inputFileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
					{
						int ibs = tb64.InputBlockSize;
						byte[] outputBytes = new byte[tb64.OutputBlockSize];
						byte[] inputBytes = new byte[inputFileStream.Length];
						inputFileStream.Read(inputBytes, 0, inputBytes.Length);
						int inputBlockSize = tb64.InputBlockSize;
						int inputOffset = 0;

						while (inputBytes.Length - inputOffset > inputBlockSize)
						{
							tb64.TransformBlock(
								inputBytes,
								inputOffset,
								inputBytes.Length - inputOffset,
								outputBytes,
								0);

							inputOffset += tb64.InputBlockSize;
							outputFileStream.Write(
								outputBytes,
								0,
								tb64.OutputBlockSize);

							outputFileStream.Flush();
							bytes.AddRange(outputBytes);
							outputFileStream.Seek(0, SeekOrigin.Begin);
						}

						// Transform the final block of data.
						outputBytes = tb64.TransformFinalBlock(
							inputBytes,
							inputOffset,
							inputBytes.Length - inputOffset);

						outputFileStream.Write(outputBytes, 0, outputBytes.Length);
						outputFileStream.Flush();
						bytes.AddRange(outputBytes);
					}
				}
			}
			catch (Exception ex) { Console.Error.WriteLine(ex); return false; }

			FileOriginalDataB64 = Encoding.ASCII.GetString(bytes.ToArray());

			return true;
		}

		public bool generateMD5Checksum()
		{
			if (FileName == "" || FileExtension == "" || FilePath == "") { return false; }

			try
			{
				string md5 = "";
				byte[] md5b = new MD5CryptoServiceProvider().ComputeHash(File.ReadAllBytes(FilePath));

				foreach (byte b in md5b)
				{
					md5 += b.ToString("X2").ToUpper();
				}

				FileMD5Checksum = md5;
			}
			catch (Exception ex) { Console.Error.WriteLine(ex.ToString()); return false; }

			return true;
		}

		public string RtfToText(string path)
		{
			RichTextBox rtb = new RichTextBox();
			rtb.Rtf = File.ReadAllText(path);
			return rtb.Text;
		}

		public string htmlToText(string path)
		{
			WebBrowser wb = new WebBrowser();
			wb.ScriptErrorsSuppressed = true;
			wb.Navigate("about:blank");

			wb.Document.Write(File.ReadAllText(path));
			
			return wb.Document.GetElementsByTagName("BODY")[0].InnerText;
		}

		public bool initializeFile()
		{
			return (
						generateFileTextContents() &&
						generateB64String() &&
						generateMD5Checksum()
					);
		}

		new public string ToString()
		{
			
			return $"{FilePath} \r\n {FileName} \r\n {FileExtension} \r\n {FileSize} \r\n {FileTextContents.Substring(0, FileTextContents.Length > 20 ? 20 : FileTextContents.Length) + "..."} \r\n {FileOriginalDataB64.Substring(0, FileOriginalDataB64.Length > 20 ? 20 : FileOriginalDataB64.Length) + "..."} \r\n {FileMD5Checksum}";
		}
	}
}