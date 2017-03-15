using KBEngine;
using UnityEngine;
using UnityEngine.SceneManagement;
using System; 
using System.IO;  
using System.Collections; 
using System.Collections.Generic;
using System.Linq;

public class UI : MonoBehaviour 
{
	public static UI inst;
	
	public int ui_state = 0;
	private string stringAccount = "";
	private string stringPasswd = "";
	private string labelMsg = "";
	private Color labelColor = Color.green;

    // 角色体积
    private int mass = 0;
    private int level = 0;

    public bool showReliveGUI = false;
	
	void Awake() 
	 {
		inst = this;
		DontDestroyOnLoad(transform.gameObject);
	 }
	 
	// Use this for initialization
	void Start () 
	{
		installEvents();
		SceneManager.LoadScene("login");
	}

	void installEvents()
	{
		// common
		KBEngine.Event.registerOut("onKicked", this, "onKicked");
		KBEngine.Event.registerOut("onDisconnected", this, "onDisconnected");
		KBEngine.Event.registerOut("onConnectionState", this, "onConnectionState");
		
		// login
		KBEngine.Event.registerOut("onCreateAccountResult", this, "onCreateAccountResult");
		KBEngine.Event.registerOut("onLoginFailed", this, "onLoginFailed");
		KBEngine.Event.registerOut("onVersionNotMatch", this, "onVersionNotMatch");
		KBEngine.Event.registerOut("onScriptVersionNotMatch", this, "onScriptVersionNotMatch");
		KBEngine.Event.registerOut("onLoginBaseappFailed", this, "onLoginBaseappFailed");
		KBEngine.Event.registerOut("onLoginSuccessfully", this, "onLoginSuccessfully");
		KBEngine.Event.registerOut("onLoginBaseapp", this, "onLoginBaseapp");
		KBEngine.Event.registerOut("Loginapp_importClientMessages", this, "Loginapp_importClientMessages");
		KBEngine.Event.registerOut("Baseapp_importClientMessages", this, "Baseapp_importClientMessages");
		KBEngine.Event.registerOut("Baseapp_importClientEntityDef", this, "Baseapp_importClientEntityDef");

        // world
        KBEngine.Event.registerOut("set_mass", this, "set_mass");
        KBEngine.Event.registerOut("set_level", this, "set_level");
    }

