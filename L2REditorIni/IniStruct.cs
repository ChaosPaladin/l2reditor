using System;
using System.Collections.Generic;
using System.Text;

namespace L2REditorIni {
	class IniStruct {
		private List<Section> sections = new List<Section>();
		private Section lastSection;
		public IniStruct() {
			
		}

		public void addSection(string sectionName, bool sectionCommented) {
			sections.Add(lastSection = new Section {name = sectionName, commented = sectionCommented});
		}

		public void addElement(string elementName, string elementValue, bool elementCommented) {
			var element = new Element {section = lastSection, name = elementName, value = elementValue, commented = elementCommented};
			lastSection.elements.Add(element);
		}

		public List<Section> getSections() {
			return sections;
		} 

		public class Section {
			public string name;
			public bool commented;
			public List<Element> elements = new List<Element>();
		}

		public class Element {
			public Section section;
			public string name;
			public string value;
			public bool commented;
		}
	}
}
