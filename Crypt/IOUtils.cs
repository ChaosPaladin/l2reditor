using System.IO;

namespace L2REditor.Engine {
	public static class IOUtils {
		public static string getTempFile() {
			var file = Path.GetRandomFileName();
			file = Path.Combine(Path.GetTempPath(), file);
			return file;
		}
	}
}
