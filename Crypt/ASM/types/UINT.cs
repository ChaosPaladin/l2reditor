using System;
using System.IO;

namespace L2REditor.Engine.ASM.types {
	public class UINT : DefaultASMType {

		public override ASMData readData(BinaryReader reader) {
			var dao = new ASMData(this);
			if (isArray) {
				uint count = reader.ReadUInt32();
				dao.data = new string[count];
				for (int i = 0; i < count; i++)
					dao.data[i] = reader.ReadUInt32().ToString();
			} else
				dao.data = new[] { reader.ReadUInt32().ToString() };
			return dao;
		}

		public override bool writeData(ASMData dao, BinaryWriter writer) {
			if (isArray) {
				writer.Write(Convert.ToUInt32(dao.data.Length));
				for(int i = 0; i < dao.data.Length; i++)
					writer.Write(uint.Parse(dao.data[i]));
			} else {
				var d = uint.Parse(dao.data[0]);
				writer.Write(d);
			}
			return true;
		}
	}
}
