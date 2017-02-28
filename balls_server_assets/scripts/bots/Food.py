# -*- coding: utf-8 -*-
import KBEngine
import KBExtra
from KBEDebug import *
from interfaces.EntityCommon import EntityCommon

class Food(KBEngine.Entity, EntityCommon):
	def __init__(self):
		KBEngine.Entity.__init__(self)
		EntityCommon.__init__(self)
