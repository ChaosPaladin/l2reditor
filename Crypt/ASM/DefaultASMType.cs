using System.IO;

namespace L2REditor.Engine.ASM {
	public abstract class DefaultASMType { //columns encode/decode impl
		public bool isArray { get; protected set; }
		public string name { get; protected set; }

		protected DefaultASMType(string name, bool isArray) {
			this.isArray = isArray;
			this.name = name;
		}

		//to override
		public abstract ASMData readData(BinaryReader reader);

		public abstract bool writeData(ASMData dao, BinaryWriter writer);
	}
}
