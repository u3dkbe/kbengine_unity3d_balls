# -*- coding: utf-8 -*-
import KBEngine
from KBEDebug import *
import GameConfigs
import random
import GameUtils

TIMER_TYPE_DESTROY = 1
TIMER_TYPE_BALANCE_MASS = 2

class Room(KBEngine.Entity):
	"""
	游戏场景
	"""
	def __init__(self):
		KBEngine.Entity.__init__(self)
		
		# 把自己移动到一个不可能触碰陷阱的地方
		self.position = (999999.0, 0.0, 0.0)

		# 这个房间中所有的玩家
		self.avatars = {}
		
		# 这个房间中产生的所有粮食
		self.foods = []
		
		# 这个房间中产生的所有粉碎球
		self.smashs = []
		
		# 告诉客户端加载地图
		KBEngine.addSpaceGeometryMapping(self.spaceID, None, "spaces/gameMap")
		
		DEBUG_MSG('created space[%d] entityID = %i, res = %s.' % (self.roomKeyC, self.id, "spaces/gameMap"))
		
		# 让baseapp和cellapp都能够方便的访问到这个房间的entityCall
		KBEngine.globalData["Room_%i" % self.spaceID] = self.base
	
		# 设置房间必要的数据，客户端可以获取之后做一些显示和限制
		KBEngine.setSpaceData(self.spaceID, "GAME_MAP_SIZE",  str(GameConfigs.GAME_MAP_SIZE))
		KBEngine.setSpaceData(self.spaceID, "ROOM_MAX_PLAYER",  str(GameConfigs.ROOM_MAX_PLAYER))
		KBEngine.setSpaceData(self.spaceID, "GAME_ROUND_TIME",  str(GameConfigs.GAME_ROUND_TIME))
		
		# 开始记录一局游戏时间， 时间结束后将玩家踢出空间同时销毁自己和空间
		self._destroyTimer = self.addTimer(GameConfigs.GAME_ROUND_TIME, 0, TIMER_TYPE_DESTROY)
		
		# 开启一个timer周期性的平衡粮食和粉碎球的数量
		self.addTimer(0.1, GameConfigs.GAME_BALANCE_MASS_TIME, TIMER_TYPE_BALANCE_MASS)

	def balanceMass(self):
		"""
		平衡粮食和粉碎球的数量
		"""
		diffSmashsCount = GameConfigs.SMASH_MAX - len(self.smashs)
		
		# 一次最多10个
		if diffSmashsCount > 10:
			diffSmashsCount = 10
			
		for i in range(diffSmashsCount):
			radius = 1.0 + random.random()
			pos = GameUtils.randomPosition3D(radius)
			dir = (0.0, 0.0, 0.0)
			entity = KBEngine.createEntity("Smash", self.spaceID, pos, dir, {"modelID" : 0, "modelScale" : 1.0, "modelRadius" : radius})
			self.smashs.append(entity.id)

		diffFoodsCount = GameConfigs.MAP_FOOD_MAX - len(self.foods)

		# 一次最多200个
		if diffFoodsCount > 200:
			diffFoodsCount = 200

		for i in range(diffFoodsCount):
			pos = GameUtils.randomPosition3D(5.0)
			dir = (0.0, 0.0, 0.0)
			mass = random.randint(5, 10) # 这个粮食吃掉奖励的能量
			radius = 1.0
			entity = KBEngine.createEntity("Food", self.spaceID, pos, dir, {"modelID" : random.randint(0, 2), "mass" : mass, "modelRadius" : radius})
			self.foods.append(entity.id)

		if diffFoodsCount > 0 or diffSmashsCount > 0:
			DEBUG_MSG('Room::balanceMass: space %i, roomKey=%i, addNewFoodsCount = %i, totalFoodsCount = %i, addNewSmashsCount = %i, totalSmashsCount = %i.' % 
				(self.spaceID, self.roomKeyC, diffFoodsCount, len(self.foods), diffSmashsCount, len(self.smashs)))
			
	#--------------------------------------------------------------------------------------------
	#                              Callbacks
	#--------------------------------------------------------------------------------------------
	def onTimer(self, id, userArg):
		"""
		KBEngine method.
		使用addTimer后， 当时间到达则该接口被调用
		@param id		: addTimer 的返回值ID
		@param userArg	: addTimer 最后一个参数所给入的数据
		"""
		if TIMER_TYPE_DESTROY == userArg:
			self.onDestroyTimer()
		elif TIMER_TYPE_BALANCE_MASS == userArg:
			self.balanceMass()

	def onDestroy(self):
		"""
		KBEngine method.
		"""
		DEBUG_MSG("Room::onDestroy: %i" % (self.id))
		del KBEngine.globalData["Room_%i" % self.spaceID]
		
	def onDestroyTimer(self):
		DEBUG_MSG("Room::onDestroyTimer: %i" % (self.id))
		# 请求销毁引擎中创建的真实空间，在空间销毁后，所有该空间上的实体都被销毁
		self.destroySpace()
	
	def onFoodDestroy(self, foodID):
		if foodID not in self.foods:
			ERROR_MSG("Room::onFoodDestroy: not found %i" % (foodID))
			return
			
		self.foods.remove(foodID)

	def onFoodSmash(self, smashID):
		if smashID not in self.smashs:
			ERROR_MSG("Room::onFoodSmash: not found %i" % (smashID))
			return
			
		self.smashs.remove(smashID)
		
	def onEnter(self, entityCall):
		"""
		defined method.
		进入场景
		"""
		DEBUG_MSG('Room::onEnter space[%d] entityID = %i.' % (self.spaceID, entityCall.id))
		self.avatars[entityCall.id] = entityCall

	def onLeave(self, entityID):
		"""
		defined method.
		离开场景
		"""
		DEBUG_MSG('Room::onLeave space[%d] entityID = %i.' % (self.spaceID, entityID))
		
		if entityID in self.avatars:
			del self.avatars[entityID]

