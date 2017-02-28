# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *
from interfaces.EntityCommon import EntityCommon

TIMER_TYPE_ADD_TRAP = 1

class Smash(KBEngine.Entity, EntityCommon):
	def __init__(self):
		KBEngine.Entity.__init__(self)
		EntityCommon.__init__(self)

		self.addTimer(0.1, 0, TIMER_TYPE_ADD_TRAP)

	def isSmash(self):
		"""
		virtual method.
		"""
		return True
		
	#--------------------------------------------------------------------------------------------
	#                              Callbacks
	#--------------------------------------------------------------------------------------------
	def onTimer(self, tid, userArg):
		"""
		KBEngine method.
		引擎回调timer触发
		"""
		#DEBUG_MSG("%s::onTimer: %i, tid:%i, arg:%i" % (self.className, self.id, tid, userArg))
		if TIMER_TYPE_ADD_TRAP == userArg:
			self.addProximity(self.modelRadius, 0, 0)
		
		EntityCommon.onTimer(self, tid, userArg)

	def onEnterTrap(self, entityEntering, range_xz, range_y, controllerID, userarg):
		"""
		KBEngine method.
		有entity进入trap
		"""
		# 只有玩家实体进入，陷阱才工作
		if entityEntering.isDestroyed or not entityEntering.isAvatar():
			return
			
		DEBUG_MSG("%s::onEnterTrap: %i entityEntering=(%s)%i, range_xz=%s, range_y=%s, controllerID=%i, userarg=%i" % \
						(self.className, self.id, entityEntering.className, entityEntering.id, \
						range_xz, range_y, controllerID, userarg))
		
		# 有玩家进入范围，销毁自己同时粉碎玩家(假设玩家体积在粉碎范围)
		self.destroy()

	def onLeaveTrap(self, entityLeaving, range_xz, range_y, controllerID, userarg):
		"""
		KBEngine method.
		有entity离开trap
		"""
		if entityLeaving.isDestroyed or entityLeaving.className != "Avatar":
			return
			
		INFO_MSG("%s::onLeaveTrap: %i entityLeaving=(%s)%i." % (self.className, self.id, \
				entityLeaving.className, entityLeaving.id))

	def onDestroy(self):
		"""
		entity销毁
		"""
		room = self.getCurrRoom()
		
		if room == None:
			return
			
		room.onFoodSmash(self.id)
