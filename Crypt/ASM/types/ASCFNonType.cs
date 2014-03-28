using System;
using System.IO;
using System.Text;

namespace L2REditor.Engine.ASM.types {
	public class ASCFNonType : DefaultASMType {
		public ASCFNonType(string name, bool isArray) : base(name, isArray) {
		}

		public override ASMData readData(BinaryReader reader) {
			var dao = new ASMData(this);
			if (isArray) {
				uint count = reader.ReadUInt32();
				dao.data = new string[count];
				for (int i = 0; i < count; i++) {
					var strLen = reader.ReadByte();
					var bin = reader.ReadBytes(strLen);
					dao.data[i] = Encoding.ASCII.GetString(bin);
				}
			} else {
				var strLen = reader.ReadByte(); //max 255 inc null terminate
				var bin = reader.ReadBytes(strLen);
				dao.data = new[] { Encoding.ASCII.GetString(bin) };
			}

			return dao;
		}

		public override bool writeData(ASMData dao, BinaryWriter writer) {
			if (isArray) {
				writer.Write(Convert.ToUInt32(dao.data.Length));
				for (int i = 0; i < dao.data.Length; i++) {
					writer.Write((byte)dao.data[i].Length);
					writer.Write(Encoding.ASCII.GetBytes(dao.data[i]));
				}
			} else {
				writer.Write((byte)dao.data[0].Length);
				writer.Write(Encoding.ASCII.GetBytes(dao.data[0]));
			}

			return true;
		}
	}
}
