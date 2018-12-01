/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : aaemu

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-10-22 00:33:28
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for climates
-- ----------------------------
DROP TABLE IF EXISTS `climates`;
CREATE TABLE `climates` (
  `id` int(8) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci;

-- ----------------------------
-- Records of climates
-- ----------------------------
INSERT INTO `climates` VALUES ('1', 'Любой');
INSERT INTO `climates` VALUES ('2', 'Умеренный');
INSERT INTO `climates` VALUES ('3', 'Тропический');
INSERT INTO `climates` VALUES ('4', 'Субарктический');
INSERT INTO `climates` VALUES ('5', 'Сухой');
INSERT INTO `climates` VALUES ('6', 'Континентальный');
SET FOREIGN_KEY_CHECKS=1;
