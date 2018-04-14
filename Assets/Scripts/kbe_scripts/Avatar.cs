namespace KBEngine
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Avatar : AvatarBase
    {
        public Avatar()
        {
        }

        public override void __init__()
        {
            if (isPlayer())
            {
                Event.registerIn("relive", this, "relive");
                Event.registerIn("updatePlayer", this, "updatePlayer");

                // 触发登陆成功事件
                Event.fireOut("onLoginSuccessfully", new object[] { KBEngineApp.app.entity_uuid, id, this });
            }
        }

        public override void onDestroy()
        {
            if (isPlayer())
            {
                KBEngine.Event.deregisterIn(this);
            }
        }

        public override void onEnterWorld()
        {
            base.onEnterWorld();

            if (isPlayer())
            {
                Event.fireOut("onAvatarEnterWorld", new object[] { KBEngineApp.app.entity_uuid, id, this });
            }
        }

        public void relive(Byte type)
        {
            cellCall("relive", type);
        }

        public virtual void updatePlayer(float x, float y, float z, float yaw)
        {
            position.x = x;
            position.y = y;
            position.z = z;

            direction.z = yaw;
        }

        public override void onModelIDChanged(Byte old)
        {
            // Dbg.DEBUG_MSG(className + "::set_modelID: " + old + " => " + v); 
            Event.fireOut("set_modelID", new object[] { this, this.modelID });
        }

        public override void onNameChanged(string old)
        {
            // Dbg.DEBUG_MSG(className + "::set_name: " + old + " => " + v); 
            Event.fireOut("set_name", new object[] { this, this.name });
        }

        public override void onMassChanged(Int32 old)
        {
            // Dbg.DEBUG_MSG(className + "::set_mass: " + old + " => " + v); 
            Event.fireOut("set_mass", new object[] { this, this.mass });
        }

        public override void onLevelChanged(Byte old)
        {
            // Dbg.DEBUG_MSG(className + "::set_level: " + old + " => " + v); 
            Event.fireOut("set_level", new object[] { this, this.level });
        }

        public override void onMoveSpeedChanged(float old)
        {
            // Dbg.DEBUG_MSG(className + "::set_moveSpeed: " + old + " => " + v); 
            Event.fireOut("set_moveSpeed", new object[] { this, this.moveSpeed });
        }

        public override void onModelScaleChanged(float old)
        {
            // Dbg.DEBUG_MSG(className + "::set_modelScale: " + old + " => " + v); 
            Event.fireOut("set_modelScale", new object[] { this, this.modelScale });
        }
    }
}
