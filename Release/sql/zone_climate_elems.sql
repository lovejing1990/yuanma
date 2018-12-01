/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : aaemu

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-10-22 00:39:05
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for zone_climate_elems
-- ----------------------------
DROP TABLE IF EXISTS `zone_climate_elems`;
CREATE TABLE `zone_climate_elems` (
  `id` int(8) NOT NULL,
  `zone_climate_id` int(8) DEFAULT NULL,
  `climate_id` int(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci;

-- ----------------------------
-- Records of zone_climate_elems
-- ----------------------------
INSERT INTO `zone_climate_elems` VALUES ('1', '2', '2');
INSERT INTO `zone_climate_elems` VALUES ('2', '3', '3');
INSERT INTO `zone_climate_elems` VALUES ('3', '4', '4');
INSERT INTO `zone_climate_elems` VALUES ('4', '5', '5');
INSERT INTO `zone_climate_elems` VALUES ('5', '6', '2');
INSERT INTO `zone_climate_elems` VALUES ('6', '6', '4');
INSERT INTO `zone_climate_elems` VALUES ('7', '7', '2');
INSERT INTO `zone_climate_elems` VALUES ('8', '7', '5');
INSERT INTO `zone_climate_elems` VALUES ('9', '8', '2');
INSERT INTO `zone_climate_elems` VALUES ('10', '8', '3');
SET FOREIGN_KEY_CHECKS=1;
