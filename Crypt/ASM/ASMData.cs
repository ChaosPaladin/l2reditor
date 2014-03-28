namespace L2REditor.Engine.ASM {
	public class ASMData {
		public DefaultASMType type { get; private set; }
		public string[] data { get; set; }

		public ASMData(DefaultASMType type) {
			this.type = type;
		}
	}
}
