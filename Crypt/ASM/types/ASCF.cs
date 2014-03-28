using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace L2REditor.Engine.ASM.types {
	public class ASCF : DefaultASMType {
		public override ASMData readData(BinaryReader reader) {
			var dao = new ASMData(this);
			if (isArray) {
				uint count = reader.ReadUInt32();
				dao.data = new string[count];
				for (int i = 0; i < count; i++) {
					var strLen = reader.ReadByte();
					if (!(dao.meta = reader.ReadByte() == 0x01))
						reader.BaseStream.Seek(-1, SeekOrigin.Current);
					var bin = reader.ReadBytes(strLen);
					dao.data[i] = Encoding.ASCII.GetString(bin);
				}
			} else {
				var strLen = reader.ReadByte(); //max 255 inc null terminate

				//i dont know why then this byte
				//if we read that byte in str... we dont have null-terminate byte
				if (!(dao.meta = reader.ReadByte() == 0x01)) //really stupid...
					reader.BaseStream.Seek(-1, SeekOrigin.Current);
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
					if (dao.meta)
						writer.Write((byte)0x01);
					writer.Write(Encoding.ASCII.GetBytes(dao.data[i]));
				}
			} else {
				writer.Write((byte)dao.data[0].Length);
				if(dao.meta)
					writer.Write((byte)0x01);
				writer.Write(Encoding.ASCII.GetBytes(dao.data[0]));
			}

			return true;
		}
	}
}
