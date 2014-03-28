using L2REditor.Engine.ASM.types;

namespace L2REditor.Engine.ASM.clients {
	public class Interlude {
		public class actionname : DefaultASMFile {
			public actionname() {
				types = new DefaultASMType[] {
					new UINT("tag", false),
					new UINT("id", false),
					new INT("type", false),
					new UINT("category", false),
					new INT("categoryes", true),   
					new AutoASCF("cmd", false), 
					new AutoASCF("icon", false),
					new AutoASCF("name", false),
					new UNICODE("description", false)   
				};
				//base.header = 
			}
		}

		public class armorgrp : DefaultASMFile {
			public armorgrp() {
				types = new DefaultASMType[] {
					new UINT("tag", false),
					new UINT("id", false),
					new UINT("drop_type", false),
					new UINT("drop_anim_type", false),
					new UINT("drop_radius", true),   
					new UINT("drop_height", false), 
					new UINT("unknown", false),
					new UNICODE("drop_mesh1", false),
					new UNICODE("drop_mesh2", false),
					new UNICODE("drop_mesh3", false),
					new UNICODE("drop_tex1", false),
					new UNICODE("drop_tex2", false),
					new UNICODE("drop_tex3", false),

					new UNICODE("icon1", false),
					new UNICODE("icon2", false),
					new UNICODE("icon3", false),
					new UNICODE("icon4", false),
					new UNICODE("icon5", false),

					new UINT("durability", false), 
					new UINT("weight", false), 
					new UINT("material", false), 
					new UINT("crystallizable", false), 
					new UINT("unknown", false), 
					new UINT("body_part", false), 

					new UNICODE("m_HumnFigh", true),
					new UNICODE("f_HumnFigh", true),
					new UNICODE("m_DarkElf", true),
					new UNICODE("f_DarkElf", true),
					new UNICODE("m_Dworf", true),
					new UNICODE("f_Dworf", true),
					new UNICODE("m_Elf", true),
					new UNICODE("f_Elf", true),
					new UNICODE("m_HumnMyst", true),
					new UNICODE("f_HumnMyst", true),
					new UNICODE("m_OrcFigh", true),
					new UNICODE("f_OrcFigh", true),
					new UNICODE("m_OrcMage", true),
					new UNICODE("f_OrcMage", true),
					new UNICODE("unused race", true),
					new UNICODE("NPC_MT", true),
					new UNICODE("ACC_MT", true),

					new UNICODE("att_eff", false),
					new UNICODE("item_sound", true),
					new UNICODE("drop_sound", false),
					new UNICODE("equip_sound", false),

					new UINT("unknown", false), 
					new UINT("unknown", false), 

					new UINT("armor_type", false), 
					new UINT("crystal_type", false), 
					new UINT("avoid_mod", false), 
					new UINT("pdef", false), 
					new UINT("mdef", false), 
					new UINT("mpbonus", false)
				};
				header = 0x0000040A;
			}
		}
	}
}
