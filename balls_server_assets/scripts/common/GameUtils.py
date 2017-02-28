# -*- coding: utf-8 -*-

"""
"""
import Math
import math
import KBEngine
import GameConfigs
import random

def randomPosition2D(radius):
	return Math.Vector2(random.randint(0, GameConfigs.GAME_MAP_SIZE) + random.random(), random.randint(0, GameConfigs.GAME_MAP_SIZE) + random.random())
	
def randomPosition3D(radius):
	return Math.Vector3(random.randint(0, GameConfigs.GAME_MAP_SIZE) + random.random(), 0.0, random.randint(0, GameConfigs.GAME_MAP_SIZE) + random.random())
	

# 玩家体重转换为移动速度
def AvatarMass2MoveSpeed(mass):
	return 0