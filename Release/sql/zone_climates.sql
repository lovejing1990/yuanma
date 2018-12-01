/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : aaemu

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-10-22 00:38:52
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for zone_climates
-- ----------------------------
DROP TABLE IF EXISTS `zone_climates`;
CREATE TABLE `zone_climates` (
  `id` int(8) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci;

-- ----------------------------
-- Records of zone_climates
-- ----------------------------
INSERT INTO `zone_climates` VALUES ('1', 'Нет');
INSERT INTO `zone_climates` VALUES ('2', 'умеренный пояс');
INSERT INTO `zone_climates` VALUES ('3', 'Тропический');
INSERT INTO `zone_climates` VALUES ('4', 'Субарктический');
INSERT INTO `zone_climates` VALUES ('5', 'Сухой');
INSERT INTO `zone_climates` VALUES ('6', 'Климат с одним континентом [умеренный / холодный]');
INSERT INTO `zone_climates` VALUES ('7', 'Климат с одним континентом [умеренный / сухой]');
INSERT INTO `zone_climates` VALUES ('8', 'Климат с одним континентом [умеренный / тропический]');
INSERT INTO `zone_climates` VALUES ('9', '미사용_삭제는 하지 마세요');
SET FOREIGN_KEY_CHECKS=1;
