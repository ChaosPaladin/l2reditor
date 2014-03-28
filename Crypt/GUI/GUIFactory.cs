using System;
using System.Collections.Generic;
using System.Text;

namespace L2REditor.Engine.GUI {
	public class GUIFactory {
		public static DebugForm createDebugForm() {
			return new Debugf();
		}

		public static LoadingCircle createLoadingCircle() {
			return new LoadingCircle();
		}
	}
}
