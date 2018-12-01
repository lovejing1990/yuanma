/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-11-28 00:47:21
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for doodad_func_attachments
-- ----------------------------
DROP TABLE IF EXISTS `doodad_func_attachments`;
CREATE TABLE `doodad_func_attachments` (
  `id` int(8) NOT NULL,
  `attach_point_id` int(8) DEFAULT NULL,
  `space` int(8) DEFAULT NULL,
  `bond_kind_id` int(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of doodad_func_attachments
-- ----------------------------
INSERT INTO `doodad_func_attachments` VALUES ('1', '1', '1', '0');
INSERT INTO `doodad_func_attachments` VALUES ('2', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('3', '2', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('4', '1', '1', '0');
INSERT INTO `doodad_func_attachments` VALUES ('5', '2', '1', '0');
INSERT INTO `doodad_func_attachments` VALUES ('6', '1', '1', '0');
INSERT INTO `doodad_func_attachments` VALUES ('7', '1', '1', '0');
INSERT INTO `doodad_func_attachments` VALUES ('8', '1', '1', '0');
INSERT INTO `doodad_func_attachments` VALUES ('9', '0', '1', '0');
INSERT INTO `doodad_func_attachments` VALUES ('10', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('13', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('14', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('15', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('17', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('18', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('19', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('20', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('21', '4', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('22', '2', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('23', '2', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('24', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('25', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('26', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('27', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('28', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('29', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('30', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('31', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('32', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('33', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('34', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('35', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('36', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('37', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('38', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('39', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('40', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('41', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('42', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('43', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('44', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('45', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('46', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('47', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('48', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('49', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('50', '2', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('51', '2', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('52', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('53', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('54', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('55', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('56', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('57', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('58', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('59', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('61', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('62', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('63', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('64', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('65', '0', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('66', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('67', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('68', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('69', '80', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('70', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('71', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('72', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('73', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('74', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('75', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('76', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('77', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('78', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('79', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('80', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('81', '2', '1', '3');
INSERT INTO `doodad_func_attachments` VALUES ('82', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('83', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('84', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('85', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('86', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('87', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('88', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('91', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('92', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('94', '80', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('95', '80', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('96', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('97', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('98', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('99', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('100', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('101', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('102', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('103', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('104', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('105', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('106', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('107', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('108', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('109', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('110', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('111', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('112', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('113', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('114', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('115', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('116', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('117', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('118', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('119', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('120', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('121', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('122', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('123', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('124', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('125', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('126', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('127', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('128', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('129', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('130', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('131', '2', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('133', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('135', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('137', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('138', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('139', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('140', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('141', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('142', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('143', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('144', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('145', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('146', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('147', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('148', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('149', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('150', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('151', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('152', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('153', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('154', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('155', '2', '3', '4');
INSERT INTO `doodad_func_attachments` VALUES ('156', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('157', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('158', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('159', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('160', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('161', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('162', '1', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('163', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('164', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('166', '80', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('167', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('168', '2', '2', '3');
INSERT INTO `doodad_func_attachments` VALUES ('169', '1', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('170', '2', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('171', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('172', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('173', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('174', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('175', '2', '1', '8');
INSERT INTO `doodad_func_attachments` VALUES ('176', '2', '1', '9');
INSERT INTO `doodad_func_attachments` VALUES ('177', '2', '1', '2');
INSERT INTO `doodad_func_attachments` VALUES ('178', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('179', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('180', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('181', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('182', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('183', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('184', '81', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('185', '80', '1', '1');
INSERT INTO `doodad_func_attachments` VALUES ('186', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('187', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('188', '2', '1', '6');
INSERT INTO `doodad_func_attachments` VALUES ('189', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('190', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('191', '2', '2', '7');
INSERT INTO `doodad_func_attachments` VALUES ('192', '2', '1', '9');
INSERT INTO `doodad_func_attachments` VALUES ('193', '0', '2', '3');
SET FOREIGN_KEY_CHECKS=1;
