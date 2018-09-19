using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace wtc_3_forms
{
	public class c_File
	{
		public fileType FileType { get; set; } = fileType.NONE;

		private string _filePath { get; set; }
		public string FilePath { get { return _filePath; } set { _filePath = value; fileCretaed(); } }

		public string FileExtension { get; set; }
		public string FileName { get; set; }
		public long FileSize { get; set; }

		public string FileTextContents { get; set; } = "";
		public string FileOriginalDataB64 { get; set; } = "";
		public string FileMD5Checksum { get; set; } = "";

		public fileRegex Regex { get; set; } = fileRegex.NONE;
		public string CustomRegex { get; set; } = "";


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
				if (FileExtension == ".pdf") { FileTextContents = c_PdfReader.readPdfDocument(FilePath); FileType = fileType.PDF; if (Regex == fileRegex.NONE) { Regex = fileRegex.PDF; } }
				else
				if (FileExtension == ".txt") { FileTextContents = File.ReadAllText(FilePath); FileType = fileType.TXT; if (Regex == fileRegex.NONE) { Regex = fileRegex.TXT; } }
				else
				if (FileExtension == ".rtf") { FileTextContents = RtfToText(FilePath); FileType = fileType.RTF; if (Regex == fileRegex.NONE) { Regex = fileRegex.TXT; } }
				else
				if (FileExtension == ".html" ||
					FileExtension == ".htm") { FileTextContents = htmlToText(FilePath); FileType = fileType.HTML; if (Regex == fileRegex.NONE) { Regex = fileRegex.HTML; } }
				else { FileTextContents = File.ReadAllText(FilePath); FileType = fileType.OTHER; if (Regex == fileRegex.NONE) { Regex = fileRegex.BASIC; } }
			}
			catch (Exception ex) { Console.Error.WriteLine(ex); return false; }
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
			RichTextBox rtb = new RichTextBox
			{
				Rtf = File.ReadAllText(path)
			};
			return rtb.Text;
		}

		public string htmlToText(string path)
		{
			WebBrowser wb = new WebBrowser
			{
				ScriptErrorsSuppressed = true
			};
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
			return "{ \"FileName\":\"" + FileName + "\", \"FileType\":\"" + FileType + "\", \"FileSize\":\"" + FileSize + "b\", \"FilePath\":\"" + FilePath.Replace(@"\", @"\\") + "\" }";
		}

		public string ToFullString()
		{

			TypeInfo cFile = typeof(c_File).GetTypeInfo();
			IEnumerable<PropertyInfo> declaredProperties = cFile.DeclaredProperties;
			IEnumerable<MethodInfo> declaredMethods = cFile.DeclaredMethods;

			return $"----------------------------------------------------------------- \r\n| {"FilePath:".PadRight(30, '.')}{FilePath} \r\n| {"FileName:".PadRight(30, '.')}{FileName} \r\n| {"Regex:".PadRight(30, '.')}{Regex} \r\n| {(Regex == fileRegex.CUSTOM ? $"{"CustomRegex:".PadRight(30, '.') + CustomRegex} \r\n|" : "")} {"FileExtension:".PadRight(30, '.')}{FileExtension} \r\n| {"FileSize:".PadRight(30, '.')}{FileSize}b (~{((float)FileSize / 1024)}kb) \r\n| {"FileTextContents:".PadRight(30, '.')}{FileTextContents.Substring(0, FileTextContents.Length > 20 ? 20 : FileTextContents.Length) + "..."} \r\n| {"FileOriginalDataB64:".PadRight(30, '.')}{FileOriginalDataB64.Substring(0, FileOriginalDataB64.Length > 20 ? 20 : FileOriginalDataB64.Length) + "..."} \r\n| {"FileMD5Checksum:".PadRight(30, '.')}{FileMD5Checksum} \r\n-----------------------------------------------------------------";
		}
	}

	public class FileContainer : Collection<c_File>//, IEnumerable<c_File>
	{
		public FileContainer() : base() { new FileContainer(new List<c_File>()); }
		public FileContainer(List<c_File> Files) : base(Files)
		{
			List<c_File> getAllOfType(fileType ft)
			{
				List<c_File> fileList = (from f in Files where f.FileType == ft select f).ToList();
				return fileList;
			}

			List<c_File> popAllOfType(fileType ft)
			{
				List<c_File> fils = new List<c_File>();
				fils = (from f in Files where f.FileType == ft select f).ToList();
				foreach (c_File ff in fils)
				{
					Files.Remove(ff);
				}

				return fils;
			}

			IEnumerable<c_File> getFileList()
			{
				return Files;
			}

			void Add(c_File file)
			{
				Files.Add(file);
				#region DEBUG
#if DEBUG
				Console.WriteLine(file.ToString());
#endif
#endregion
			}

			/// <summary>
			/// <para>Pops last element off and returns it</para>
			/// <para>LIFO style. EG: [A,B,C] -PoP-> [A,B] C</para>
			/// </summary>
			c_File pop()
			{
				c_File v = null;

				try
				{
					if (Files.Count > 0)
					{
						v = Files[Files.Count];
						Files.Remove(Files[Files.Count]);
					}
				}
				catch (Exception ex) { Console.WriteLine(ex); }

				return v;
			}

			/// <summary>
			/// <para>Pushes new element to List</para>
			/// <para>EG: [A,B] -Push-C-> [A,B,C]</para>
			/// </summary>
			bool push(c_File file)
			{
				try
				{
					Files.Add(file);
					#region DEBUG
					#if DEBUG
					Console.WriteLine(file.ToString());
					#endif
					#endregion
					return true;
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
					return false;
				}
			}

			int GetHashCode()
			{
				return base.GetHashCode();
			}

			string ToString()
			{
				return base.ToString();
			}

			void AddRange(IEnumerable<c_File> files)
			{
				foreach (c_File f in files)
				{
					Files.Add(f);
				}
			}

			c_File[] ToArray()
			{
				return Files.ToArray();
			}

			void makeUnique()
			{
				List<c_File> fTmp = new List<c_File>();
				foreach (c_File file in Files) { if (!fTmp.Select(x => x.FileMD5Checksum).Contains(file.FileMD5Checksum)) { fTmp.Add(file); } }
				Files = fTmp;
			}

			bool Equals(object obj)
			{
				return base.Equals(obj);
			}

		}

		public void AddRange(IEnumerable<c_File> files)
		{
			foreach (c_File f in files)
			{
				this.Add(f);
			}
		}

		public void makeUnique()
		{
			List<c_File> fTmp = new List<c_File>();
			foreach (c_File file in this) { if (!fTmp.Select(x => x.FileMD5Checksum).Contains(file.FileMD5Checksum)) { fTmp.Add(file); } }
			this.Clear();
			this.AddRange(fTmp);
		}









	}

		
	
	public enum fileType
	{
		PDF,
		TXT,
		RTF,
		HTML,
		OTHER,
		NONE
	}

	public enum fileRegex
	{
		BASIC,		//SUPER BASIC, just tries and gets dates and times of working days
		PDF,		//General PDF regex, tailored to the shitty PDF we generate
		TXT,		//General string regex, tailored to when someone copies out the text from a generic reader
		TXT2,       //Better string regex, tailored to when someone copies out the text from adobe reader
		HTML,		//Experimental, in case there's html generated table instead of pdf
		HEURISTIC,	//Experimental, same as basic but attempts to find the pattern of the data and generate regex tailored to that
		CUSTOM,		//Custom in case user writes their own regex they want to custom use
		NONE		//Fuck this shit, i'm out...
	}
}