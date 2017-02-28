# -*- coding: utf-8 -*-

"""
"""

# ------------------------------------------------------------------------------
# entity state
# ------------------------------------------------------------------------------
ENTITY_STATE_UNKNOW									= -1
ENTITY_STATE_SAFE										= 0
ENTITY_STATE_FREE										= 1
ENTITY_STATE_MAX    									= 4


#  一个房间最大人数
ROOM_MAX_PLAYER = 35

# 限制玩家最大分割数量
PLAYER_LIMIT_SPLIT = 16

#  一局游戏时间（秒）
GAME_ROUND_TIME = 720 #60 * 12

# 游戏中粮食和粉碎球平衡刷新时间 
GAME_BALANCE_MASS_TIME = 1

# Bots机器人AI频率（秒）
BOTS_UPDATE_TIME = 0.3

# 地图大小(米)
GAME_MAP_SIZE = 200

# 地图最大粮食数量
MAP_FOOD_MAX = 3000

# 玩家喷出的粮食最大数量
FIRE_FOOD_MAX = 20

# 地图最大粉碎者（病毒）数量
SMASH_MAX = 100

