/*
Navicat MySQL Data Transfer

Source Server         : AAEmu
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-10-10 12:38:20
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for formulas
-- ----------------------------
DROP TABLE IF EXISTS `formulas`;
CREATE TABLE `formulas` (
  `id` int(8) NOT NULL,
  `formula` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci; 

-- ----------------------------
-- Records of formulas
-- ----------------------------
INSERT INTO `formulas` VALUES ('2', '0 * (100 / casting_tolerance) * (1 + (1 * floor(damage_percent / 10)))');
INSERT INTO `formulas` VALUES ('3', '300 * (100 / casting_tolerance) * (0.42 * floor(damage_percent / 5))');
INSERT INTO `formulas` VALUES ('4', 'min(40, 12 * (1 + (source_level - target_level) / 50) / (1 + stealth_level / 50))');
INSERT INTO `formulas` VALUES ('5', 'clamp(1 + (npc_level - pc_level) * 0.03, 0.5, 1) * range');
INSERT INTO `formulas` VALUES ('6', '0');
INSERT INTO `formulas` VALUES ('7', 'log(pc_level) * 3');
INSERT INTO `formulas` VALUES ('8', 'experience / 20');
INSERT INTO `formulas` VALUES ('9', 'experience * 4 / 100');
INSERT INTO `formulas` VALUES ('10', '0.5');
INSERT INTO `formulas` VALUES ('11', ' if_negative(range - 1, 1, 1.05 + (min(range, 100)/100) )');
INSERT INTO `formulas` VALUES ('12', 'if_negative(range - 8, 0.8, 1)');
INSERT INTO `formulas` VALUES ('13', '(ab_level ^ 2) / 15 + 30');
INSERT INTO `formulas` VALUES ('14', 'clamp(npc_size_avg, 0.1, 10.0) * 13.0 + 15.0');
INSERT INTO `formulas` VALUES ('15', '(clamp(npc_size_avg, 0.1, 10.0) * 13.0 + 15.0) / 2.0');
INSERT INTO `formulas` VALUES ('16', 'clamp(npc_size_avg, 0.1, 10.0) * 5.0');
INSERT INTO `formulas` VALUES ('17', 'clamp(npc_size_avg, 0.1, 10.0) * 7.0');
INSERT INTO `formulas` VALUES ('18', 'clamp(npc_size_avg, 0.1, 10.0) * 10.0');
SET FOREIGN_KEY_CHECKS=1;
