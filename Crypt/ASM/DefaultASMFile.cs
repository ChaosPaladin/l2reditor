using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace L2REditor.Engine.ASM {
	public class DefaultASMFile {
		private static readonly byte[] EOF = { //end file: ' SafePackage'
			0x0c, 0x53, 0x61, 0x66, 0x65, 0x50, 0x61, 0x63, 0x6b, 0x61, 0x67, 0x65, 0x00
		};

		public readonly IList<ASMData[]> values = new List<ASMData[]>(); //data
		protected DefaultASMType[] types { get; set; }
		protected int header { get; set; }

		public DefaultASMFile() {
			
		}

		public bool deserialize(BinaryReader reader) {
			//st pos 4 bytes
			for (;;) {
				//check EOF
				if (reader.BaseStream.Position >= reader.BaseStream.Length - (EOF.Length + 1))
					break;

				ASMData[] datas = new ASMData[types.Length];
				for (int i = 0; i < datas.Length; i++)
					if ((datas[i] = types[i].readData(reader)) == null) { //failed read data type
						free();
						return false;
					}
				values.Add(datas);
			}

			return true;
		}

		public bool serialize(string file) {
			if(File.Exists(file)) File.Delete(file);

			using (var fs = new BinaryWriter(File.Create(file))) {
				fs.Write(header); //write file header

				foreach (var value in values) {
					for (int i = 0; i < value.Length; i++) {
						if (!types[i].writeData(value[i], fs))
							return false;
					}
				}

				fs.Write(EOF); //write EOF
			}

			return true;
		}

		public void free() {
			values.Clear();
		}
	}
}
