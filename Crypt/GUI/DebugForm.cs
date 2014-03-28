using System;
using System.Collections.Generic;
using System.Text;

namespace L2REditor.Engine.GUI {
	public interface DebugForm {
		void write(string text);
		void show();
		void focus();
		void hide();
		bool isVisible();
	}
}
