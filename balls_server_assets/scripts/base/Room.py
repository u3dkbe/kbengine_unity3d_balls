# -*- coding: utf-8 -*-
import KBEngine
import random
import copy
import math
from KBEDebug import *

class Room(KBEngine.Base):
	"""
	一个可操控cellapp上真正space的实体
	注意：它是一个实体，并不是真正的space，真正的space存在于cellapp的内存中，通过这个实体与之关联并操控space。
	"""
	def __init__(self):
		KBEngine.Base.__init__(self)
		
		self.cellData["roomKeyC"] = self.roomKey
		
		# 请求在cellapp上创建cell空间
		self.createInNewSpace(None)
		
		self.avatars = {}

	def enterRoom(self, entityMailbox, position, direction):
		"""
		defined method.
		请求进入某个space中
		"""
		entityMailbox.createCell(self.cell)
		self.onEnter(entityMailbox)

	def leaveRoom(self, entityID):
		"""
		defined method.
		某个玩家请求退出这个space
		"""
		self.onLeave(entityID)
		
	def onTimer(self, tid, userArg):
		"""
		KBEngine method.
		引擎回调timer触发
		"""
		#DEBUG_MSG("%s::onTimer: %i, tid:%i, arg:%i" % (self.getScriptName(), self.id, tid, userArg))
		pass
		
	def onEnter(self, entityMailbox):
		"""
		defined method.
		进入场景
		"""
		self.avatars[entityMailbox.id] = entityMailbox
		
	def onLeave(self, entityID):
		"""
		defined method.
		离开场景
		"""
		if entityID in self.avatars:
			del self.avatars[entityID]

	def onLoseCell(self):
		"""
		KBEngine method.
		entity的cell部分实体丢失
		"""
		KBEngine.globalData["Halls"].onRoomLoseCell(self.roomKey)
		
		self.avatars = {}
		self.destroy()

	def onGetCell(self):
		"""
		KBEngine method.
		entity的cell部分实体被创建成功
		"""
		DEBUG_MSG("Room::onGetCell: %i" % self.id)
		KBEngine.globalData["Halls"].onRoomGetCell(self, self.roomKey)
