/*
	Generated by KBEngine!
	Please do not modify this file!
	tools = kbcmd
*/

namespace KBEngine
{
	using UnityEngine;
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public class EntityDef
	{
		public static Dictionary<string, UInt16> datatype2id = new Dictionary<string, UInt16>();
		public static Dictionary<string, DATATYPE_BASE> datatypes = new Dictionary<string, DATATYPE_BASE>();
		public static Dictionary<UInt16, DATATYPE_BASE> id2datatypes = new Dictionary<UInt16, DATATYPE_BASE>();
		public static Dictionary<string, Int32> entityclass = new Dictionary<string, Int32>();
		public static Dictionary<string, ScriptModule> moduledefs = new Dictionary<string, ScriptModule>();
		public static Dictionary<UInt16, ScriptModule> idmoduledefs = new Dictionary<UInt16, ScriptModule>();

		public static bool init()
		{
			initDataTypes();
			initDefTypes();
			initScriptModules();
			return true;
		}

		public static bool reset()
		{
			clear();
			return init();
		}

		public static void clear()
		{
			datatype2id.Clear();
			datatypes.Clear();
			id2datatypes.Clear();
			entityclass.Clear();
			moduledefs.Clear();
			idmoduledefs.Clear();
		}

		public static void initDataTypes()
		{
			datatypes["UINT8"] = new DATATYPE_UINT8();
			datatypes["UINT16"] = new DATATYPE_UINT16();
			datatypes["UINT32"] = new DATATYPE_UINT32();
			datatypes["UINT64"] = new DATATYPE_UINT64();

			datatypes["INT8"] = new DATATYPE_INT8();
			datatypes["INT16"] = new DATATYPE_INT16();
			datatypes["INT32"] = new DATATYPE_INT32();
			datatypes["INT64"] = new DATATYPE_INT64();

			datatypes["FLOAT"] = new DATATYPE_FLOAT();
			datatypes["DOUBLE"] = new DATATYPE_DOUBLE();

			datatypes["STRING"] = new DATATYPE_STRING();
			datatypes["VECTOR2"] = new DATATYPE_VECTOR2();

			datatypes["VECTOR3"] = new DATATYPE_VECTOR3();

			datatypes["VECTOR4"] = new DATATYPE_VECTOR4();
			datatypes["PYTHON"] = new DATATYPE_PYTHON();

			datatypes["UNICODE"] = new DATATYPE_UNICODE();
			datatypes["ENTITYCALL"] = new DATATYPE_ENTITYCALL();

			datatypes["BLOB"] = new DATATYPE_BLOB();
		}

		public static void initScriptModules()
		{
			ScriptModule pAvatarModule = new ScriptModule("Avatar");
			EntityDef.moduledefs["Avatar"] = pAvatarModule;
			EntityDef.idmoduledefs[1] = pAvatarModule;

			Property pAvatar_position = new Property();
			pAvatar_position.name = "position";
			pAvatar_position.properUtype = 40000;
			pAvatar_position.properFlags = 4;
			pAvatar_position.aliasID = 1;
			Vector3 Avatar_position_defval = new Vector3();
			pAvatar_position.defaultVal = Avatar_position_defval;
			pAvatarModule.propertys["position"] = pAvatar_position; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_position.aliasID] = pAvatar_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(position / 40000).");

			Property pAvatar_direction = new Property();
			pAvatar_direction.name = "direction";
			pAvatar_direction.properUtype = 40001;
			pAvatar_direction.properFlags = 4;
			pAvatar_direction.aliasID = 2;
			Vector3 Avatar_direction_defval = new Vector3();
			pAvatar_direction.defaultVal = Avatar_direction_defval;
			pAvatarModule.propertys["direction"] = pAvatar_direction; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_direction.aliasID] = pAvatar_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(direction / 40001).");

