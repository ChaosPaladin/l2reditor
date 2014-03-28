using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace L2REditor.Engine.Crypt
{
    public class Crypt
    {
		private readonly ProcessStartInfo encdecProcess;
		private readonly ProcessStartInfo asmProcess;
		private readonly ProcessStartInfo disasmProcess;
		private readonly StringBuilder output = new StringBuilder();

		public CVersion.EVersion version { get; set; }

	    public Crypt(bool usingAsm = true) {
			if (!existsResources(usingAsm))
				throw new Exception("Corrupt resources!");
			encdecProcess = new ProcessStartInfo(@".\l2encdec.exe");
		    if (usingAsm) {
			    asmProcess = new ProcessStartInfo(@".\l2asm.exe");
			    disasmProcess = new ProcessStartInfo(@".\l2disasm.exe");
		    }
			configureProcessNfo(usingAsm);
	    }

		private bool existsResources(bool usingAsm) {
			return (!usingAsm || (File.Exists(@".\l2asm.exe") && File.Exists(@".\l2disasm.exe"))) && File.Exists(@".\l2encdec.exe");
	    }

		private void configureProcessNfo(bool usingAsm) {
		    encdecProcess.CreateNoWindow = true;
		    encdecProcess.RedirectStandardOutput = true;
		    encdecProcess.UseShellExecute = false;

			if (usingAsm) {
				asmProcess.CreateNoWindow = true;
				asmProcess.RedirectStandardOutput = true;
				asmProcess.UseShellExecute = false;

				disasmProcess.CreateNoWindow = true;
				disasmProcess.RedirectStandardOutput = true;
				disasmProcess.UseShellExecute = false;
			}
		}

	    public bool encryptFile(string inputFile, string outputFile, string cryptVersion) {
			encdecProcess.Arguments = String.Format("-e {0} {1} {2}", cryptVersion, inputFile, outputFile);
			Process process = Process.Start(encdecProcess);
			process.WaitForExit();

			_out(process.StandardOutput.ReadToEnd());

		    if (!File.Exists(outputFile)) {
				_out(String.Format("Failed encrypt file {0} to {1}", inputFile, outputFile));
			    return false;
		    }

		    return true;
	    }

	    public bool asmFile(string inputFile, string outputFile, DDF ddf, bool isASCII) {
		    if (!checkDDF(ddf.eDDF))
			    return false;

			asmProcess.Arguments = String.Format("-{3} -d {0} {1} {2}", ddf.eDDF, inputFile, outputFile, isASCII ? "f" : "l");
			Process process = Process.Start(asmProcess);
			process.WaitForExit();

			_out(process.StandardOutput.ReadToEnd());


			if (!File.Exists(outputFile)) {
				_out(String.Format("Failed serialize file {0} to {1}", inputFile, outputFile));
			    return false;
		    }

//			File.Delete(ddf.eDDF);
			return true;
	    }

		public bool decryptFile(string inputFile, string outputFile, string cryptVersion) {
			encdecProcess.Arguments = String.Format("-d {0} {1}", inputFile, outputFile);
			Process process = Process.Start(encdecProcess);
			process.WaitForExit();

			_out(process.StandardOutput.ReadToEnd());


			if (!File.Exists(outputFile)) {
				_out(String.Format("Failed decrypt file {0} to {1}", inputFile, outputFile));
				return false;
			}

			return true;
		}

	    public bool disasmFile(string inputFile, string outputFile, DDF ddf, bool isASCII) {
			if (!checkDDF(ddf.oDDF))
			    return false;

		    ddf.eDDF = IOUtils.getTempFile();
			disasmProcess.Arguments = String.Format("-{3} -d {0} -e {4} {1} {2}", ddf.oDDF, inputFile, outputFile, isASCII ? "f" : "l", ddf.eDDF);
			Process process = Process.Start(disasmProcess);
			process.WaitForExit();

			_out(process.StandardOutput.ReadToEnd());

		    if (!File.Exists(outputFile)) {
				_out(String.Format("Failed deserialize file {0} to {1}", inputFile, outputFile));
			    return false;
		    }

		    return true;
	    }

	    public string getCryptVersion(string inputFile) {
			using (Stream stream = File.Open(inputFile, FileMode.Open)) {
				var rawHeader = new byte[6];
				stream.Seek(22, SeekOrigin.Begin);
				_out("Jump to 22");
				var bytes = stream.Read(rawHeader, 0, rawHeader.Length);
				_out(String.Format("Read {0} bytes from {1}", bytes, inputFile));
				return Encoding.Unicode.GetString(rawHeader);
			}
	    }

	    public DDF getDDF(string inputFile) {
		    var ddf = Path.Combine(@".\",
			    Path.Combine(CVersion.getFolder(version), Path.GetFileNameWithoutExtension(inputFile) + ".ddf"));
		    if (!File.Exists(ddf))
			    return null;
		    return new DDF {oDDF = ddf};
	    }

	    public string getOut() {
		    try {
			    return output.ToString();
		    } finally {
			    output.Length = 0;
			    output.Capacity = 10;
		    }
	    }

		private bool checkDDF(string ddf) {
			if (version == CVersion.EVersion.NONE) {
				_out("Version not set");
				return false;
			}

			if (ddf == null || !File.Exists(ddf)) {
				_out("ASM DDF type not found!");
				return false;
			}
		    return true;
	    }

	    private void _out(string text) {
		    output.AppendLine(text);
	    }
    }
}
