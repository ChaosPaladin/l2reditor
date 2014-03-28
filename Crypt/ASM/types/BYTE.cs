using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace L2REditor.Engine.ASM.types {
	public class BYTE : DefaultASMType {
		public BYTE(string name, bool isArray) : base(name, isArray) {
		}

		public override ASMData readData(BinaryReader reader) {
			throw new NotImplementedException();
		}

		public override bool writeData(ASMData dao, BinaryWriter writer) {
			throw new NotImplementedException();
		}
	}
}
