/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-12-03 01:52:19
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for npc_posture_sets
-- ----------------------------
DROP TABLE IF EXISTS `npc_posture_sets`;
CREATE TABLE `npc_posture_sets` (
  `id` int(8) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `quest_anim_action_id` int(8) DEFAULT NULL,
  `comment` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci;

-- ----------------------------
-- Records of npc_posture_sets
-- ----------------------------
INSERT INTO `npc_posture_sets` VALUES ('1', 'stn_act_stabler_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('3', 'chair_weapon_male', '0', '무기상인');
INSERT INTO `npc_posture_sets` VALUES ('4', 'stn_thinking_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('5', 'stn_crossarm_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('6', 'chair_rest_building_dealer_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('7', 'stn_stabler_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('8', 'stn_handsback_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('9', 'stn_priest_pray_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('11', 'stn_record_lookaround_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('12', 'stn_thinking_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('13', 'stn_handsback_male_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('14', 'stn_crossarm_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('15', 'stn_getherhands_female_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('16', 'stn_searching_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('17', 'sit_lean_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('19', 'stn_crossarm_material_trader_female', '0', '재료상인');
INSERT INTO `npc_posture_sets` VALUES ('20', 'stn_pharmacist_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('21', 'stn_record_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('22', 'obj_chair_plant_male', '0', '묘목상인');
INSERT INTO `npc_posture_sets` VALUES ('23', 'stn_handback_furniure_dealer_male', '0', '가구상인');
INSERT INTO `npc_posture_sets` VALUES ('24', 'stn_crossarm_armor_dealer_male', '0', '방어구상인');
INSERT INTO `npc_posture_sets` VALUES ('25', 'stn_sermon_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('26', 'obj_stn_dress_male', '0', '의상상인');
INSERT INTO `npc_posture_sets` VALUES ('27', 'chair_rest_livestock_female', '0', '가축 상인');
INSERT INTO `npc_posture_sets` VALUES ('28', 'stn_florist_female', '0', '씨앗상인');
INSERT INTO `npc_posture_sets` VALUES ('29', 'stn_soldier_nuian_all', '0', '누이안 경비병, 감시병 -> 28번 포스쳐 여벌 남아 있음. (깃발)');
INSERT INTO `npc_posture_sets` VALUES ('30', 'stn_getherhands_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('31', ' stn_crossarm_material_trader_female_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('32', 'ground_sexappeal_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('33', 'chair_temptation_female (의자 없음)', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('34', 'sit_torch_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('35', 'sit_prisoner_all', '0', '죄수, 포로');
INSERT INTO `npc_posture_sets` VALUES ('36', 'stn_oldman_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('37', 'sit_crossleg_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('38', 'sit_drunken_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('39', 'obj_stn_cook_female', '0', '음식상인, 요리사');
INSERT INTO `npc_posture_sets` VALUES ('40', 'stn_scope_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('41', 'chair_straightleg_female', '204', '');
INSERT INTO `npc_posture_sets` VALUES ('42', 'stn_commander_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('43', 'stn_soldier_axe_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('45', 'chair_rest_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('47', 'ground_sleep_all(em)', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('48', 'sit_crouch_kid', '0', 'girl01 용');
INSERT INTO `npc_posture_sets` VALUES ('49', 'sit_gang_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('50', 'sit_netting_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('51', 'stn_search_cough_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('52', 'sit_crouch_crying', '0', 'girl01 용');
INSERT INTO `npc_posture_sets` VALUES ('53', 'sit_investigation_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('55', 'stn_soldier_sword_all (무기안나옴)', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('56', 'chair_searching_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('59', 'sit_crouch_kid_playing', '0', 'girl01 용');
INSERT INTO `npc_posture_sets` VALUES ('60', 'ground_corpse_all(em)', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('62', 'stn_searching_all', '0', '남자 제작 예정 (9월 1주)');
INSERT INTO `npc_posture_sets` VALUES ('63', 'stn_soldier_archer_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('64', 'chair_guitar_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('67', 'stn_priest_pray_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('68', 'sit_kneel_all(em)', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('72', 'chair_searching_all(judge)', '0', '재판관 전용 (56번과 다른 의자가 붙어 있음)');
INSERT INTO `npc_posture_sets` VALUES ('73', 'chair_sleep_all', '204', '');
INSERT INTO `npc_posture_sets` VALUES ('75', 'stn_soldier_elf_all', '0', '엘프 경비병, 감시병');
INSERT INTO `npc_posture_sets` VALUES ('76', 'stn_soldier_hariharan_all', '0', '하리하란 경비병, 감시병');
INSERT INTO `npc_posture_sets` VALUES ('77', 'stn_soldier_ferre_male', '0', '페레 경비병, 감시병');
INSERT INTO `npc_posture_sets` VALUES ('78', 'stn_angry_all', '0', '어셋 제작 예정');
INSERT INTO `npc_posture_sets` VALUES ('79', 'stn_afraid_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('81', 'stn_angry_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('82', 'stn_afraid_all_notalk', '97', '9월 1주차 발주 (어셋제작예정)');
INSERT INTO `npc_posture_sets` VALUES ('83', 'stn_cough_kid', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('84', 'stn_sworddance_all', '0', 'fist_pos_stn_sdance_talk');
INSERT INTO `npc_posture_sets` VALUES ('85', 'sit_beggar_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('86', 'stn_cough_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('87', 'ground_falldown_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('88', 'stn_hurray_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('89', 'stn_shoveling_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('90', 'sit_hammer_all', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('91', 'stn_stumble_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('92', 'stn_talk_1_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('93', 'stn_talk_2_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('94', 'stn_gang_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('95', 'stn_lonely_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('96', 'stn_loud_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('97', 'stn_sweat_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('98', 'stn_vomit_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('99', 'stn_readbook_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('100', 'stn_relaxed_a', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('102', 'stn_relaxed_b', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('103', 'stn_relaxed_c', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('104', 'stn_boring_all', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('105', 'stn_crying_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('106', 'chair_stump_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('107', 'sit_investigation_machine_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('108', 'stn_record_machine_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('109', 'chair_pink_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('110', 'stn_calling_all', '97', 'fist_pos_stn_calling_idle');
INSERT INTO `npc_posture_sets` VALUES ('111', 'stn_shoveling_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('112', 'stn_peep_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('113', 'stn_peep_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('114', 'stn_singing_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('115', 'stn_singing_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('116', 'stn_shy_kid_notalk', '97', 'girl01/narayana_girl01 용');
INSERT INTO `npc_posture_sets` VALUES ('117', 'sit_crouch_crying_kid', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('118', 'sit_crouch_crying_kid_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('119', 'sit_crouch_kid_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('120', 'sit_crouch_kid_playing_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('121', 'stn_anvil_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('122', 'ground_sidesleep_all ', '0', 'fist_pos_gnd_sidesleep_talk');
INSERT INTO `npc_posture_sets` VALUES ('123', 'stn_onshoulder_Pickaxe_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('124', 'stn_onshoulder_fishingrod_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('125', 'sit_chair_tapswaits_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('126', 'sit_chair_snooze_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('127', 'sit_chair_crossleg_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('128', 'stn_pickaxe_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('129', 'stn_fishingrod_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('130', 'hang_prisoner_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('131', 'stn_playlute_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('132', 'stn_playpipe_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('133', 'stn_soldier_hariharan_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('134', 'stn_soldier_nuian_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('135', 'stn_soldier_elf_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('136', 'stn_soldier_ferre_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('137', 'pos_sit_pulling', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('139', 'chair_oldman_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('142', 'stn_liabilities_b_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('143', 'stn_fishing_male_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('144', 'chair_readbook_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('145', 'gnd_corpse_lastwill_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('146', 'stn_guitarist_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('147', 'chair_armrest_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('148', 'stn_crossarm_blackguard_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('149', 'stn_crossarm_blackguard_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('150', 'stn_cleaning_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('151', 'sit_chair_stump_crossleg_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('152', 'stn_stumble_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('153', 'chair_aptchair_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('154', 'chair_crossleg_aptchair_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('155', 'chair_crossleg_elf_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('156', 'chair_crossleg_elf_02_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('157', 'chair_armrest_oscar_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('158', 'sit_netting_male(net)', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('159', 'chair_armrest_b_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('160', 'stn_onehand_ax01_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('161', 'stn_onehand_ax01_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('162', 'stn_onehand_trowel01_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('163', 'stn_onehand_trowel01_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('164', 'stn_onehand_relaxed_blade_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('165', 'stn_onehand_relaxed_blade_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('166', 'fist_pos_stn_onehand_bow_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('167', 'fist_pos_stn_onehand_bow_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('168', 'stn_sprinklewater_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('169', 'stn_sprinklewater_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('170', 'stn_get_fruit_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('171', 'stn_get_fruit_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('172', 'sit_feeding_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('173', 'sit_feeding_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('174', 'stn_act_stabler_male_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('175', 'stn_cleaning_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('176', 'stn_florist_female_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('177', 'stn_liabilities_c_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('179', 'stn_liabilities_d_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('180', 'stn_onehand_relaxed_lamp_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('181', 'stn_onehand_relaxed_lamp_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('182', 'stn_shy_kid', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('183', 'stn_distract_kid', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('184', 'stn_distract_kid_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('185', 'stn_crying_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('186', 'stn_onehand_relaxed_pipe_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('187', 'stn_onehand_relaxed_pipe_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('188', 'sit_chiar_kid', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('189', 'stn_anvil_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('190', 'stn_liabilities_b_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('191', 'stn_liabilities_c_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('192', 'stn_liabilities_d_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('193', 'sit_wounded_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('194', 'stn_tod_set_male_01', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('195', 'chair_crossleg_elf_03_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('196', 'stn_tod_set_female_02', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('197', 'stn_tod_set_all_03', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('198', 'fist_pos_gnd_corpse_lastwill_talking_test', '201', '');
INSERT INTO `npc_posture_sets` VALUES ('199', 'stn_onehand_relaxed_dagger_all', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('200', 'stn_ax_all_notalk', '97', '장작패기');
INSERT INTO `npc_posture_sets` VALUES ('201', 'chair_readbook_male(conductor)', '0', '원정대관리인');
INSERT INTO `npc_posture_sets` VALUES ('202', 'pos_sit_pulling_plants_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('203', 'pos_sit_pulling_plants_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('204', 'sit_investigation_plants_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('205', 'sit_investigation_plants_male_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('206', 'chair_rest_all(higness)', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('207', 'stn_soldier_axe2_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('208', 'stn_search_cough_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('209', 'stn_priest_resurrection', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('210', 'stn_Honor_male', '0', '명예 점수 수집가');
INSERT INTO `npc_posture_sets` VALUES ('211', 'stn_soldier_ferre_female_2', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('212', 'stn_ax_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('213', 'chair_straightleg2_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('214', 'chair_stump_oldman_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('215', 'stn_eatsuop_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('216', 'chair_eatsuop_all', '204', '');
INSERT INTO `npc_posture_sets` VALUES ('217', 'stn_bored_all', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('218', 'stn_backpain_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('219', 'stn_guitarist_b_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('220', 'stn_shoveling_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('221', 'stn_onehand_relaxed_guitar_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('222', 'stn_onehand_relaxed_guitar_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('223', 'stn_guitarist_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('224', 'crouch_livestock_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('225', 'crouch_furniturerepair_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('226', 'stn_drink_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('227', 'chair_drink_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('228', 'stn_Honor_male_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('229', 'stn_commander_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('230', 'stn_soldier_sword_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('231', 'stn_anvil_all_test', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('232', 'stn_anvil_dwaf', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('233', 'stn_concierge_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('234', 'stn_ac_mine_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('235', 'stn_keeperflag_male', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('237', 'chair01_drink_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('239', 'sit_corch_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('240', 'chair_red_female', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('241', 'stn_cooking_all', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('242', 'stn_dance_all', '0', '댄스 \'밤의 열기\'');
INSERT INTO `npc_posture_sets` VALUES ('243', 'stn_dance2_all', '0', '댄스 \'전쟁의 예고\'');
INSERT INTO `npc_posture_sets` VALUES ('244', 'stn_tod_set_all_04', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('245', 'stn_onehand_ladle_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('246', 'stn_onehand_ladle_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('247', 'chair_drink_all(test)', '0', '스마트 오브젝트 테스트');
INSERT INTO `npc_posture_sets` VALUES ('248', 'chair_drink_all(soc_test)', '0', '스마트 오브젝트 테스트 2');
INSERT INTO `npc_posture_sets` VALUES ('249', 'chair02_drink_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('250', 'fishing_idle_all', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('251', 'fishing_action_all', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('252', 'stn_drink_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('253', 'stn_eatsuop_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('254', 'stn_onehand_relaxed_cane_all', '0', '');
INSERT INTO `npc_posture_sets` VALUES ('255', 'stn_onehand_relaxed_cane_all_notalk', '97', '');
INSERT INTO `npc_posture_sets` VALUES ('256', 'daru_warehousekeeper_notalk', '97', '다루 창고 관리인');
INSERT INTO `npc_posture_sets` VALUES ('257', 'daru_traders_notalk', '97', '다루 교역상');
INSERT INTO `npc_posture_sets` VALUES ('258', 'daru_pilot_notalk', '97', '순환 마차 관리인, 비행선 안내인');
INSERT INTO `npc_posture_sets` VALUES ('259', 'daru_auctioneer_notalk', '97', '경매장 관리인, 신기루섬 안내인');
INSERT INTO `npc_posture_sets` VALUES ('260', 'stn_anvil_dw_male', '0', '드워프 대장장이');
INSERT INTO `npc_posture_sets` VALUES ('263', 'sit_beggar_notalk', '97', '');
SET FOREIGN_KEY_CHECKS=1;
