using System;
using System.IO;
using System.Text;

namespace L2REditor.Engine.ASM.types {
	public class UNICODE : DefaultASMType {
		public override ASMData readData(BinaryReader reader) {
			var dao = new ASMData(this);
			if (isArray) {
				uint count = reader.ReadUInt32();
				dao.data = new string[count];
				for (int i = 0; i < count; i++) {
					var strLen = reader.ReadUInt32();
					dao.data[i] = Encoding.Unicode.GetString(reader.ReadBytes((int) strLen));
				}
			} else {
				var strLen = reader.ReadUInt32();
				dao.data = new [] { Encoding.Unicode.GetString(reader.ReadBytes((int) strLen)) };
			}

			return dao;
		}

		public override bool writeData(ASMData dao, BinaryWriter writer) {
			if (isArray) {
				writer.Write(Convert.ToUInt32(dao.data.Length));
				for (int i = 0; i < dao.data.Length; i++) {
					writer.Write(Convert.ToUInt32(dao.data[i].Length * 2));
					writer.Write(Encoding.Unicode.GetBytes(dao.data[i]));
				}
			} else {
				writer.Write(Convert.ToUInt32(dao.data[0].Length * 2));
				writer.Write(Encoding.Unicode.GetBytes(dao.data[0]));
			}

			return true;
		}
	}
}
