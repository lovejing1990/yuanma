/*
Navicat MySQL Data Transfer

Source Server         : AA
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : melia

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-10-02 13:11:49
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for vars
-- ----------------------------
DROP TABLE IF EXISTS `vars`;
CREATE TABLE `vars` (
  `varId` bigint(20) NOT NULL AUTO_INCREMENT,
  `owner` varchar(128) NOT NULL,
  `name` varchar(128) NOT NULL,
  `type` char(2) NOT NULL,
  `value` mediumtext NOT NULL,
  PRIMARY KEY (`varId`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci; 

-- ----------------------------
-- Records of vars
-- ----------------------------
SET FOREIGN_KEY_CHECKS=1;
