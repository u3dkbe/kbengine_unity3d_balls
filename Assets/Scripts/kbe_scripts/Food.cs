namespace KBEngine
{
    using UnityEngine;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Food : FoodBase
    {
        public Food()
        {
        }

        public override void onModelIDChanged(Byte old)
        {
            // Dbg.DEBUG_MSG(className + "::set_modelID: " + old + " => " + v); 
            Event.fireOut("set_modelID", new object[] { this, this.modelID });
        }
    }

}
