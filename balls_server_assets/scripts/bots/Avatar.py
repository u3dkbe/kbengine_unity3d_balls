# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *
import GameConfigs
from interfaces.EntityCommon import EntityCommon

class Avatar(KBEngine.Entity, EntityCommon):
	def __init__(self):
		KBEngine.Entity.__init__(self)
		EntityCommon.__init__(self)
		
		DEBUG_MSG("Avatar::__init__:%s." % (self.__dict__))

	def onEnterSpace(self):
		"""
		KBEngine method.
		这个entity进入了一个新的space
		"""
		DEBUG_MSG("%s::onEnterSpace: %i" % (self.className, self.id))

	def onLeaveSpace(self):
		"""
		KBEngine method.
		这个entity将要离开当前space
		"""
		DEBUG_MSG("%s::onLeaveSpace: %i" % (self.className, self.id))
		
	def onBecomePlayer( self ):
		"""
		KBEngine method.
		当这个entity被引擎定义为角色时被调用
		"""
		DEBUG_MSG("%s::onBecomePlayer: %i" % (self.className, self.id))

	def update(self):
		pass
		
class PlayerAvatar(Avatar):
	def __init__(self):
		pass

	def onBecomePlayer( self ):
		"""
		KBEngine method.
		当这个entity被引擎定义为角色时被调用
		"""
		DEBUG_MSG("%s::onBecomePlayer: %i" % (self.className, self.id))
		KBEngine.callback(GameConfigs.BOTS_UPDATE_TIME, self.update)

	def onEnterSpace(self):
		"""
		KBEngine method.
		这个entity进入了一个新的space
		"""
		DEBUG_MSG("%s::onEnterSpace: %i" % (self.className, self.id))
		
		# 注意：由于PlayerAvatar是引擎底层强制由Avatar转换过来，__init__并不会再调用
		# 这里手动进行初始化一下
		self.__init__()
		
	def onLeaveSpace(self):
		"""
		KBEngine method.
		这个entity将要离开当前space
		"""
		DEBUG_MSG("%s::onLeaveSpace: %i" % (self.className, self.id))

	def update(self):
		DEBUG_MSG("%s::update: %i" % (self.className, self.id))
		if self.isDestroyed:
			return

		KBEngine.callback(GameConfigs.BOTS_UPDATE_TIME, self.update)
		