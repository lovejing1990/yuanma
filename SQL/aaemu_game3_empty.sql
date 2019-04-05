/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : aaemu_game

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2019-03-25 19:37:58
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for abilities
-- ----------------------------
DROP TABLE IF EXISTS `abilities`;
CREATE TABLE `abilities` (
  `id` tinyint(3) unsigned NOT NULL,
  `exp` int(11) NOT NULL,
  `owner` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of abilities
-- ----------------------------

-- ----------------------------
-- Table structure for actabilities
-- ----------------------------
DROP TABLE IF EXISTS `actabilities`;
CREATE TABLE `actabilities` (
  `id` int(10) unsigned NOT NULL,
  `point` int(10) unsigned NOT NULL DEFAULT '0',
  `step` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `owner` int(10) unsigned NOT NULL,
  PRIMARY KEY (`owner`,`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of actabilities
-- ----------------------------

-- ----------------------------
-- Table structure for appellations
-- ----------------------------
DROP TABLE IF EXISTS `appellations`;
CREATE TABLE `appellations` (
  `id` int(10) unsigned NOT NULL,
  `active` tinyint(1) NOT NULL DEFAULT '0',
  `owner` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of appellations
-- ----------------------------

-- ----------------------------
-- Table structure for blocked
-- ----------------------------
DROP TABLE IF EXISTS `blocked`;
CREATE TABLE `blocked` (
  `owner` int(11) NOT NULL,
  `blocked_id` int(11) NOT NULL,
  PRIMARY KEY (`owner`,`blocked_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of blocked
-- ----------------------------

-- ----------------------------
-- Table structure for characters
-- ----------------------------
DROP TABLE IF EXISTS `characters`;
CREATE TABLE `characters` (
  `id` int(11) unsigned NOT NULL,
  `account_id` int(11) unsigned NOT NULL,
  `name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `race` tinyint(2) NOT NULL,
  `gender` tinyint(1) NOT NULL,
  `unit_model_params` blob NOT NULL,
  `level` tinyint(4) NOT NULL,
  `expirience` int(11) NOT NULL,
  `recoverable_exp` int(11) NOT NULL,
  `hp` int(11) NOT NULL,
  `mp` int(11) NOT NULL,
  `labor_power` mediumint(9) NOT NULL,
  `labor_power_modified` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `consumed_lp` int(11) NOT NULL,
  `ability1` tinyint(4) NOT NULL,
  `ability2` tinyint(4) NOT NULL,
  `ability3` tinyint(4) NOT NULL,
  `world_id` int(11) unsigned NOT NULL,
  `zone_id` int(11) unsigned NOT NULL,
  `x` float NOT NULL,
  `y` float NOT NULL,
  `z` float NOT NULL,
  `rotation_x` tinyint(4) NOT NULL,
  `rotation_y` tinyint(4) NOT NULL,
  `rotation_z` tinyint(4) NOT NULL,
  `faction_id` int(11) unsigned NOT NULL,
  `faction_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `expedition_id` int(11) NOT NULL,
  `family` int(11) unsigned NOT NULL,
  `dead_count` mediumint(8) unsigned NOT NULL,
  `dead_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `rez_wait_duration` int(11) NOT NULL,
  `rez_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `rez_penalty_duration` int(11) NOT NULL,
  `leave_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `money` bigint(20) NOT NULL,
  `money2` bigint(20) NOT NULL,
  `honor_point` int(11) NOT NULL,
  `vocation_point` int(11) NOT NULL,
  `crime_point` int(11) NOT NULL,
  `crime_record` int(11) NOT NULL,
  `delete_request_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `transfer_request_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `delete_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `bm_point` int(11) NOT NULL,
  `auto_use_aapoint` tinyint(1) NOT NULL,
  `prev_point` int(11) NOT NULL,
  `point` int(11) NOT NULL,
  `gift` int(11) NOT NULL,
  `num_inv_slot` tinyint(3) unsigned NOT NULL DEFAULT '50',
  `num_bank_slot` smallint(5) unsigned NOT NULL DEFAULT '50',
  `expanded_expert` tinyint(4) NOT NULL,
  `slots` blob NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`id`,`account_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of characters
-- ----------------------------

-- ----------------------------
-- Table structure for completed_quests
-- ----------------------------
DROP TABLE IF EXISTS `completed_quests`;
CREATE TABLE `completed_quests` (
  `id` int(11) unsigned NOT NULL,
  `data` tinyblob NOT NULL,
  `owner` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id`,`owner`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of completed_quests
-- ----------------------------

-- ----------------------------
-- Table structure for expeditions
-- ----------------------------
DROP TABLE IF EXISTS `expeditions`;
CREATE TABLE `expeditions` (
  `id` int(11) NOT NULL,
  `owner` int(11) NOT NULL,
  `owner_name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `mother` int(11) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of expeditions
-- ----------------------------

-- ----------------------------
-- Table structure for family_members
-- ----------------------------
DROP TABLE IF EXISTS `family_members`;
CREATE TABLE `family_members` (
  `character_id` int(11) NOT NULL,
  `family_id` int(11) NOT NULL,
  `name` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `role` tinyint(1) NOT NULL DEFAULT '0',
  `title` varchar(45) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`family_id`,`character_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of family_members
-- ----------------------------

-- ----------------------------
-- Table structure for friends
-- ----------------------------
DROP TABLE IF EXISTS `friends`;
CREATE TABLE `friends` (
  `id` int(11) NOT NULL,
  `friend_id` int(11) NOT NULL,
  `owner` int(11) NOT NULL,
  PRIMARY KEY (`id`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of friends
-- ----------------------------

-- ----------------------------
-- Table structure for housings
-- ----------------------------
DROP TABLE IF EXISTS `housings`;
CREATE TABLE `housings` (
  `id` int(11) NOT NULL,
  `account_id` int(10) unsigned NOT NULL,
  `owner` int(10) unsigned NOT NULL,
  `template_id` int(10) unsigned NOT NULL,
  `x` float NOT NULL,
  `y` float NOT NULL,
  `z` float NOT NULL,
  `rotation_z` tinyint(4) NOT NULL,
  `current_step` tinyint(4) NOT NULL,
  `permission` tinyint(4) NOT NULL,
  PRIMARY KEY (`account_id`,`owner`,`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of housings
-- ----------------------------

-- ----------------------------
-- Table structure for items
-- ----------------------------
DROP TABLE IF EXISTS `items`;
CREATE TABLE `items` (
  `id` bigint(20) unsigned NOT NULL,
  `type` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `template_id` int(11) unsigned NOT NULL,
  `slot_type` enum('Equipment','Inventory','Bank') CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `slot` int(11) NOT NULL,
  `count` int(11) NOT NULL,
  `details` blob,
  `lifespan_mins` int(11) NOT NULL,
  `made_unit_id` int(11) unsigned NOT NULL DEFAULT '0',
  `unsecure_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `unpack_time` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  `owner` int(11) unsigned NOT NULL,
  `grade` tinyint(1) DEFAULT '0',
  `created_at` datetime NOT NULL DEFAULT '0001-01-01 00:00:00',
  PRIMARY KEY (`id`) USING BTREE,
  KEY `owner` (`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of items
-- ----------------------------

-- ----------------------------
-- Table structure for mates
-- ----------------------------
DROP TABLE IF EXISTS `mates`;
CREATE TABLE `mates` (
  `id` int(11) unsigned NOT NULL,
  `item_id` bigint(20) unsigned NOT NULL,
  `name` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `xp` int(11) NOT NULL,
  `level` tinyint(4) NOT NULL,
  `mileage` int(11) NOT NULL,
  `hp` int(11) NOT NULL,
  `mp` int(11) NOT NULL,
  `owner` int(11) unsigned NOT NULL,
  `updated_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `created_at` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`,`item_id`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of mates
-- ----------------------------

-- ----------------------------
-- Table structure for options
-- ----------------------------
DROP TABLE IF EXISTS `options`;
CREATE TABLE `options` (
  `key` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `value` text CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `owner` int(11) unsigned NOT NULL,
  PRIMARY KEY (`key`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of options
-- ----------------------------

-- ----------------------------
-- Table structure for portal_book_coords
-- ----------------------------
DROP TABLE IF EXISTS `portal_book_coords`;
CREATE TABLE `portal_book_coords` (
  `id` int(11) NOT NULL,
  `name` varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `x` int(11) DEFAULT '0',
  `y` int(11) DEFAULT '0',
  `z` int(11) DEFAULT '0',
  `zone_id` int(11) DEFAULT '0',
  `z_rot` int(11) DEFAULT '0',
  `sub_zone_id` int(11) DEFAULT '0',
  `owner` int(11) NOT NULL,
  PRIMARY KEY (`id`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of portal_book_coords
-- ----------------------------

-- ----------------------------
-- Table structure for portal_visited_district
-- ----------------------------
DROP TABLE IF EXISTS `portal_visited_district`;
CREATE TABLE `portal_visited_district` (
  `id` int(11) NOT NULL,
  `subzone` int(11) NOT NULL,
  `owner` int(11) NOT NULL,
  PRIMARY KEY (`id`,`subzone`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of portal_visited_district
-- ----------------------------

-- ----------------------------
-- Table structure for quests
-- ----------------------------
DROP TABLE IF EXISTS `quests`;
CREATE TABLE `quests` (
  `id` int(11) unsigned NOT NULL,
  `template_id` int(11) unsigned NOT NULL,
  `data` tinyblob NOT NULL,
  `status` tinyint(4) NOT NULL,
  `owner` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id`,`owner`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of quests
-- ----------------------------

-- ----------------------------
-- Table structure for skills
-- ----------------------------
DROP TABLE IF EXISTS `skills`;
CREATE TABLE `skills` (
  `id` int(11) unsigned NOT NULL,
  `level` tinyint(4) NOT NULL,
  `type` enum('Skill','Buff') CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `owner` int(11) unsigned NOT NULL,
  PRIMARY KEY (`id`,`owner`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of skills
-- ----------------------------
SET FOREIGN_KEY_CHECKS=1;
