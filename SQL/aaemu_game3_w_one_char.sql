/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : aaemu_game

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2019-04-01 23:03:22
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
INSERT INTO `abilities` VALUES ('1', '0', '1');
INSERT INTO `abilities` VALUES ('2', '0', '1');
INSERT INTO `abilities` VALUES ('3', '0', '1');
INSERT INTO `abilities` VALUES ('4', '0', '1');
INSERT INTO `abilities` VALUES ('5', '0', '1');
INSERT INTO `abilities` VALUES ('6', '0', '1');
INSERT INTO `abilities` VALUES ('7', '0', '1');
INSERT INTO `abilities` VALUES ('8', '0', '1');
INSERT INTO `abilities` VALUES ('9', '0', '1');
INSERT INTO `abilities` VALUES ('10', '0', '1');

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
INSERT INTO `actabilities` VALUES ('1', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('2', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('3', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('4', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('5', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('6', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('7', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('8', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('9', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('10', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('11', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('12', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('13', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('14', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('15', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('16', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('17', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('18', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('19', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('20', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('21', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('22', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('23', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('24', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('25', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('26', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('27', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('28', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('29', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('30', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('31', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('32', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('33', '0', '0', '1');
INSERT INTO `actabilities` VALUES ('34', '0', '0', '1');

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
INSERT INTO `characters` VALUES ('1', '1', 'Newbie', '1', '2', 0x03CB10000000000000000000000000000000000000000000000000000000000000000000000000803F000000000000803F0000803F00000000000000000400BC01AA00000000000000000000803F0000803F0000803F8FC2353F0000803F0000803F0000803FE37B8BFFAFECEFFFAFECEFFF584838FF00000000800000EF00EF00EE000103000000000000110000000000FE00063BB900D800EE00D400281BEBE100E700F037230000000000640000000000000064000000F0000000000000002BD50000006400000000F9000000E0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, '1', '0', '0', '370', '320', '50', '2019-03-29 22:47:02', '0', '1', '11', '11', '1', '179', '15578', '15382.1', '126.484', '0', '0', '0', '101', '', '0', '0', '0', '0001-01-01 00:00:00', '0', '0001-01-01 00:00:00', '0', '0001-01-01 00:00:00', '0', '0', '0', '0', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '0', '0', '0', '0', '0', '50', '50', '0', 0x00020200000002C03E000002D446000000000000000001CD0F000001674900000168490000029F3F0000029F38000000000000000248370000026229000002343A000002363A000002353A0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000, '2019-03-30 02:47:02', '2019-03-29 22:47:02');

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
INSERT INTO `items` VALUES ('16777216', 'AAEmu.Game.Models.Game.Items.Armor', '23387', 'Equipment', '2', '1', 0x5500000000000000000000000000000000000000000000000000000000000000000000, '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777217', 'AAEmu.Game.Models.Game.Items.Armor', '23388', 'Equipment', '4', '1', 0x4600000000000000000000000000000000000000000000000000000000000000000000, '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777218', 'AAEmu.Game.Models.Game.Items.Armor', '23390', 'Equipment', '6', '1', 0x2300000000000000000000000000000000000000000000000000000000000000000000, '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777219', 'AAEmu.Game.Models.Game.Items.Weapon', '5569', 'Equipment', '15', '1', 0x8200000000000000000000000000000000000000000000000000000000000000000000, '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777220', 'AAEmu.Game.Models.Game.Items.Weapon', '6152', 'Equipment', '16', '1', 0x9B00000000000000000000000000000000000000000000000000000000000000000000, '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777221', 'AAEmu.Game.Models.Game.Items.Weapon', '6127', 'Equipment', '17', '1', 0x8200000000000000000000000000000000000000000000000000000000000000000000, '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777222', 'AAEmu.Game.Models.Game.Items.Weapon', '6177', 'Equipment', '18', '1', 0x8200000000000000000000000000000000000000000000000000000000000000000000, '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777223', 'AAEmu.Game.Models.Game.Items.BodyPart', '19839', 'Equipment', '19', '1', '', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777224', 'AAEmu.Game.Models.Game.Items.BodyPart', '25372', 'Equipment', '20', '1', '', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777225', 'AAEmu.Game.Models.Game.Items.BodyPart', '539', 'Equipment', '24', '1', '', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777226', 'AAEmu.Game.Models.Game.Items.Item', '4045', 'Inventory', '0', '1', '', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777227', 'AAEmu.Game.Models.Game.Items.Item', '18791', 'Inventory', '1', '3', '', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777228', 'AAEmu.Game.Models.Game.Items.Item', '18792', 'Inventory', '2', '3', '', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');
INSERT INTO `items` VALUES ('16777229', 'AAEmu.Game.Models.Game.Items.Item', '417', 'Inventory', '3', '3', '', '0', '0', '0001-01-01 00:00:00', '0001-01-01 00:00:00', '1', '0', '2019-03-29 22:47:02');

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
INSERT INTO `skills` VALUES ('18132', '1', 'Skill', '1');
SET FOREIGN_KEY_CHECKS=1;
