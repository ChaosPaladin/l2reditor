namespace L2REditor.Engine.Crypt {
	public class CVersion {
		public enum EVersion {
			C3,
			C4,
			C5,
			Interlude,
			CT10,
			CT15,
			CT21,
			CT22en,
			CT22ru,
			CT23en,
			CT23kr,
			CT23ru,
			CT24en,
			CT24ru,
			CT25en,
			CT26en,
			CT31,
			CT32,
			CT33,
			NONE
		}

		public static EVersion getVersionFromText(string text) {
			switch (text) {
				case "C3":
					return EVersion.C3;
				case "C4":
					return EVersion.C4;
				case "C5":
					return EVersion.C5;
				case "Interlude":
					return EVersion.Interlude;
				case "CT 1.0":
					return EVersion.CT10;
				case "CT 1.5":
					return EVersion.CT15;
				case "CT 2.1":
					return EVersion.CT21;
				case "CT 2.2":
					return EVersion.CT22en;
				case "CT 2.2 RU":
					return EVersion.CT22ru;
				case "CT 2.3 EN":
					return EVersion.CT23en;
				case "CT 2.3 KR":
					return EVersion.CT23kr;
				case "CT 2.3 RU":
					return EVersion.CT23ru;
				case "CT 2.4 EN":
					return EVersion.CT24en;
				case "CT 2.4 RU":
					return EVersion.CT24ru;
				case "CT 2.5 EN":
					return EVersion.CT25en;
				case "CT 2.6 EN":
					return EVersion.CT26en;
				case "CT 3.1 EN":
					return EVersion.CT31;
				case "CT 3.2 EN":
					return EVersion.CT32;
				case "CT 3.3 EN":
					return EVersion.CT33;
			}
			return EVersion.NONE;
		}

		public static string getFolder(EVersion ver) {
			switch (ver) {
				case EVersion.C3:
					return "C3";
				case EVersion.C4:
					return "C4";
				case EVersion.C5:
					return "C5";
				case EVersion.Interlude:
					return "Interlude";
				case EVersion.CT10:
					return "CT1_0";
				case EVersion.CT15:
					return "CT1_5";
				case EVersion.CT21:
					return "CT2_1";
				case EVersion.CT22en:
					return "CT2_2";
				case EVersion.CT22ru:
					return "CT2_2ru";
				case EVersion.CT23en:
					return "CT2_3en";
				case EVersion.CT23kr:
					return "CT2_3kr";
				case EVersion.CT23ru:
					return "CT2_3ru";
				case EVersion.CT24en:
					return "CT2_4en";
				case EVersion.CT24ru:
					return "CT2_4ru";
				case EVersion.CT25en:
					return "CT2_5en";
				case EVersion.CT26en:
					return "H5";
				case EVersion.CT31:
					return "GOD";
				case EVersion.CT32:
					return "Harmony";
				case EVersion.CT33:
					return "Tauti";
			}
			return null;
		}

		public static string getName(EVersion ver) {
			switch (ver) {
				case EVersion.C3:
					return "C3";
				case EVersion.C4:
					return "C4";
				case EVersion.C5:
					return "C5";
				case EVersion.Interlude:
					return "Interlude";
				case EVersion.CT10:
					return "CT 1.0";
				case EVersion.CT15:
					return "CT 1.5";
				case EVersion.CT21:
					return "CT 2.1";
				case EVersion.CT22en:
					return "CT 2.2";
				case EVersion.CT22ru:
					return "CT 2.2 RU";
				case EVersion.CT23en:
					return "CT 2.3 EN";
				case EVersion.CT23kr:
					return "CT 2.3 KR";
				case EVersion.CT23ru:
					return "CT 2.3 RU";
				case EVersion.CT24en:
					return "CT 2.4 EN";
				case EVersion.CT24ru:
					return "CT 2.4 RU";
				case EVersion.CT25en:
					return "CT 2.5 EN";
				case EVersion.CT26en:
					return "CT 2.6 EN";
				case EVersion.CT31:
					return "CT 3.1 EN";
				case EVersion.CT32:
					return "CT 3.2 EN";
				case EVersion.CT33:
					return "CT 3.3 EN";
				default:
					return "NONE";
			}
		}
	}
}
