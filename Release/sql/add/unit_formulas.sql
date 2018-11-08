/*
Navicat MySQL Data Transfer

Source Server         : AAEmu
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-10-10 12:40:20
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for unit_formulas
-- ----------------------------
DROP TABLE IF EXISTS `unit_formulas`;
CREATE TABLE `unit_formulas` (
  `id` int(8) NOT NULL,
  `formula` varchar(255) DEFAULT NULL,
  `kind_id` int(8) DEFAULT NULL,
  `owner_type_id` int(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci; 

-- ----------------------------
-- Records of unit_formulas
-- ----------------------------
INSERT INTO `unit_formulas` VALUES ('1', '( dex * 10 ) * 100', '1', '0');
INSERT INTO `unit_formulas` VALUES ('2', '(((str + spi) / 2 + 30 ) * 9 ) * 100', '2', '0');
INSERT INTO `unit_formulas` VALUES ('3', '((dex + int) / 2 * 8 ) * 100', '3', '0');
INSERT INTO `unit_formulas` VALUES ('4', '(str * 6 ) * 100', '4', '0');
INSERT INTO `unit_formulas` VALUES ('5', '((str + sta) / 2 * 4.5 ) * 100', '5', '0');
INSERT INTO `unit_formulas` VALUES ('6', '((dex + int) / 2 * 10 ) * 100', '6', '0');
INSERT INTO `unit_formulas` VALUES ('7', '(((dex + spi) / 2 + 30 ) * 9 ) * 100', '7', '0');
INSERT INTO `unit_formulas` VALUES ('8', '((dex + int) / 2 * 8 ) * 100', '8', '0');
INSERT INTO `unit_formulas` VALUES ('9', '(str * 6 ) * 100', '9', '0');
INSERT INTO `unit_formulas` VALUES ('10', '(int * 10 ) * 100', '10', '0');
INSERT INTO `unit_formulas` VALUES ('11', '(((int + spi) / 2 + 30 ) * 9 ) * 100', '11', '0');
INSERT INTO `unit_formulas` VALUES ('12', '(ab_level * 1.6 + 8) * 3', '12', '0');
INSERT INTO `unit_formulas` VALUES ('13', 'level_dps / (2 * (ab_level / 50) + 3)', '13', '0');
INSERT INTO `unit_formulas` VALUES ('14', '( level * 80 + sta * 8 ) + 100', '14', '0');
INSERT INTO `unit_formulas` VALUES ('15', 'level * 70 + int * 8 + 140', '15', '0');
INSERT INTO `unit_formulas` VALUES ('16', 'spi * 0.2 + 15', '16', '0');
INSERT INTO `unit_formulas` VALUES ('17', 'spi * 0.2 + 15', '17', '0');
INSERT INTO `unit_formulas` VALUES ('18', '( dex * 4 * npc_kind ) * 100', '1', '1');
INSERT INTO `unit_formulas` VALUES ('19', '((str + spi) / 2 * 10 ) * 100', '2', '1');
INSERT INTO `unit_formulas` VALUES ('20', '((dex + int) / 2 * 1 ) * 100', '3', '1');
INSERT INTO `unit_formulas` VALUES ('21', '(str * 0 ) * 100', '4', '1');
INSERT INTO `unit_formulas` VALUES ('22', '((str + sta) / 2 * 0 ) * 100', '5', '1');
INSERT INTO `unit_formulas` VALUES ('23', '((dex + int) / 2 * 4 ) * 100', '6', '1');
INSERT INTO `unit_formulas` VALUES ('24', '((dex + spi) / 2 * 10 ) * 100', '7', '1');
INSERT INTO `unit_formulas` VALUES ('25', '((dex + int) / 2 * 1 ) * 100', '8', '1');
INSERT INTO `unit_formulas` VALUES ('26', '(str * 0 ) * 100', '9', '1');
INSERT INTO `unit_formulas` VALUES ('27', '(int * 4 * npc_kind ) * 100', '10', '1');
INSERT INTO `unit_formulas` VALUES ('28', '((int + spi) / 2 * 10 ) * 100', '11', '1');
INSERT INTO `unit_formulas` VALUES ('29', '( floor( ( ab_level + 2 ) / 3 ) * 24 - 8 ) * ( npc_template * npc_kind * npc_grade )', '12', '1');
INSERT INTO `unit_formulas` VALUES ('30', 'level_dps / ((ab_level / 50) + 1)', '13', '1');
INSERT INTO `unit_formulas` VALUES ('31', '( 2.5  * level^2 + 20 * level + (sta * 10 ) ) * ( npc_template * npc_kind * npc_grade )', '14', '1');
INSERT INTO `unit_formulas` VALUES ('32', '(level * 20 + int * 10 + 130) * ( npc_kind * npc_grade )', '15', '1');
INSERT INTO `unit_formulas` VALUES ('33', 'spi * 0.1 + 15', '16', '1');
INSERT INTO `unit_formulas` VALUES ('34', 'spi * 0.07 + 15', '17', '1');
INSERT INTO `unit_formulas` VALUES ('35', '( dex * 10 ) * 100', '1', '2');
INSERT INTO `unit_formulas` VALUES ('36', '((str + spi) / 2 * 10 ) * 100', '2', '2');
INSERT INTO `unit_formulas` VALUES ('37', '((dex + int) / 2 * 8 ) * 100', '3', '2');
INSERT INTO `unit_formulas` VALUES ('38', '(str * 12 ) * 100', '4', '2');
INSERT INTO `unit_formulas` VALUES ('39', '((str + sta) / 2 * 9 ) * 100', '5', '2');
INSERT INTO `unit_formulas` VALUES ('40', '((dex + int) / 2 * 10 ) * 100', '6', '2');
INSERT INTO `unit_formulas` VALUES ('41', '((dex + spi) / 2 * 10 ) * 100', '7', '2');
INSERT INTO `unit_formulas` VALUES ('42', '((dex + int) / 2 * 8 ) * 100', '8', '2');
INSERT INTO `unit_formulas` VALUES ('43', '(str * 12 ) * 100', '9', '2');
INSERT INTO `unit_formulas` VALUES ('44', '(int * 10 ) * 100', '10', '2');
INSERT INTO `unit_formulas` VALUES ('45', '((int + spi) / 2 * 10 ) * 100', '11', '2');
INSERT INTO `unit_formulas` VALUES ('46', '(ab_level + 1) ^ 1.2 + 5', '12', '2');
INSERT INTO `unit_formulas` VALUES ('47', 'level_dps / ((ab_level / 50) + 3)', '13', '2');
INSERT INTO `unit_formulas` VALUES ('48', 'level * 30 + sta * 10', '14', '2');
INSERT INTO `unit_formulas` VALUES ('49', 'level * 20 + int * 10', '15', '2');
INSERT INTO `unit_formulas` VALUES ('50', '20', '16', '2');
INSERT INTO `unit_formulas` VALUES ('51', 'spi * 0.1 + 9', '17', '2');
INSERT INTO `unit_formulas` VALUES ('52', '( dex * 10 ) * 100', '1', '3');
INSERT INTO `unit_formulas` VALUES ('53', '((str + spi) / 2 * 10 ) * 100', '2', '3');
INSERT INTO `unit_formulas` VALUES ('54', '((dex + int) / 2 * 8 ) * 100', '3', '3');
INSERT INTO `unit_formulas` VALUES ('55', '(str * 12 ) * 100', '4', '3');
INSERT INTO `unit_formulas` VALUES ('56', '((str + sta) / 2 * 9 ) * 100', '5', '3');
INSERT INTO `unit_formulas` VALUES ('57', '((dex + int) / 2 * 10 ) * 100', '6', '3');
INSERT INTO `unit_formulas` VALUES ('58', '((dex + spi) / 2 * 10 ) * 100', '7', '3');
INSERT INTO `unit_formulas` VALUES ('59', '((dex + int) / 2 * 8 ) * 100', '8', '3');
INSERT INTO `unit_formulas` VALUES ('60', '(str * 12 ) * 100', '9', '3');
INSERT INTO `unit_formulas` VALUES ('61', '(int * 10 ) * 100', '10', '3');
INSERT INTO `unit_formulas` VALUES ('62', '((int + spi) / 2 * 10 ) * 100', '11', '3');
INSERT INTO `unit_formulas` VALUES ('63', '(ab_level + 1) ^ 1.2 + 5', '12', '3');
INSERT INTO `unit_formulas` VALUES ('64', 'level_dps / ((ab_level / 50) + 3)', '13', '3');
INSERT INTO `unit_formulas` VALUES ('65', 'level * 30 + sta * 10', '14', '3');
INSERT INTO `unit_formulas` VALUES ('66', 'level * 20 + int * 10', '15', '3');
INSERT INTO `unit_formulas` VALUES ('67', '0', '16', '3');
INSERT INTO `unit_formulas` VALUES ('68', 'spi * 0.1 + 9', '17', '3');
INSERT INTO `unit_formulas` VALUES ('69', '( dex * 10 ) * 100', '1', '4');
INSERT INTO `unit_formulas` VALUES ('70', '((str + spi) / 2 * 10 ) * 100', '2', '4');
INSERT INTO `unit_formulas` VALUES ('71', '((dex + int) / 2 * 8 ) * 100', '3', '4');
INSERT INTO `unit_formulas` VALUES ('72', '(str * 12 ) * 100', '4', '4');
INSERT INTO `unit_formulas` VALUES ('73', '((str + sta) / 2 * 9 ) * 100', '5', '4');
INSERT INTO `unit_formulas` VALUES ('74', '((dex + int) / 2 * 10 ) * 100', '6', '4');
INSERT INTO `unit_formulas` VALUES ('75', '((dex + spi) / 2 * 10 ) * 100', '7', '4');
INSERT INTO `unit_formulas` VALUES ('76', '((dex + int) / 2 * 8 ) * 100', '8', '4');
INSERT INTO `unit_formulas` VALUES ('77', '(str * 12 ) * 100', '9', '4');
INSERT INTO `unit_formulas` VALUES ('78', '(int * 10 ) * 100', '10', '4');
INSERT INTO `unit_formulas` VALUES ('79', '((int + spi) / 2 * 10 ) * 100', '11', '4');
INSERT INTO `unit_formulas` VALUES ('80', '(ab_level + 1) ^ 1.2 + 5', '12', '4');
INSERT INTO `unit_formulas` VALUES ('81', 'level_dps / ((ab_level / 50) + 3)', '13', '4');
INSERT INTO `unit_formulas` VALUES ('82', 'level * 30 + sta * 10', '14', '4');
INSERT INTO `unit_formulas` VALUES ('83', 'level * 20 + int * 10', '15', '4');
INSERT INTO `unit_formulas` VALUES ('84', 'spi * 0.2 * 1.0 + 8', '16', '4');
INSERT INTO `unit_formulas` VALUES ('85', 'spi * 0.1 + 9', '17', '4');
INSERT INTO `unit_formulas` VALUES ('86', '( dex * 10 ) * 100', '1', '5');
INSERT INTO `unit_formulas` VALUES ('87', '(((str + spi) / 2 + 30 ) * 9 ) * 100', '2', '5');
INSERT INTO `unit_formulas` VALUES ('88', '((dex + int) / 2 * 8 ) * 100', '3', '5');
INSERT INTO `unit_formulas` VALUES ('89', '(str * 6 ) * 100', '4', '5');
INSERT INTO `unit_formulas` VALUES ('90', '((str + sta) / 2 * 4.5 ) * 100', '5', '5');
INSERT INTO `unit_formulas` VALUES ('91', '((dex + int) / 2 * 10 ) * 100', '6', '5');
INSERT INTO `unit_formulas` VALUES ('92', '(((dex + spi) / 2 + 30 ) * 9 ) * 100', '7', '5');
INSERT INTO `unit_formulas` VALUES ('93', '((dex + int) / 2 * 8 ) * 100', '8', '5');
INSERT INTO `unit_formulas` VALUES ('94', '(str * 6 ) * 100', '9', '5');
INSERT INTO `unit_formulas` VALUES ('95', '(int * 10 ) * 100', '10', '5');
INSERT INTO `unit_formulas` VALUES ('96', '(((int + spi) / 2 + 30 ) * 9 ) * 100', '11', '5');
INSERT INTO `unit_formulas` VALUES ('97', '(ab_level * 1.6 + 8) * 3', '12', '5');
INSERT INTO `unit_formulas` VALUES ('98', 'level_dps / ((ab_level / 50) + 3)', '13', '5');
INSERT INTO `unit_formulas` VALUES ('99', '(level * 70 + sta * 10) * mate_kind', '14', '5');
INSERT INTO `unit_formulas` VALUES ('100', 'level * 15 + int * 10 * mate_kind', '15', '5');
INSERT INTO `unit_formulas` VALUES ('101', 'spi * 0.1 + 7', '16', '5');
INSERT INTO `unit_formulas` VALUES ('102', 'spi * 0.07 + 7', '17', '5');
INSERT INTO `unit_formulas` VALUES ('103', '0', '18', '0');
INSERT INTO `unit_formulas` VALUES ('104', '( 935 / 50 * level ) * ( npc_template * npc_kind * npc_grade )', '18', '1');
INSERT INTO `unit_formulas` VALUES ('105', '0', '18', '2');
INSERT INTO `unit_formulas` VALUES ('106', '0', '18', '3');
INSERT INTO `unit_formulas` VALUES ('107', '0', '18', '4');
INSERT INTO `unit_formulas` VALUES ('108', '0', '18', '5');
INSERT INTO `unit_formulas` VALUES ('109', 'spi * 4', '19', '0');
INSERT INTO `unit_formulas` VALUES ('110', '( 935 / 50 * level ) * ( npc_template * npc_kind * npc_grade )', '19', '1');
INSERT INTO `unit_formulas` VALUES ('111', '0', '19', '2');
INSERT INTO `unit_formulas` VALUES ('112', '0', '19', '3');
INSERT INTO `unit_formulas` VALUES ('113', '0', '19', '4');
INSERT INTO `unit_formulas` VALUES ('114', 'spi * 2', '19', '5');
INSERT INTO `unit_formulas` VALUES ('115', '((level ^ 1.3 + level * 3 + 17) * 100 ) * 100', '20', '0');
INSERT INTO `unit_formulas` VALUES ('116', '((level ^ 1.3 + level * 3 + 17) * 100 ) * 100', '20', '1');
INSERT INTO `unit_formulas` VALUES ('117', '((level ^ 1.3 + level * 3 + 17) * 100 ) * 100', '20', '2');
INSERT INTO `unit_formulas` VALUES ('118', '((level ^ 1.3 + level * 3 + 17) * 100 ) * 100', '20', '3');
INSERT INTO `unit_formulas` VALUES ('119', '((level ^ 1.3 + level * 3 + 17) * 100 ) * 100', '20', '4');
INSERT INTO `unit_formulas` VALUES ('120', '((level ^ 1.3 + level * 3 + 17) * 100 ) * 100', '20', '5');
INSERT INTO `unit_formulas` VALUES ('121', 'str * 100', '21', '0');
INSERT INTO `unit_formulas` VALUES ('122', '( ( floor( ( level + 2 ) / 3 ) * 12 + 1 ) + ( str * 0.1 ) - 5 ) * 1000 * ( npc_template * npc_kind * npc_grade )', '21', '1');
INSERT INTO `unit_formulas` VALUES ('123', 'str * 50', '21', '2');
INSERT INTO `unit_formulas` VALUES ('124', 'str * 50', '21', '3');
INSERT INTO `unit_formulas` VALUES ('125', 'str * 50', '21', '4');
INSERT INTO `unit_formulas` VALUES ('126', '(( level *2 + 8 ) + ( str * 0.1 ) ) * 1000', '21', '5');
INSERT INTO `unit_formulas` VALUES ('127', '10 + (level - 1) * 2 + if_negative( level - 51, 0, ( level - 50 ) * 8 )', '22', '0');
INSERT INTO `unit_formulas` VALUES ('128', '( level * 4 + 10 ) * npc_template', '22', '1');
INSERT INTO `unit_formulas` VALUES ('129', '10 + (level - 1) * 2', '22', '2');
INSERT INTO `unit_formulas` VALUES ('130', '10 + (level - 1) * 2', '22', '3');
INSERT INTO `unit_formulas` VALUES ('131', '10 + (level - 1) * 2', '22', '4');
INSERT INTO `unit_formulas` VALUES ('132', '10 + (level - 1) * 4', '22', '5');
INSERT INTO `unit_formulas` VALUES ('133', '10 + (level - 1) * 2 + if_negative( level - 51, 0, ( level - 50 ) * 8 )', '23', '0');
INSERT INTO `unit_formulas` VALUES ('134', '( level * 4 + 10 ) * npc_template', '23', '1');
INSERT INTO `unit_formulas` VALUES ('135', '10 + (level - 1) * 2', '23', '2');
INSERT INTO `unit_formulas` VALUES ('136', '10 + (level - 1) * 2', '23', '3');
INSERT INTO `unit_formulas` VALUES ('137', '10 + (level - 1) * 2', '23', '4');
INSERT INTO `unit_formulas` VALUES ('138', '10 + (level - 1) * 4', '23', '5');
INSERT INTO `unit_formulas` VALUES ('139', '10 + (level - 1) * 2 + if_negative( level - 51, 0, ( level - 50 ) * 8 )', '24', '0');
INSERT INTO `unit_formulas` VALUES ('140', '( level * 4 + 10 ) * npc_template', '24', '1');
INSERT INTO `unit_formulas` VALUES ('141', '10 + (level - 1) * 2', '24', '2');
INSERT INTO `unit_formulas` VALUES ('142', '10 + (level - 1) * 2', '24', '3');
INSERT INTO `unit_formulas` VALUES ('143', '10 + (level - 1) * 2', '24', '4');
INSERT INTO `unit_formulas` VALUES ('144', '10 + (level - 1) * 4', '24', '5');
INSERT INTO `unit_formulas` VALUES ('145', '10 + (level - 1) * 2 + if_negative( level - 51, 0, ( level - 50 ) * 8 )', '25', '0');
INSERT INTO `unit_formulas` VALUES ('146', '( level * 4 + 10 ) * npc_template', '25', '1');
INSERT INTO `unit_formulas` VALUES ('147', '10 + (level - 1) * 2', '25', '2');
INSERT INTO `unit_formulas` VALUES ('148', '10 + (level - 1) * 2', '25', '3');
INSERT INTO `unit_formulas` VALUES ('149', '10 + (level - 1) * 2', '25', '4');
INSERT INTO `unit_formulas` VALUES ('150', '10 + (level - 1) * 4', '25', '5');
INSERT INTO `unit_formulas` VALUES ('151', '10 + (level - 1) * 2 + if_negative( level - 51, 0, ( level - 50 ) * 8 )', '26', '0');
INSERT INTO `unit_formulas` VALUES ('152', '( level * 4 + 10 ) * npc_template', '26', '1');
INSERT INTO `unit_formulas` VALUES ('153', '10 + (level - 1) * 2', '26', '2');
INSERT INTO `unit_formulas` VALUES ('154', '10 + (level - 1) * 2', '26', '3');
INSERT INTO `unit_formulas` VALUES ('155', '10 + (level - 1) * 2', '26', '4');
INSERT INTO `unit_formulas` VALUES ('156', '10 + (level - 1) * 4', '26', '5');
INSERT INTO `unit_formulas` VALUES ('157', '10 + (level - 1) * 2', '27', '0');
INSERT INTO `unit_formulas` VALUES ('158', '11', '27', '1');
INSERT INTO `unit_formulas` VALUES ('159', '10 + (level - 1) * 2', '27', '2');
INSERT INTO `unit_formulas` VALUES ('160', '10 + (level - 1) * 2', '27', '3');
INSERT INTO `unit_formulas` VALUES ('161', '10 + (level - 1) * 2', '27', '4');
INSERT INTO `unit_formulas` VALUES ('162', '10 + (level - 1) * 4', '27', '5');
INSERT INTO `unit_formulas` VALUES ('163', 'dex * 100', '28', '0');
INSERT INTO `unit_formulas` VALUES ('164', '( ( floor( ( level + 2 ) / 3 ) * 12 + 1 ) + ( dex * 0.1 ) - 5 ) * 1000 * ( npc_template * npc_kind * npc_grade )', '28', '1');
INSERT INTO `unit_formulas` VALUES ('165', '0', '28', '2');
INSERT INTO `unit_formulas` VALUES ('166', '0', '28', '3');
INSERT INTO `unit_formulas` VALUES ('167', '0', '28', '4');
INSERT INTO `unit_formulas` VALUES ('168', '(( level *2 + 8 ) + ( dex * 0.1 ) ) * 1000', '28', '5');
INSERT INTO `unit_formulas` VALUES ('169', 'int * 100', '29', '0');
INSERT INTO `unit_formulas` VALUES ('170', '( ( floor( ( level + 2 ) / 3 ) * 12 + 1 ) + ( int * 0.1 ) - 5 ) * 1000 * ( npc_template * npc_kind * npc_grade )', '29', '1');
INSERT INTO `unit_formulas` VALUES ('171', '0', '29', '2');
INSERT INTO `unit_formulas` VALUES ('172', '0', '29', '3');
INSERT INTO `unit_formulas` VALUES ('173', '0', '29', '4');
INSERT INTO `unit_formulas` VALUES ('174', '(( level *2 + 8 ) + ( int * 0.1 ) ) * 1000', '29', '5');
INSERT INTO `unit_formulas` VALUES ('175', '( dex * 10 ) * 100', '1', '6');
INSERT INTO `unit_formulas` VALUES ('176', '((str + spi) / 2 * 10 ) * 100', '2', '6');
INSERT INTO `unit_formulas` VALUES ('177', '((dex + int) / 2 * 8 ) * 100', '3', '6');
INSERT INTO `unit_formulas` VALUES ('178', '(str * 12 ) * 100', '4', '6');
INSERT INTO `unit_formulas` VALUES ('179', '((str + sta) / 2 * 9 ) * 100', '5', '6');
INSERT INTO `unit_formulas` VALUES ('180', '((dex + int) / 2 * 10 ) * 100', '6', '6');
INSERT INTO `unit_formulas` VALUES ('181', '((dex + spi) / 2 * 10 ) * 100', '7', '6');
INSERT INTO `unit_formulas` VALUES ('182', '((dex + int) / 2 * 8 ) * 100', '8', '6');
INSERT INTO `unit_formulas` VALUES ('183', '(str * 12 ) * 100', '9', '6');
INSERT INTO `unit_formulas` VALUES ('184', '(int * 10 ) * 100', '10', '6');
INSERT INTO `unit_formulas` VALUES ('185', '((int + spi) / 2 * 10 ) * 100', '11', '6');
INSERT INTO `unit_formulas` VALUES ('186', '(ab_level + 1) ^ 1.2 + 5', '12', '6');
INSERT INTO `unit_formulas` VALUES ('187', 'level_dps / ((ab_level / 50) + 3)', '13', '6');
INSERT INTO `unit_formulas` VALUES ('188', '10000', '14', '6');
INSERT INTO `unit_formulas` VALUES ('189', '0', '15', '6');
INSERT INTO `unit_formulas` VALUES ('190', '0', '16', '6');
INSERT INTO `unit_formulas` VALUES ('191', '0', '17', '6');
INSERT INTO `unit_formulas` VALUES ('192', '30030', '18', '6');
INSERT INTO `unit_formulas` VALUES ('193', '30030', '19', '6');
INSERT INTO `unit_formulas` VALUES ('194', '((level ^ 1.3 + level * 3 + 17) * 100 ) * 100', '20', '6');
INSERT INTO `unit_formulas` VALUES ('195', 'str * 50', '21', '6');
INSERT INTO `unit_formulas` VALUES ('196', '10 + (level - 1) * 2', '22', '6');
INSERT INTO `unit_formulas` VALUES ('197', '10 + (level - 1) * 2', '23', '6');
INSERT INTO `unit_formulas` VALUES ('198', '10 + (level - 1) * 2', '24', '6');
INSERT INTO `unit_formulas` VALUES ('199', '10 + (level - 1) * 2', '25', '6');
INSERT INTO `unit_formulas` VALUES ('200', '10 + (level - 1) * 2', '26', '6');
INSERT INTO `unit_formulas` VALUES ('201', '10 + (level - 1) * 2', '27', '6');
INSERT INTO `unit_formulas` VALUES ('202', '0', '28', '6');
INSERT INTO `unit_formulas` VALUES ('203', '0', '29', '6');
INSERT INTO `unit_formulas` VALUES ('204', '100', '30', '0');
INSERT INTO `unit_formulas` VALUES ('205', '100', '30', '1');
INSERT INTO `unit_formulas` VALUES ('206', '100', '30', '2');
INSERT INTO `unit_formulas` VALUES ('207', '100', '30', '3');
INSERT INTO `unit_formulas` VALUES ('208', '100', '30', '4');
INSERT INTO `unit_formulas` VALUES ('209', '100', '30', '5');
INSERT INTO `unit_formulas` VALUES ('210', '100', '30', '6');
INSERT INTO `unit_formulas` VALUES ('211', '( spi * 0.1 ) * 5', '31', '0');
INSERT INTO `unit_formulas` VALUES ('212', '0', '31', '1');
INSERT INTO `unit_formulas` VALUES ('213', '0', '31', '2');
INSERT INTO `unit_formulas` VALUES ('214', '0', '31', '3');
INSERT INTO `unit_formulas` VALUES ('215', '0', '31', '4');
INSERT INTO `unit_formulas` VALUES ('216', ' ( spi * 0.1 ) * 2', '31', '5');
INSERT INTO `unit_formulas` VALUES ('217', '0', '31', '6');
INSERT INTO `unit_formulas` VALUES ('218', '( spi * 0.1 ) * 5', '32', '0');
INSERT INTO `unit_formulas` VALUES ('219', '0', '32', '1');
INSERT INTO `unit_formulas` VALUES ('220', '0', '32', '2');
INSERT INTO `unit_formulas` VALUES ('221', '0', '32', '3');
INSERT INTO `unit_formulas` VALUES ('222', '0', '32', '4');
INSERT INTO `unit_formulas` VALUES ('223', ' ( spi * 0.1 ) * 2', '32', '5');
INSERT INTO `unit_formulas` VALUES ('224', '0', '32', '6');
INSERT INTO `unit_formulas` VALUES ('225', 'clamp(10 + (10 * (level_diff - 4) / 16), 10, 20)', '33', '0');
INSERT INTO `unit_formulas` VALUES ('226', 'clamp(10 + (50 * (level_diff - 4) / 16), 10, 60)', '33', '1');
INSERT INTO `unit_formulas` VALUES ('227', '10', '33', '2');
INSERT INTO `unit_formulas` VALUES ('228', '10', '33', '3');
INSERT INTO `unit_formulas` VALUES ('229', '10', '33', '4');
INSERT INTO `unit_formulas` VALUES ('230', 'clamp(10 + (10 * (level_diff - 4) / 16), 10, 20)', '33', '5');
INSERT INTO `unit_formulas` VALUES ('231', '10', '33', '6');
INSERT INTO `unit_formulas` VALUES ('232', '0', '34', '0');
INSERT INTO `unit_formulas` VALUES ('233', '(level * 5 + 90) * npc_grade', '34', '1');
INSERT INTO `unit_formulas` VALUES ('234', '0', '34', '2');
INSERT INTO `unit_formulas` VALUES ('235', '0', '34', '3');
INSERT INTO `unit_formulas` VALUES ('236', '0', '34', '4');
INSERT INTO `unit_formulas` VALUES ('237', '0', '34', '5');
INSERT INTO `unit_formulas` VALUES ('238', '0', '34', '6');
INSERT INTO `unit_formulas` VALUES ('239', '200', '35', '0');
INSERT INTO `unit_formulas` VALUES ('240', '200', '35', '1');
INSERT INTO `unit_formulas` VALUES ('241', '200', '35', '2');
INSERT INTO `unit_formulas` VALUES ('242', '200', '35', '3');
INSERT INTO `unit_formulas` VALUES ('243', '200', '35', '4');
INSERT INTO `unit_formulas` VALUES ('244', '200', '35', '5');
INSERT INTO `unit_formulas` VALUES ('245', '200', '35', '6');
INSERT INTO `unit_formulas` VALUES ('246', '175', '36', '0');
INSERT INTO `unit_formulas` VALUES ('247', '175', '36', '1');
INSERT INTO `unit_formulas` VALUES ('248', '175', '36', '2');
INSERT INTO `unit_formulas` VALUES ('249', '175', '36', '3');
INSERT INTO `unit_formulas` VALUES ('250', '175', '36', '4');
INSERT INTO `unit_formulas` VALUES ('251', '175', '36', '5');
INSERT INTO `unit_formulas` VALUES ('252', '175', '36', '6');
INSERT INTO `unit_formulas` VALUES ('253', '150', '37', '0');
INSERT INTO `unit_formulas` VALUES ('254', '150', '37', '1');
INSERT INTO `unit_formulas` VALUES ('255', '150', '37', '2');
INSERT INTO `unit_formulas` VALUES ('256', '150', '37', '3');
INSERT INTO `unit_formulas` VALUES ('257', '150', '37', '4');
INSERT INTO `unit_formulas` VALUES ('258', '150', '37', '5');
INSERT INTO `unit_formulas` VALUES ('259', '150', '37', '6');
INSERT INTO `unit_formulas` VALUES ('260', '0', '38', '0');
INSERT INTO `unit_formulas` VALUES ('261', '0', '38', '1');
INSERT INTO `unit_formulas` VALUES ('262', '0', '38', '2');
INSERT INTO `unit_formulas` VALUES ('263', '0', '38', '3');
INSERT INTO `unit_formulas` VALUES ('264', '0', '38', '4');
INSERT INTO `unit_formulas` VALUES ('265', '0', '38', '5');
INSERT INTO `unit_formulas` VALUES ('266', '0', '38', '6');
SET FOREIGN_KEY_CHECKS=1;