			Property pAvatar_spaceID = new Property();
			pAvatar_spaceID.name = "spaceID";
			pAvatar_spaceID.properUtype = 40002;
			pAvatar_spaceID.properFlags = 16;
			pAvatar_spaceID.aliasID = 3;
			UInt32 Avatar_spaceID_defval;
			UInt32.TryParse("", out Avatar_spaceID_defval);
			pAvatar_spaceID.defaultVal = Avatar_spaceID_defval;
			pAvatarModule.propertys["spaceID"] = pAvatar_spaceID; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_spaceID.aliasID] = pAvatar_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(spaceID / 40002).");

			Property pAvatar_level = new Property();
			pAvatar_level.name = "level";
			pAvatar_level.properUtype = 5;
			pAvatar_level.properFlags = 16;
			pAvatar_level.aliasID = 4;
			Byte Avatar_level_defval;
			Byte.TryParse("1", out Avatar_level_defval);
			pAvatar_level.defaultVal = Avatar_level_defval;
			pAvatarModule.propertys["level"] = pAvatar_level; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_level.aliasID] = pAvatar_level;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(level / 5).");

			Property pAvatar_mass = new Property();
			pAvatar_mass.name = "mass";
			pAvatar_mass.properUtype = 4;
			pAvatar_mass.properFlags = 16;
			pAvatar_mass.aliasID = 5;
			Int32 Avatar_mass_defval;
			Int32.TryParse("10", out Avatar_mass_defval);
			pAvatar_mass.defaultVal = Avatar_mass_defval;
			pAvatarModule.propertys["mass"] = pAvatar_mass; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_mass.aliasID] = pAvatar_mass;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(mass / 4).");

			Property pAvatar_modelID = new Property();
			pAvatar_modelID.name = "modelID";
			pAvatar_modelID.properUtype = 9;
			pAvatar_modelID.properFlags = 4;
			pAvatar_modelID.aliasID = 6;
			Byte Avatar_modelID_defval;
			Byte.TryParse("0", out Avatar_modelID_defval);
			pAvatar_modelID.defaultVal = Avatar_modelID_defval;
			pAvatarModule.propertys["modelID"] = pAvatar_modelID; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_modelID.aliasID] = pAvatar_modelID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(modelID / 9).");

			Property pAvatar_modelScale = new Property();
			pAvatar_modelScale.name = "modelScale";
			pAvatar_modelScale.properUtype = 7;
			pAvatar_modelScale.properFlags = 4;
			pAvatar_modelScale.aliasID = 7;
			float Avatar_modelScale_defval;
			float.TryParse("0.3", out Avatar_modelScale_defval);
			pAvatar_modelScale.defaultVal = Avatar_modelScale_defval;
			pAvatarModule.propertys["modelScale"] = pAvatar_modelScale; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_modelScale.aliasID] = pAvatar_modelScale;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(modelScale / 7).");

			Property pAvatar_moveSpeed = new Property();
			pAvatar_moveSpeed.name = "moveSpeed";
			pAvatar_moveSpeed.properUtype = 6;
			pAvatar_moveSpeed.properFlags = 4;
			pAvatar_moveSpeed.aliasID = 8;
			float Avatar_moveSpeed_defval;
			float.TryParse("6.5", out Avatar_moveSpeed_defval);
			pAvatar_moveSpeed.defaultVal = Avatar_moveSpeed_defval;
			pAvatarModule.propertys["moveSpeed"] = pAvatar_moveSpeed; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_moveSpeed.aliasID] = pAvatar_moveSpeed;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(moveSpeed / 6).");

			Property pAvatar_name = new Property();
			pAvatar_name.name = "name";
			pAvatar_name.properUtype = 2;
			pAvatar_name.properFlags = 4;
			pAvatar_name.aliasID = 9;
			string Avatar_name_defval = "";
			pAvatar_name.defaultVal = Avatar_name_defval;
			pAvatarModule.propertys["name"] = pAvatar_name; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_name.aliasID] = pAvatar_name;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(name / 2).");

			Property pAvatar_state = new Property();
			pAvatar_state.name = "state";
			pAvatar_state.properUtype = 8;
			pAvatar_state.properFlags = 4;
			pAvatar_state.aliasID = 10;
			SByte Avatar_state_defval;
			SByte.TryParse("0", out Avatar_state_defval);
			pAvatar_state.defaultVal = Avatar_state_defval;
			pAvatarModule.propertys["state"] = pAvatar_state; 

			pAvatarModule.usePropertyDescrAlias = true;
			pAvatarModule.idpropertys[(UInt16)pAvatar_state.aliasID] = pAvatar_state;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Avatar), property(state / 8).");

			ScriptModule pFoodModule = new ScriptModule("Food");
			EntityDef.moduledefs["Food"] = pFoodModule;
			EntityDef.idmoduledefs[4] = pFoodModule;

			Property pFood_position = new Property();
			pFood_position.name = "position";
			pFood_position.properUtype = 40000;
			pFood_position.properFlags = 4;
			pFood_position.aliasID = 1;
			Vector3 Food_position_defval = new Vector3();
			pFood_position.defaultVal = Food_position_defval;
			pFoodModule.propertys["position"] = pFood_position; 

			pFoodModule.usePropertyDescrAlias = true;
			pFoodModule.idpropertys[(UInt16)pFood_position.aliasID] = pFood_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Food), property(position / 40000).");

			Property pFood_direction = new Property();
			pFood_direction.name = "direction";
			pFood_direction.properUtype = 40001;
			pFood_direction.properFlags = 4;
			pFood_direction.aliasID = 2;
			Vector3 Food_direction_defval = new Vector3();
			pFood_direction.defaultVal = Food_direction_defval;
			pFoodModule.propertys["direction"] = pFood_direction; 

			pFoodModule.usePropertyDescrAlias = true;
			pFoodModule.idpropertys[(UInt16)pFood_direction.aliasID] = pFood_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Food), property(direction / 40001).");

			Property pFood_spaceID = new Property();
			pFood_spaceID.name = "spaceID";
			pFood_spaceID.properUtype = 40002;
			pFood_spaceID.properFlags = 16;
			pFood_spaceID.aliasID = 3;
			UInt32 Food_spaceID_defval;
			UInt32.TryParse("", out Food_spaceID_defval);
			pFood_spaceID.defaultVal = Food_spaceID_defval;
			pFoodModule.propertys["spaceID"] = pFood_spaceID; 

			pFoodModule.usePropertyDescrAlias = true;
			pFoodModule.idpropertys[(UInt16)pFood_spaceID.aliasID] = pFood_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Food), property(spaceID / 40002).");

			Property pFood_modelID = new Property();
			pFood_modelID.name = "modelID";
			pFood_modelID.properUtype = 14;
			pFood_modelID.properFlags = 4;
			pFood_modelID.aliasID = 4;
			Byte Food_modelID_defval;
			Byte.TryParse("0", out Food_modelID_defval);
			pFood_modelID.defaultVal = Food_modelID_defval;
			pFoodModule.propertys["modelID"] = pFood_modelID; 

			pFoodModule.usePropertyDescrAlias = true;
			pFoodModule.idpropertys[(UInt16)pFood_modelID.aliasID] = pFood_modelID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Food), property(modelID / 14).");

			ScriptModule pSmashModule = new ScriptModule("Smash");
			EntityDef.moduledefs["Smash"] = pSmashModule;
			EntityDef.idmoduledefs[5] = pSmashModule;

			Property pSmash_position = new Property();
			pSmash_position.name = "position";
			pSmash_position.properUtype = 40000;
			pSmash_position.properFlags = 4;
			pSmash_position.aliasID = 1;
			Vector3 Smash_position_defval = new Vector3();
			pSmash_position.defaultVal = Smash_position_defval;
			pSmashModule.propertys["position"] = pSmash_position; 

			pSmashModule.usePropertyDescrAlias = true;
			pSmashModule.idpropertys[(UInt16)pSmash_position.aliasID] = pSmash_position;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Smash), property(position / 40000).");

			Property pSmash_direction = new Property();
			pSmash_direction.name = "direction";
			pSmash_direction.properUtype = 40001;
			pSmash_direction.properFlags = 4;
			pSmash_direction.aliasID = 2;
			Vector3 Smash_direction_defval = new Vector3();
			pSmash_direction.defaultVal = Smash_direction_defval;
			pSmashModule.propertys["direction"] = pSmash_direction; 

			pSmashModule.usePropertyDescrAlias = true;
			pSmashModule.idpropertys[(UInt16)pSmash_direction.aliasID] = pSmash_direction;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Smash), property(direction / 40001).");

			Property pSmash_spaceID = new Property();
			pSmash_spaceID.name = "spaceID";
			pSmash_spaceID.properUtype = 40002;
			pSmash_spaceID.properFlags = 16;
			pSmash_spaceID.aliasID = 3;
			UInt32 Smash_spaceID_defval;
			UInt32.TryParse("", out Smash_spaceID_defval);
			pSmash_spaceID.defaultVal = Smash_spaceID_defval;
			pSmashModule.propertys["spaceID"] = pSmash_spaceID; 

			pSmashModule.usePropertyDescrAlias = true;
			pSmashModule.idpropertys[(UInt16)pSmash_spaceID.aliasID] = pSmash_spaceID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Smash), property(spaceID / 40002).");

			Property pSmash_modelID = new Property();
			pSmash_modelID.name = "modelID";
			pSmash_modelID.properUtype = 17;
			pSmash_modelID.properFlags = 4;
			pSmash_modelID.aliasID = 4;
			Byte Smash_modelID_defval;
			Byte.TryParse("0", out Smash_modelID_defval);
			pSmash_modelID.defaultVal = Smash_modelID_defval;
			pSmashModule.propertys["modelID"] = pSmash_modelID; 

			pSmashModule.usePropertyDescrAlias = true;
			pSmashModule.idpropertys[(UInt16)pSmash_modelID.aliasID] = pSmash_modelID;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Smash), property(modelID / 17).");

			Property pSmash_modelScale = new Property();
			pSmash_modelScale.name = "modelScale";
			pSmash_modelScale.properUtype = 16;
			pSmash_modelScale.properFlags = 4;
			pSmash_modelScale.aliasID = 5;
			float Smash_modelScale_defval;
			float.TryParse("1.0", out Smash_modelScale_defval);
			pSmash_modelScale.defaultVal = Smash_modelScale_defval;
			pSmashModule.propertys["modelScale"] = pSmash_modelScale; 

			pSmashModule.usePropertyDescrAlias = true;
			pSmashModule.idpropertys[(UInt16)pSmash_modelScale.aliasID] = pSmash_modelScale;

			//Dbg.DEBUG_MSG("EntityDef::initScriptModules: add(Smash), property(modelScale / 16).");

		}

		public static void initDefTypes()
		{
			{
				UInt16 utype = 2;
				string typeName = "BOOL";
				string name = "UINT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 3;
				string typeName = "UINT16";
				string name = "UINT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 5;
				string typeName = "SPACE_KEY";
				string name = "UINT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 4;
				string typeName = "SPACE_ID";
				string name = "UINT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 6;
				string typeName = "INT8";
				string name = "INT8";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 7;
				string typeName = "INT16";
				string name = "INT16";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 8;
				string typeName = "ENTITY_ID";
				string name = "INT32";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 9;
				string typeName = "INT64";
				string name = "INT64";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 1;
				string typeName = "STRING";
				string name = "STRING";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 12;
				string typeName = "UNICODE";
				string name = "UNICODE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 13;
				string typeName = "FLOAT";
				string name = "FLOAT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 14;
				string typeName = "DOUBLE";
				string name = "DOUBLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PYTHON";
				string name = "PYTHON";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_DICT";
				string name = "PY_DICT";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_TUPLE";
				string name = "PY_TUPLE";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "PY_LIST";
				string name = "PY_LIST";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 10;
				string typeName = "ENTITYCALL";
				string name = "ENTITYCALL";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 11;
				string typeName = "BLOB";
				string name = "BLOB";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 15;
				string typeName = "VECTOR2";
				string name = "VECTOR2";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 16;
				string typeName = "DIRECTION3D";
				string name = "VECTOR3";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			{
				UInt16 utype = 17;
				string typeName = "VECTOR4";
				string name = "VECTOR4";
				DATATYPE_BASE val = null;
				EntityDef.datatypes.TryGetValue(name, out val);
				EntityDef.datatypes[typeName] = val;
				EntityDef.id2datatypes[utype] = EntityDef.datatypes[typeName];
				EntityDef.datatype2id[typeName] = utype;
			}

			foreach(string datatypeStr in EntityDef.datatypes.Keys)
			{
				DATATYPE_BASE dataType = EntityDef.datatypes[datatypeStr];
				if(dataType != null)
				{
					dataType.bind();
				}
			}
		}

	}


}