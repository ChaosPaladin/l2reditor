using System.IO;

namespace L2REditor.Engine.ASM {
	public abstract class DefaultASMType { //columns encode/decode impl
		public bool isArray { get; set; }

		//to override
		public abstract ASMData readData(BinaryReader reader);

		public abstract bool writeData(ASMData dao, BinaryWriter writer);
	}
}
