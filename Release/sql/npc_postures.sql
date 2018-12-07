/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-12-03 01:52:29
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for npc_postures
-- ----------------------------
DROP TABLE IF EXISTS `npc_postures`;
CREATE TABLE `npc_postures` (
  `id` int(8) NOT NULL,
  `npc_posture_set_id` int(8) DEFAULT NULL,
  `anim_action_id` int(8) DEFAULT NULL,
  `talk_anim` varchar(255) DEFAULT NULL,
  `start_tod_time` int(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci;

-- ----------------------------
-- Records of npc_postures
-- ----------------------------
INSERT INTO `npc_postures` VALUES ('1', '1', '55', 'fist_pos_stn_stabler_talk', '0');
INSERT INTO `npc_postures` VALUES ('3', '3', '92', 'fist_pos_sit_chair_weaponshop_dealer_talk', '0');
INSERT INTO `npc_postures` VALUES ('4', '4', '54', '', '0');
INSERT INTO `npc_postures` VALUES ('5', '5', '50', '', '0');
INSERT INTO `npc_postures` VALUES ('6', '6', '101', 'fist_pos_stn_building_dealer_talk', '4');
INSERT INTO `npc_postures` VALUES ('7', '7', '98', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('8', '8', '83', 'fist_pos_stn_handsback_talk', '0');
INSERT INTO `npc_postures` VALUES ('9', '9', '39', 'fist_pos_priest_pray_talk', '0');
INSERT INTO `npc_postures` VALUES ('11', '11', '37', 'fist_pos_record_talk', '0');
INSERT INTO `npc_postures` VALUES ('12', '12', '54', 'fist_pos_stn_thinking_talk', '0');
INSERT INTO `npc_postures` VALUES ('13', '13', '83', '', '0');
INSERT INTO `npc_postures` VALUES ('14', '14', '50', 'fist_pos_stn_crossarm_talk', '0');
INSERT INTO `npc_postures` VALUES ('15', '15', '113', '', '0');
INSERT INTO `npc_postures` VALUES ('16', '16', '58', '', '0');
INSERT INTO `npc_postures` VALUES ('17', '17', '26', 'fist_pos_sit_lean_talk', '0');
INSERT INTO `npc_postures` VALUES ('19', '19', '106', 'fist_pos_stn_materials_trader_talk', '0');
INSERT INTO `npc_postures` VALUES ('20', '20', '73', 'fist_pos_stn_pharmacist_talk', '0');
INSERT INTO `npc_postures` VALUES ('21', '21', '103', 'fist_pos_record_talk', '0');
INSERT INTO `npc_postures` VALUES ('22', '22', '87', 'fist_pos_sit_chair_nursery_dealer_talk', '0');
INSERT INTO `npc_postures` VALUES ('23', '23', '224', 'fist_pos_sit_crouch_furniturerepair_talk', '0');
INSERT INTO `npc_postures` VALUES ('24', '24', '100', 'fist_pos_stn_armor_dealer_talk', '0');
INSERT INTO `npc_postures` VALUES ('25', '25', '40', 'fist_pos_priest_silent_talk', '0');
INSERT INTO `npc_postures` VALUES ('26', '26', '30', 'fist_pos_dresser_talk', '0');
INSERT INTO `npc_postures` VALUES ('27', '27', '223', 'fist_pos_sit_crouch_livestock_talk', '0');
INSERT INTO `npc_postures` VALUES ('28', '28', '68', 'fist_pos_stn_florist_talk', '0');
INSERT INTO `npc_postures` VALUES ('29', '29', '108', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('30', '30', '113', 'fist_pos_stn_getherhands_talk', '0');
INSERT INTO `npc_postures` VALUES ('31', '31', '106', '', '0');
INSERT INTO `npc_postures` VALUES ('32', '32', '46', 'fist_ac_sexappeal', '0');
INSERT INTO `npc_postures` VALUES ('33', '33', '47', 'fist_ac_temptation', '0');
INSERT INTO `npc_postures` VALUES ('34', '34', '25', 'fist_pos_sit_crouch_talk', '0');
INSERT INTO `npc_postures` VALUES ('35', '35', '81', 'fist_pos_sit_gnd_prisoner_talk', '0');
INSERT INTO `npc_postures` VALUES ('36', '36', '72', 'fist_pos_stn_oldman_cane_talk', '0');
INSERT INTO `npc_postures` VALUES ('37', '37', '27', 'fist_pos_sit_crossleg_talk', '0');
INSERT INTO `npc_postures` VALUES ('38', '38', '65', 'fist_pos_sit_gnd_drunken_talk', '7');
INSERT INTO `npc_postures` VALUES ('39', '39', '89', 'fist_pos_stn_cooking_soup_talk', '0');
INSERT INTO `npc_postures` VALUES ('40', '40', '99', '', '0');
INSERT INTO `npc_postures` VALUES ('41', '41', '105', 'fist_pos_sit_chair_talk', '4');
INSERT INTO `npc_postures` VALUES ('42', '42', '104', 'fist_pos_stn_soldier_general_talk', '0');
INSERT INTO `npc_postures` VALUES ('43', '43', '82', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('45', '45', '78', 'fist_pos_sit_chair_rest_talk', '4');
INSERT INTO `npc_postures` VALUES ('47', '47', '20', 'fist_em_sleep', '0');
INSERT INTO `npc_postures` VALUES ('48', '48', '61', 'fist_pos_sit_crouch_kid_talk', '0');
INSERT INTO `npc_postures` VALUES ('49', '49', '75', 'fist_pos_sit_crouch_gang_talk', '0');
INSERT INTO `npc_postures` VALUES ('50', '50', '56', 'fist_pos_sit_grd_netting_talk', '0');
INSERT INTO `npc_postures` VALUES ('51', '51', '60', 'fist_pos_stn_sick_searching_talk', '0');
INSERT INTO `npc_postures` VALUES ('52', '52', '59', 'fist_pos_sit_crouch_crying_idle', '0');
INSERT INTO `npc_postures` VALUES ('53', '53', '70', 'fist_pos_sit_crouch_investigation_talk', '0');
INSERT INTO `npc_postures` VALUES ('55', '55', '112', 'fist_pos_stn_soldier_guard_talk', '0');
INSERT INTO `npc_postures` VALUES ('56', '56', '24', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('59', '59', '62', 'fist_pos_sit_crouch_kid_playing_talk', '0');
INSERT INTO `npc_postures` VALUES ('60', '60', '76', 'fist_pos_corpse_1', '0');
INSERT INTO `npc_postures` VALUES ('62', '62', '58', 'fist_pos_stn_searching_talk', '0');
INSERT INTO `npc_postures` VALUES ('63', '63', '69', 'fist_pos_stn_soldier_archer_talk', '0');
INSERT INTO `npc_postures` VALUES ('64', '64', '93', 'fist_pos_sit_chair_guitarist_tune_talk', '0');
INSERT INTO `npc_postures` VALUES ('67', '67', '39', '', '0');
INSERT INTO `npc_postures` VALUES ('68', '68', '80', '', '0');
INSERT INTO `npc_postures` VALUES ('72', '72', '115', 'fist_pos_sit_chiar_talk', '0');
INSERT INTO `npc_postures` VALUES ('73', '73', '79', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('78', '75', '109', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('79', '76', '110', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('80', '77', '111', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('83', '83', '118', 'fist_ac_cough', '0');
INSERT INTO `npc_postures` VALUES ('84', '84', '119', '', '0');
INSERT INTO `npc_postures` VALUES ('85', '85', '120', '', '0');
INSERT INTO `npc_postures` VALUES ('86', '86', '118', '', '0');
INSERT INTO `npc_postures` VALUES ('87', '87', '121', 'fist_ac_falldown_loop', '0');
INSERT INTO `npc_postures` VALUES ('88', '88', '122', '', '0');
INSERT INTO `npc_postures` VALUES ('89', '89', '123', 'fist_ac_shoveling', '0');
INSERT INTO `npc_postures` VALUES ('90', '90', '124', '', '0');
INSERT INTO `npc_postures` VALUES ('91', '91', '125', '', '0');
INSERT INTO `npc_postures` VALUES ('92', '92', '126', '', '0');
INSERT INTO `npc_postures` VALUES ('93', '93', '126', '', '0');
INSERT INTO `npc_postures` VALUES ('94', '94', '128', '', '0');
INSERT INTO `npc_postures` VALUES ('95', '95', '129', '', '0');
INSERT INTO `npc_postures` VALUES ('97', '97', '131', '', '0');
INSERT INTO `npc_postures` VALUES ('98', '98', '132', 'fist_em_vomit', '0');
INSERT INTO `npc_postures` VALUES ('99', '99', '133', 'fist_pos_stn_readbook_talk', '0');
INSERT INTO `npc_postures` VALUES ('100', '79', '134', 'fsit_pos_stn_afraid_talk', '0');
INSERT INTO `npc_postures` VALUES ('101', '78', '135', 'fist_pos_stn_angry_talk', '0');
INSERT INTO `npc_postures` VALUES ('102', '81', '135', '', '0');
INSERT INTO `npc_postures` VALUES ('103', '82', '134', '', '0');
INSERT INTO `npc_postures` VALUES ('105', '100', '136', '', '0');
INSERT INTO `npc_postures` VALUES ('106', '102', '137', '', '0');
INSERT INTO `npc_postures` VALUES ('107', '103', '138', '', '0');
INSERT INTO `npc_postures` VALUES ('108', '104', '139', '', '0');
INSERT INTO `npc_postures` VALUES ('109', '105', '140', '', '0');
INSERT INTO `npc_postures` VALUES ('110', '106', '141', 'fist_pos_sit_chair_rest_talk', '0');
INSERT INTO `npc_postures` VALUES ('111', '107', '142', 'fist_pos_sit_crouch_investigation_talk', '0');
INSERT INTO `npc_postures` VALUES ('112', '108', '143', 'fist_pos_record_talk', '0');
INSERT INTO `npc_postures` VALUES ('113', '109', '144', 'fist_pos_sit_chair_pure_talk', '0');
INSERT INTO `npc_postures` VALUES ('114', '110', '145', '', '0');
INSERT INTO `npc_postures` VALUES ('115', '111', '146', 'fist_pos_stn_leanshovel_talk', '0');
INSERT INTO `npc_postures` VALUES ('116', '112', '147', 'fist_pos_stn_peep_talk', '0');
INSERT INTO `npc_postures` VALUES ('117', '113', '147', '', '0');
INSERT INTO `npc_postures` VALUES ('118', '114', '148', 'fist_pos_stn_singing_talk', '0');
INSERT INTO `npc_postures` VALUES ('119', '115', '148', '', '0');
INSERT INTO `npc_postures` VALUES ('120', '116', '149', '', '0');
INSERT INTO `npc_postures` VALUES ('121', '117', '63', 'fist_pos_sit_crouch_crying_talk', '0');
INSERT INTO `npc_postures` VALUES ('122', '118', '63', '', '0');
INSERT INTO `npc_postures` VALUES ('123', '119', '61', '', '0');
INSERT INTO `npc_postures` VALUES ('124', '120', '62', '', '0');
INSERT INTO `npc_postures` VALUES ('125', '121', '150', 'fist_pos_stn_anvil_talk', '0');
INSERT INTO `npc_postures` VALUES ('126', '122', '155', 'fist_pos_gnd_sidesleep_talk', '0');
INSERT INTO `npc_postures` VALUES ('127', '123', '157', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('128', '124', '158', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('129', '125', '159', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('130', '126', '160', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('131', '127', '161', 'fist_pos_sit_chair_crossleg_talk', '0');
INSERT INTO `npc_postures` VALUES ('132', '128', '157', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('133', '129', '158', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('134', '130', '162', 'fist_pos_hang_prisoner_talk', '0');
INSERT INTO `npc_postures` VALUES ('135', '131', '163', 'music_co_sk_lute_cast', '0');
INSERT INTO `npc_postures` VALUES ('136', '133', '165', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('137', '134', '166', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('138', '135', '167', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('139', '136', '168', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('140', '137', '169', '', '0');
INSERT INTO `npc_postures` VALUES ('141', '132', '164', 'music_co_sk_pipe_cast', '0');
INSERT INTO `npc_postures` VALUES ('143', '139', '170', 'fist_pos_sit_chair_oldman_cane_talk', '0');
INSERT INTO `npc_postures` VALUES ('145', '142', '171', 'fist_pos_stn_liabilities_talk', '0');
INSERT INTO `npc_postures` VALUES ('146', '143', '172', '', '0');
INSERT INTO `npc_postures` VALUES ('147', '144', '173', 'fist_pos_sit_chair_readbook_talk', '4');
INSERT INTO `npc_postures` VALUES ('148', '145', '174', 'fist_pos_gnd_corpse_lastwill_talk', '0');
INSERT INTO `npc_postures` VALUES ('149', '146', '203', 'fist_pos_stn_guitarist_talk', '0');
INSERT INTO `npc_postures` VALUES ('150', '147', '176', 'fist_pos_sit_chair_armrest_talk', '0');
INSERT INTO `npc_postures` VALUES ('151', '148', '177', 'fist_pos_stn_crossarm_talk', '0');
INSERT INTO `npc_postures` VALUES ('152', '149', '177', '', '0');
INSERT INTO `npc_postures` VALUES ('153', '150', '179', 'fist_pos_stn_cleaning_idle', '0');
INSERT INTO `npc_postures` VALUES ('154', '151', '180', 'fist_pos_sit_chair_crossleg_talk', '4');
INSERT INTO `npc_postures` VALUES ('155', '152', '125', 'fist_pos_stn_stumble_talk', '0');
INSERT INTO `npc_postures` VALUES ('156', '153', '181', 'fist_pos_sit_chair_rest_talk', '0');
INSERT INTO `npc_postures` VALUES ('157', '154', '182', 'fist_pos_sit_chair_crossleg_talk', '0');
INSERT INTO `npc_postures` VALUES ('158', '155', '183', 'fist_pos_sit_chair_crossleg_talk', '0');
INSERT INTO `npc_postures` VALUES ('159', '156', '184', 'fist_pos_sit_chair_crossleg_talk', '0');
INSERT INTO `npc_postures` VALUES ('160', '157', '185', 'fist_pos_sit_chair_crossleg_talk', '0');
INSERT INTO `npc_postures` VALUES ('162', '38', '155', 'fist_pos_gnd_sidesleep_talk', '20');
INSERT INTO `npc_postures` VALUES ('163', '144', '160', 'fist_pos_sit_chair_talk', '20');
INSERT INTO `npc_postures` VALUES ('164', '144', '160', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('167', '38', '155', 'fist_pos_gnd_sidesleep_talk', '0');
INSERT INTO `npc_postures` VALUES ('168', '158', '186', 'fist_pos_sit_grd_netting_talk', '0');
INSERT INTO `npc_postures` VALUES ('171', '151', '187', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('172', '151', '187', 'fist_pos_sit_chair_talk', '20');
INSERT INTO `npc_postures` VALUES ('173', '159', '189', 'fist_pos_sit_chair_armrest_talk', '0');
INSERT INTO `npc_postures` VALUES ('174', '160', '188', 'fist_pos_stn_onehand_relaxed_idle', '0');
INSERT INTO `npc_postures` VALUES ('175', '161', '188', '', '0');
INSERT INTO `npc_postures` VALUES ('176', '162', '190', 'fist_pos_stn_onehand_relaxed_idle(trowel01)', '0');
INSERT INTO `npc_postures` VALUES ('177', '163', '190', '', '0');
INSERT INTO `npc_postures` VALUES ('178', '164', '191', '', '0');
INSERT INTO `npc_postures` VALUES ('179', '165', '191', '', '0');
INSERT INTO `npc_postures` VALUES ('180', '166', '192', 'fist_pos_stn_onehand_relaxed_idle(bow_01_1 )', '0');
INSERT INTO `npc_postures` VALUES ('181', '167', '192', '', '0');
INSERT INTO `npc_postures` VALUES ('182', '168', '48', 'fist_ac_sprinklewater', '0');
INSERT INTO `npc_postures` VALUES ('183', '169', '48', '', '0');
INSERT INTO `npc_postures` VALUES ('184', '170', '49', 'fist_ac_get_fruit', '0');
INSERT INTO `npc_postures` VALUES ('185', '171', '49', '', '0');
INSERT INTO `npc_postures` VALUES ('186', '172', '74', 'fist_ac_feeding', '0');
INSERT INTO `npc_postures` VALUES ('187', '173', '74', '', '0');
INSERT INTO `npc_postures` VALUES ('188', '6', '79', 'fist_pos_sit_chair_sleep_talk', '0');
INSERT INTO `npc_postures` VALUES ('189', '6', '79', 'fist_pos_sit_chair_sleep_talk', '20');
INSERT INTO `npc_postures` VALUES ('190', '174', '55', '', '0');
INSERT INTO `npc_postures` VALUES ('191', '175', '179', '', '0');
INSERT INTO `npc_postures` VALUES ('192', '41', '160', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('193', '41', '160', 'fist_pos_sit_chair_talk', '20');
INSERT INTO `npc_postures` VALUES ('194', '176', '68', '', '0');
INSERT INTO `npc_postures` VALUES ('195', '177', '194', 'fist_pos_stn_liabilities_talk', '0');
INSERT INTO `npc_postures` VALUES ('196', '179', '195', 'fist_pos_stn_liabilities_talk', '0');
INSERT INTO `npc_postures` VALUES ('197', '180', '196', 'fist_pos_stn_onehand_relaxed_idle(lamp)', '0');
INSERT INTO `npc_postures` VALUES ('198', '181', '196', '', '0');
INSERT INTO `npc_postures` VALUES ('199', '182', '149', 'fist_pos_stn_shy_talk', '0');
INSERT INTO `npc_postures` VALUES ('200', '183', '193', 'fist_pos_stn_distract_talk', '0');
INSERT INTO `npc_postures` VALUES ('201', '184', '193', '', '0');
INSERT INTO `npc_postures` VALUES ('202', '185', '140', 'fist_pos_stn_crying_talk', '0');
INSERT INTO `npc_postures` VALUES ('203', '186', '197', 'fist_pos_stn_onehand_relaxed_idle(ins_w_16_1)', '0');
INSERT INTO `npc_postures` VALUES ('204', '187', '197', '', '0');
INSERT INTO `npc_postures` VALUES ('205', '188', '198', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('206', '189', '150', '', '0');
INSERT INTO `npc_postures` VALUES ('207', '190', '171', '', '0');
INSERT INTO `npc_postures` VALUES ('208', '191', '194', '', '0');
INSERT INTO `npc_postures` VALUES ('209', '192', '195', '', '0');
INSERT INTO `npc_postures` VALUES ('210', '193', '199', 'fist_pos_sit_gnd_wounded_talk', '0');
INSERT INTO `npc_postures` VALUES ('211', '194', '83', '', '3');
INSERT INTO `npc_postures` VALUES ('212', '194', '196', '', '20');
INSERT INTO `npc_postures` VALUES ('213', '194', '196', '', '0');
INSERT INTO `npc_postures` VALUES ('214', '195', '200', 'fist_pos_sit_chair_rest_talk', '0');
INSERT INTO `npc_postures` VALUES ('215', '196', '196', '', '0');
INSERT INTO `npc_postures` VALUES ('216', '196', '113', '', '3');
INSERT INTO `npc_postures` VALUES ('217', '196', '196', '', '20');
INSERT INTO `npc_postures` VALUES ('218', '197', '179', '', '3');
INSERT INTO `npc_postures` VALUES ('219', '197', '196', '', '0');
INSERT INTO `npc_postures` VALUES ('220', '197', '196', '', '20');
INSERT INTO `npc_postures` VALUES ('221', '198', '174', 'fist_pos_gnd_corpse_lastwill_talking_talk', '0');
INSERT INTO `npc_postures` VALUES ('222', '199', '202', '', '0');
INSERT INTO `npc_postures` VALUES ('224', '45', '160', 'fist_pos_sit_chair_talk', '0');
INSERT INTO `npc_postures` VALUES ('225', '45', '160', 'fist_pos_sit_chair_talk', '20');
INSERT INTO `npc_postures` VALUES ('226', '200', '205', '', '0');
INSERT INTO `npc_postures` VALUES ('227', '201', '206', 'fist_pos_sit_chair_readbook_talk', '0');
INSERT INTO `npc_postures` VALUES ('228', '202', '207', 'fist_ac_pulling', '0');
INSERT INTO `npc_postures` VALUES ('229', '203', '207', '', '0');
INSERT INTO `npc_postures` VALUES ('230', '204', '208', 'fist_pos_sit_crouch_investigation_talk', '0');
INSERT INTO `npc_postures` VALUES ('231', '205', '208', '', '0');
INSERT INTO `npc_postures` VALUES ('232', '206', '209', 'fist_pos_sit_chair_rest_talk', '0');
INSERT INTO `npc_postures` VALUES ('233', '207', '210', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('234', '208', '60', '', '0');
INSERT INTO `npc_postures` VALUES ('235', '209', '213', 'fist_pos_priest_resurrection_talk', '0');
INSERT INTO `npc_postures` VALUES ('236', '210', '214', 'fist_pos_stn_soldier_mercenary_talk', '0');
INSERT INTO `npc_postures` VALUES ('238', '212', '205', 'fist_ac_mine(Ax)', '0');
INSERT INTO `npc_postures` VALUES ('239', '213', '216', 'fist_pos_sit_chair_pure_talk', '0');
INSERT INTO `npc_postures` VALUES ('240', '214', '217', 'fist_pos_sit_chair_oldman_cane_talk', '0');
INSERT INTO `npc_postures` VALUES ('241', '215', '218', 'fist_pos_stn_eatsuop_talk', '0');
INSERT INTO `npc_postures` VALUES ('242', '216', '219', 'fist_pos_sit_chair_eatsuop_talk', '0');
INSERT INTO `npc_postures` VALUES ('243', '217', '220', '', '0');
INSERT INTO `npc_postures` VALUES ('244', '218', '221', '', '0');
INSERT INTO `npc_postures` VALUES ('245', '219', '175', '', '0');
INSERT INTO `npc_postures` VALUES ('246', '220', '146', '', '0');
INSERT INTO `npc_postures` VALUES ('247', '221', '222', 'fist_pos_stn_onehand_relaxed_idle(guitar)', '0');
INSERT INTO `npc_postures` VALUES ('248', '222', '222', '', '0');
INSERT INTO `npc_postures` VALUES ('249', '223', '203', '', '0');
INSERT INTO `npc_postures` VALUES ('250', '224', '223', 'fist_pos_sit_crouch_livestock_talk', '0');
INSERT INTO `npc_postures` VALUES ('251', '225', '224', 'fist_pos_sit_crouch_furniturerepair_talk', '0');
INSERT INTO `npc_postures` VALUES ('252', '226', '225', 'fist_pos_stn_drink_talk', '0');
INSERT INTO `npc_postures` VALUES ('253', '227', '226', 'fist_pos_sit_chair_drink_talk', '0');
INSERT INTO `npc_postures` VALUES ('254', '228', '214', '', '0');
INSERT INTO `npc_postures` VALUES ('255', '229', '104', '', '0');
INSERT INTO `npc_postures` VALUES ('256', '230', '112', '', '0');
INSERT INTO `npc_postures` VALUES ('257', '231', '227', 'fist_pos_stn_anvil_talk', '0');
INSERT INTO `npc_postures` VALUES ('258', '232', '228', '', '0');
INSERT INTO `npc_postures` VALUES ('259', '233', '28', 'fist_pos_soldier_attention_talk', '0');
INSERT INTO `npc_postures` VALUES ('260', '234', '232', 'fist_ac_mine(Miners)', '0');
INSERT INTO `npc_postures` VALUES ('261', '235', '233', 'fist_pos_stn_keeperflag_talk', '0');
INSERT INTO `npc_postures` VALUES ('263', '237', '235', 'fist_pos_sit_chair_drink_talk', '0');
INSERT INTO `npc_postures` VALUES ('265', '239', '25', '', '0');
INSERT INTO `npc_postures` VALUES ('266', '240', '236', 'fist_pos_sit_chair_pure_talk', '0');
INSERT INTO `npc_postures` VALUES ('267', '241', '237', '', '0');
INSERT INTO `npc_postures` VALUES ('268', '242', '238', 'fist_ba_dance_idle', '0');
INSERT INTO `npc_postures` VALUES ('269', '243', '239', 'fist_ba_dance2_idle', '0');
INSERT INTO `npc_postures` VALUES ('270', '244', '125', 'fist_pos_stn_stumble_talk', '0');
INSERT INTO `npc_postures` VALUES ('271', '244', '225', 'fist_pos_stn_drink_idle', '7');
INSERT INTO `npc_postures` VALUES ('272', '244', '125', 'fist_pos_stn_stumble_talk', '20');
INSERT INTO `npc_postures` VALUES ('273', '245', '240', 'fist_pos_stn_onehand_relaxed_idle(ladle)', '0');
INSERT INTO `npc_postures` VALUES ('274', '246', '240', '', '0');
INSERT INTO `npc_postures` VALUES ('275', '247', '243', 'fist_pos_sit_chair_drink_talk', '0');
INSERT INTO `npc_postures` VALUES ('277', '249', '244', 'fist_pos_sit_chair_drink_talk', '0');
INSERT INTO `npc_postures` VALUES ('278', '250', '245', '', '0');
INSERT INTO `npc_postures` VALUES ('279', '251', '247', '', '0');
INSERT INTO `npc_postures` VALUES ('280', '252', '225', '', '0');
INSERT INTO `npc_postures` VALUES ('281', '253', '218', '', '0');
INSERT INTO `npc_postures` VALUES ('282', '254', '250', 'fist_pos_stn_onehand_relaxed_idle(Cane)', '0');
INSERT INTO `npc_postures` VALUES ('283', '255', '250', '', '0');
INSERT INTO `npc_postures` VALUES ('284', '256', '252', '', '0');
INSERT INTO `npc_postures` VALUES ('285', '257', '253', '', '0');
INSERT INTO `npc_postures` VALUES ('286', '258', '254', '', '0');
INSERT INTO `npc_postures` VALUES ('287', '259', '255', '', '0');
INSERT INTO `npc_postures` VALUES ('288', '260', '256', 'fist_pos_stn_anvil_talk', '0');
INSERT INTO `npc_postures` VALUES ('291', '263', '120', '', '0');
SET FOREIGN_KEY_CHECKS=1;