	void OnDestroy()
	{
		KBEngine.Event.deregisterOut(this);
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Input.GetKeyUp(KeyCode.Space))
        {
			Debug.Log("KeyCode.Space");
        }
	}
	
	void onLoginUI()
	{
		if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 30, 200, 30), "Login(登陆)"))  
        {  
        	Debug.Log("stringAccount:" + stringAccount);
        	Debug.Log("stringPasswd:" + stringPasswd);
        	
			if(stringAccount.Length > 0 && stringPasswd.Length > 5)
			{
				login();
			}
			else
			{
				err("account or password is error, length < 6!(账号或者密码错误，长度必须大于5!)");
			}
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 70, 200, 30), "CreateAccount(注册账号)"))  
        {  
			Debug.Log("stringAccount:" + stringAccount);
			Debug.Log("stringPasswd:" + stringPasswd);

			if(stringAccount.Length > 0 && stringPasswd.Length > 5)
			{
				createAccount();
			}
			else
			{
				err("account or password is error, length < 6!(账号或者密码错误，长度必须大于5!)");
			}
        }
        
		stringAccount = GUI.TextField(new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 30), stringAccount, 20);
		stringPasswd = GUI.PasswordField(new Rect (Screen.width / 2 - 100, Screen.height / 2 - 10, 200, 30), stringPasswd, '*');
	}

	void onWorldUI()
	{
        labelMsg = "";

        if (showReliveGUI)
		{
			if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 30), "Relive(复活)"))  
			{
				KBEngine.Event.fireIn("relive", (Byte)1);		        	
			}
		}

        if (level == 1)
            GUI.Label(new Rect(0, 75, 400, 100), "Mass: " + mass + "mg");
        else if (level == 2)
            GUI.Label(new Rect(0, 75, 400, 100), "Mass: " + mass + "g");
        else if (level == 3)
            GUI.Label(new Rect(0, 75, 400, 100), "Mass: " + mass + "kg");
        else if (level == 4)
            GUI.Label(new Rect(0, 75, 400, 100), "Mass: " + mass + "t");
        else if (level >= 5)
            GUI.Label(new Rect(0, 75, 400, 100), "Mass: " + mass + "kt");
    }

    void OnGUI()  
    {  
		if(ui_state == 1)
		{
			onWorldUI();
   		}
   		else
   		{
   			onLoginUI();
   		}
   		
		if(KBEngineApp.app != null && KBEngineApp.app.serverVersion != "" 
			&& KBEngineApp.app.serverVersion != KBEngineApp.app.clientVersion)
		{
			labelColor = Color.red;
			labelMsg = "version not match(curr=" + KBEngineApp.app.clientVersion + ", srv=" + KBEngineApp.app.serverVersion + " )(版本不匹配)";
		}
		else if(KBEngineApp.app != null && KBEngineApp.app.serverScriptVersion != "" 
			&& KBEngineApp.app.serverScriptVersion != KBEngineApp.app.clientScriptVersion)
		{
			labelColor = Color.red;
			labelMsg = "scriptVersion not match(curr=" + KBEngineApp.app.clientScriptVersion + ", srv=" + KBEngineApp.app.serverScriptVersion + " )(脚本版本不匹配)";
		}
		
		GUI.contentColor = labelColor;
		GUI.Label(new Rect((Screen.width / 2) - 100, 40, 400, 100), labelMsg);

		GUI.Label(new Rect(0, 5, 400, 100), "client version: " + KBEngine.KBEngineApp.app.clientVersion);
		GUI.Label(new Rect(0, 20, 400, 100), "client script version: " + KBEngine.KBEngineApp.app.clientScriptVersion);
		GUI.Label(new Rect(0, 35, 400, 100), "server version: " + KBEngine.KBEngineApp.app.serverVersion);
		GUI.Label(new Rect(0, 50, 400, 100), "server script version: " + KBEngine.KBEngineApp.app.serverScriptVersion);
	}  
	
	public void err(string s)
	{
		labelColor = Color.red;
		labelMsg = s;
	}
	
	public void info(string s)
	{
		labelColor = Color.green;
		labelMsg = s;
	}
	
	public void login()
	{
        SceneManager.LoadScene("world");
        info("connect to server...(连接到服务端...)");
		KBEngine.Event.fireIn("login", stringAccount, stringPasswd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_balls"));
	}
	
	public void createAccount()
	{
		info("connect to server...(连接到服务端...)");
		
		KBEngine.Event.fireIn("createAccount", stringAccount, stringPasswd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_balls"));
	}
	
	public void onCreateAccountResult(UInt16 retcode, byte[] datas)
	{
		if(retcode != 0)
		{
			err("createAccount is error(注册账号错误)! err=" + KBEngineApp.app.serverErr(retcode));
			return;
		}
		
		if(KBEngineApp.validEmail(stringAccount))
		{
			info("createAccount is successfully, Please activate your Email!(注册账号成功，请激活Email!)");
		}
		else
		{
			info("createAccount is successfully!(注册账号成功!)");
		}
	}
	
	public void onConnectionState(bool success)
	{
		if(!success)
			err("connect(" + KBEngineApp.app.getInitArgs().ip + ":" + KBEngineApp.app.getInitArgs().port + ") is error! (连接错误)");
		else
			info("connect successfully, please wait...(连接成功，请等候...)");
	}
	
	public void onLoginFailed(UInt16 failedcode)
	{
		if(failedcode == 20)
		{
			err("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode) + ", " + System.Text.Encoding.ASCII.GetString(KBEngineApp.app.serverdatas()));
		}
		else
		{
			err("login is failed(登陆失败), err=" + KBEngineApp.app.serverErr(failedcode));
		}
	}
	
	public void onVersionNotMatch(string verInfo, string serVerInfo)
	{
		err("");
	}

	public void onScriptVersionNotMatch(string verInfo, string serVerInfo)
	{
		err("");
	}
	
	public void onLoginBaseappFailed(UInt16 failedcode)
	{
		err("loginBaseapp is failed(登陆网关失败), err=" + KBEngineApp.app.serverErr(failedcode));
	}
	
	public void onLoginBaseapp()
	{
		info("connect to loginBaseapp, please wait...(连接到网关， 请稍后...)");
	}

	public void onLoginSuccessfully(UInt64 rndUUID, Int32 eid, KBEngine.Avatar accountEntity)
	{
		info("login is successfully!(登陆成功!)");
		ui_state = 1;
	}

	public void onKicked(UInt16 failedcode)
	{
		err("kick, disconnect!, reason=" + KBEngineApp.app.serverErr(failedcode));
		SceneManager.LoadScene("login");
		ui_state = 0;
	}

	public void Loginapp_importClientMessages()
	{
		info("Loginapp_importClientMessages ...");
	}

	public void Baseapp_importClientMessages()
	{
		info("Baseapp_importClientMessages ...");
	}
	
	public void Baseapp_importClientEntityDef()
	{
		info("importClientEntityDef ...");
	}
	
	public void onDisconnected()
	{
        SceneManager.LoadScene("login");
        ui_state = 0;
    }

    public void set_level(KBEngine.Entity entity, object v)
    {
        level = (Byte)v;
    }

    public void set_mass(KBEngine.Entity entity, object v)
    {
        mass = (int)v;
    }
}
