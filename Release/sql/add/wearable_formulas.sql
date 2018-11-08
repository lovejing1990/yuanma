/*
Navicat MySQL Data Transfer

Source Server         : AAEmu
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-10-10 12:40:11
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for wearable_formulas
-- ----------------------------
DROP TABLE IF EXISTS `wearable_formulas`;
CREATE TABLE `wearable_formulas` (
  `id` int(8) NOT NULL,
  `kind_id` int(8) DEFAULT NULL,
  `formula` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci; 

-- ----------------------------
-- Records of wearable_formulas
-- ----------------------------
INSERT INTO `wearable_formulas` VALUES ('1', '0', 'floor(item_level ^ 1.1 * 45 + 100) * item_grade');
INSERT INTO `wearable_formulas` VALUES ('2', '1', 'floor(item_level ^ 1.1 * 25 + 117) * item_grade');
SET FOREIGN_KEY_CHECKS=1;
