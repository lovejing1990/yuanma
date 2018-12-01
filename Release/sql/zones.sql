/*
Navicat MySQL Data Transfer

Source Server         : aaemu
Source Server Version : 80012
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80012
File Encoding         : 65001

Date: 2018-10-22 00:39:18
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for zones
-- ----------------------------
DROP TABLE IF EXISTS `zones`;
CREATE TABLE `zones` (
  `id` int(8) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  `zone_key` int(8) DEFAULT NULL,
  `group_id` int(8) DEFAULT NULL,
  `closed` int(1) DEFAULT NULL,
  `display_text` varchar(255) DEFAULT NULL,
  `faction_id` int(8) DEFAULT NULL,
  `zone_climate_id` int(8) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci;

-- ----------------------------
-- Records of zones
-- ----------------------------
INSERT INTO `zones` VALUES ('1', 'w_gweonid_forest_1', '129', '1', '1', 'Лес Гвинедар', '148', '2');
INSERT INTO `zones` VALUES ('2', 'w_marianople_1', '133', '2', '1', 'Мэрианхольд', '148', '2');
INSERT INTO `zones` VALUES ('3', 'e_steppe_belt_1', '136', '14', '0', 'Саванна', null, '5');
INSERT INTO `zones` VALUES ('4', 'e_ruins_of_hariharalaya_1', '137', '15', '0', 'Руины Харихараллы', null, '3');
INSERT INTO `zones` VALUES ('5', 'e_lokas_checkers_1', '138', '16', '0', 'Рокочущие перевалы', null, '2');
INSERT INTO `zones` VALUES ('6', 'e_ynystere_1', '139', '17', '1', 'Инистра', null, '2');
INSERT INTO `zones` VALUES ('7', 'w_garangdol_plains_1', '140', '3', '1', 'Земля Говорящих Камней', '148', '2');
INSERT INTO `zones` VALUES ('8', 'e_sunrise_peninsula_1', '141', '4', '1', 'Полуостров Рассвета', '149', '5');
INSERT INTO `zones` VALUES ('9', 'w_solzreed_1', '142', '5', '1', 'Полуостров Солрид', '148', '2');
INSERT INTO `zones` VALUES ('10', 'w_white_forest_1', '143', '18', '1', 'Белый лес', '148', '2');
INSERT INTO `zones` VALUES ('11', 'w_lilyut_meadow_1', '144', '6', '1', 'Холмы Лилиот', '148', '2');
INSERT INTO `zones` VALUES ('12', 'w_the_carcass_1', '145', '19', '0', 'Кладбище драконов', null, '4');
INSERT INTO `zones` VALUES ('13', 'e_rainbow_field_1', '146', '7', '0', 'Радужные пески', '149', '5');
INSERT INTO `zones` VALUES ('14', 'w_cross_plains_1', '148', '20', '1', 'Полуостров Падающих Звезд', null, '2');
INSERT INTO `zones` VALUES ('15', 'w_two_crowns_1', '149', '8', '1', 'Две Короны', '148', '2');
INSERT INTO `zones` VALUES ('16', 'w_cradle_of_genesis', '150', '21', '0', 'Колыбель бытия', '148', '2');
INSERT INTO `zones` VALUES ('17', 'w_golden_plains_1', '151', '22', '1', 'Золотые равнины', null, '2');
INSERT INTO `zones` VALUES ('18', 'e_mahadevi_1', '153', '9', '1', 'Махадеби', '149', '3');
INSERT INTO `zones` VALUES ('19', 'w_bronze_rock_1', '154', '10', '0', 'Бронзовая скала', '148', '4');
INSERT INTO `zones` VALUES ('20', 'e_hasla_1', '155', '23', '0', 'Хазира', null, '2');
INSERT INTO `zones` VALUES ('21', 'e_falcony_plateau_1', '156', '11', '1', 'Плато Соколиной Охоты', '149', '2');
INSERT INTO `zones` VALUES ('22', 'e_sunny_wilderness_1', '157', '13', '0', 'Пустыня Жгучего Солнца', '149', '5');
INSERT INTO `zones` VALUES ('23', 'e_tiger_spine_mountains_1', '158', '24', '1', 'Тигриный хребет', '149', '2');
INSERT INTO `zones` VALUES ('24', 'e_ancient_forest', '159', '25', '1', 'Древний лес', '149', '2');
INSERT INTO `zones` VALUES ('25', 'e_singing_land_1', '160', '12', '1', 'Поющая земля', '149', '2');
INSERT INTO `zones` VALUES ('26', 'w_hell_swamp_1', '161', '26', '1', 'Заболоченные низины', null, '3');
INSERT INTO `zones` VALUES ('27', 'w_long_sand_1', '162', '27', '0', 'Долгая коса', null, '3');
INSERT INTO `zones` VALUES ('28', 'w_barren_land', '164', '28', '0', 'Покинутые земли', null, '0');
INSERT INTO `zones` VALUES ('29', 's_lost_island', '172', '30', '1', 'Море Забвения', null, '2');
INSERT INTO `zones` VALUES ('30', 's_lostway_sea', '173', '30', '1', 'Море Забвения', null, '2');
INSERT INTO `zones` VALUES ('31', 'login', '0', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('32', 'siegefield', '2', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('33', 'npc_single', '3', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('34', 'cbsuh_nonpc', '4', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('35', 'old_w_garangdol', '21', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('36', 'old_w_marianople', '22', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('37', 'old_w_solzreed', '23', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('38', 'old_w_two_crowns', '24', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('39', 'old_w_cross_plains', '25', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('40', 'old_w_white_forest', '29', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('41', 'old_w_gold_moss', '30', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('42', 'old_w_longsand', '31', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('43', 'old_w_gold_plains', '32', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('44', 'old_w_cradle_genesis', '33', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('45', 'old_w_bronze_rock', '34', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('46', 'old_w_hanuimaru', '35', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('47', 'old_w_nameless_canyon', '36', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('48', 'old_w_gweoniod_forest', '37', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('49', 'old_w_lilyut_mea', '38', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('50', 'old_w_carcass', '39', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('51', 'old_w_hell_swamp', '40', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('52', 'old_w_death_mt', '41', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('53', 'old_w_twist_coast', '42', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('54', 'old_w_tornado_mea', '43', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('55', 'old_w_dark_moon', '44', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('56', 'old_w_firefly_pen', '45', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('57', 'old_w_frozen_top', '46', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('58', 'old_w_mirror_kingdom', '47', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('59', 'ocean_level', '72', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('60', 'old_e_black_desert', '73', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('61', 'old_e_laveda', '74', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('62', 'old_e_desert_of_fossils', '75', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('63', 'old_e_sunny_wilderness', '76', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('64', 'old_e_volcanic_shore', '77', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('65', 'old_e_sylvina_volcanic_region', '78', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('66', 'old_e_hasla', '79', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('67', 'old_e_ruins_of_hariharalaya', '80', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('68', 'old_e_steppe_belt', '81', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('69', 'old_e_rainbow_field', '82', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('70', 'old_e_lokaloka_mt_south', '83', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('71', 'old_e_lokaloka_mt_north', '84', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('72', 'old_e_return_land', '85', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('73', 'old_e_loca_checkers', '86', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('74', 'old_e_night_velley', '87', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('75', 'old_e_una_basin', '88', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('76', 'old_e_ancient_forest', '89', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('77', 'old_e_ynystere', '90', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('78', 'old_e_sing_land', '91', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('79', 'old_e_falcony_plateau', '92', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('80', 'old_e_tiger_mt', '93', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('81', 'old_e_mahadevi', '94', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('82', 'old_e_sunrise_pen', '95', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('83', 'old_e_white_island', '96', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('84', 'old_w_ynys_island', '97', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('85', 'old_w_wandering_island', '98', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('86', 'origin', '99', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('87', 'model_room', '100', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('88', 'worldlevel8x8', '101', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('89', 'world8x8_noone', '102', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('90', 'module_object_update', '104', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('91', 'module_hightmap_update', '105', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('92', 'npc_brave', '108', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('93', 'background_lod', '117', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('94', 'main_world_0_0', '118', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('95', 'main_world_1_0', '119', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('96', 'main_world_2_0', '120', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('97', 'main_world_0_1', '121', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('98', 'main_world_1_1', '122', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('99', 'main_world_2_1', '123', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('100', 'main_world_0_2', '124', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('101', 'main_world_1_2', '125', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('102', 'main_world_2_2', '126', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('103', 'main_world_rain_bow', '127', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('104', 'main_world_tiger', '128', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('105', 'main_world_two_crowns', '130', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('106', 'main_world_3_0', '131', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('107', 'main_world_bone', '132', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('108', 'instance_silent_colossus', '134', '32', '0', 'Ущелье Спящего', null, '0');
INSERT INTO `zones` VALUES ('109', 'main_world_rough_ynystere', '135', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('110', 'sound_test', '147', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('111', '3d_environment_object', '152', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('112', 'test_w_gweonid_forest', '163', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('113', 'machinima_w_solzreed', '165', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('114', 'npc_test', '166', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('115', '3d_natural_object', '167', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('116', 'machinima_w_gweonid_forest', '168', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('117', 'machinima_w_garangdol_plains', '169', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('118', 'machinima_w_bronze_rock', '170', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('119', 'sumday_nonpc', '171', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('120', 'gstar2010', '174', null, '0', 'G-Star 2010', null, '0');
INSERT INTO `zones` VALUES ('121', 'chls_model_room', '175', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('122', 's_zman_nonpc', '176', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('123', 'loginbg2', '177', null, '1', '', null, '0');
INSERT INTO `zones` VALUES ('124', 'w_solzreed_2', '178', '5', '1', 'Полуостров Солрид', '148', '2');
INSERT INTO `zones` VALUES ('125', 'w_solzreed_3', '179', '5', '1', 'Полуостров Солрид', '148', '2');
INSERT INTO `zones` VALUES ('126', 's_silent_sea_7', '180', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('127', 'w_gweonid_forest_2', '181', '1', '1', 'Лес Гвинедар', '148', '2');
INSERT INTO `zones` VALUES ('128', 'w_gweonid_forest_3', '182', '1', '1', 'Лес Гвинедар', '148', '2');
INSERT INTO `zones` VALUES ('129', 'w_marianople_2', '183', '2', '1', 'Мэрианхольд', '148', '2');
INSERT INTO `zones` VALUES ('130', 'e_falcony_plateau_2', '184', '11', '1', 'Плато Соколиной Охоты', '149', '2');
INSERT INTO `zones` VALUES ('131', 'w_garangdol_plains_2', '185', '3', '1', 'Земля Говорящих Камней', '148', '2');
INSERT INTO `zones` VALUES ('132', 'w_two_crowns_2', '186', '8', '1', 'Две Короны', '148', '2');
INSERT INTO `zones` VALUES ('133', 'e_rainbow_field_2', '187', '7', '1', 'Радужные пески', '149', '5');
INSERT INTO `zones` VALUES ('134', 'e_rainbow_field_3', '188', '7', '1', 'Радужные пески', '149', '5');
INSERT INTO `zones` VALUES ('135', 'e_rainbow_field_4', '189', '7', '1', 'Радужные пески', '149', '5');
INSERT INTO `zones` VALUES ('136', 'e_sunny_wilderness_2', '190', '13', '0', 'Пустыня Жгучего Солнца', '149', '5');
INSERT INTO `zones` VALUES ('137', 'e_sunrise_peninsula_2', '191', '4', '1', 'Полуостров Рассвета', '149', '5');
INSERT INTO `zones` VALUES ('138', 'w_bronze_rock_2', '192', '10', '0', 'Бронзовая скала', '148', '4');
INSERT INTO `zones` VALUES ('139', 'w_bronze_rock_3', '193', '10', '0', 'Бронзовая скала', '148', '4');
INSERT INTO `zones` VALUES ('140', 'e_singing_land_2', '194', '12', '1', 'Поющая земля', '149', '2');
INSERT INTO `zones` VALUES ('141', 'w_lilyut_meadow_2', '195', '6', '1', 'Холмы Лилиот', '148', '2');
INSERT INTO `zones` VALUES ('142', 'e_mahadevi_2', '196', '9', '1', 'Махадеби', '149', '3');
INSERT INTO `zones` VALUES ('143', 'e_mahadevi_3', '197', '9', '1', 'Махадеби', '149', '3');
INSERT INTO `zones` VALUES ('144', 'instance_training_camp', '198', '31', '1', 'Тренировочный лагерь', null, '0');
INSERT INTO `zones` VALUES ('145', 'w_golden_plains_2', '206', '22', '1', 'Золотые равнины', null, '2');
INSERT INTO `zones` VALUES ('146', 'w_golden_plains_3', '207', '22', '1', 'Золотые равнины', null, '2');
INSERT INTO `zones` VALUES ('147', 'w_dark_side_of_the_moon', '209', null, '0', '', null, '0');
INSERT INTO `zones` VALUES ('148', 'o_salpimari', '204', '33', '0', 'Сальфимар', null, '6');
INSERT INTO `zones` VALUES ('149', 'o_nuimari', '205', '34', '0', 'Нуимар', null, '6');
INSERT INTO `zones` VALUES ('150', 's_silent_sea_1', '210', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('151', 's_silent_sea_2', '211', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('152', 's_silent_sea_3', '212', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('153', 's_silent_sea_4', '213', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('154', 's_silent_sea_5', '214', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('155', 's_silent_sea_6', '215', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('156', 'e_una_basin', '216', null, '0', '', null, '0');
INSERT INTO `zones` VALUES ('157', 's_nightmare_coast', '217', null, '0', '', null, '0');
INSERT INTO `zones` VALUES ('158', 's_golden_sea_1', '218', '39', '1', 'Золотое море', null, '3');
INSERT INTO `zones` VALUES ('159', 's_golden_sea_2', '219', '39', '1', 'Золотое море', null, '3');
INSERT INTO `zones` VALUES ('160', 's_crescent_sea', '221', '40', '1', 'Море Полумесяца', null, '2');
INSERT INTO `zones` VALUES ('161', 'lock_golden_sea', '226', '41', '0', 'Частная зона Золотого моря', null, '0');
INSERT INTO `zones` VALUES ('162', 'lock_left_side_of_silent_sea', '227', '41', '0', 'Западная частная зона Тихого моря', null, '0');
INSERT INTO `zones` VALUES ('163', 'lock_right_side_of_silent_sea_1', '228', '41', '0', 'Восточная частная зона Тихого моря', null, '0');
INSERT INTO `zones` VALUES ('164', 'lock_right_side_of_silent_sea_2', '229', '41', '0', 'Восточная частная зона Тихого моря', null, '0');
INSERT INTO `zones` VALUES ('165', 'lock_south_sunrise_peninsula', '225', '41', '0', 'Южная частная зона Рассвета', null, '0');
INSERT INTO `zones` VALUES ('166', 'o_seonyeokmari', '233', '43', '0', 'Сонекмар', null, '7');
INSERT INTO `zones` VALUES ('167', 'o_rest_land', '234', '44', '0', 'Земля Покоя', null, '7');
INSERT INTO `zones` VALUES ('168', 'instance_burntcastle_armory', '236', '45', '1', 'Арсенал Сожженной крепости', null, '0');
INSERT INTO `zones` VALUES ('169', 'instance_hadir_farm', '241', '46', '1', 'Ферма Хадира', null, '0');
INSERT INTO `zones` VALUES ('170', 'instance_sal_temple', '240', '47', '1', 'Подземелья Аль-Харбы', null, '0');
INSERT INTO `zones` VALUES ('171', 'w_hell_swamp_2', '248', '26', '1', 'Заболоченные низины', null, '3');
INSERT INTO `zones` VALUES ('172', 'e_steppe_belt_2', '247', '14', '0', 'Саванна', null, '5');
INSERT INTO `zones` VALUES ('173', 'e_lokas_checkers_2', '246', '16', '0', 'Рокочущие перевалы', null, '2');
INSERT INTO `zones` VALUES ('174', 'e_ruins_of_hariharalaya_2', '242', '15', '0', 'Руины Харихараллы', null, '3');
INSERT INTO `zones` VALUES ('175', 'e_ruins_of_hariharalaya_3', '243', '15', '0', 'Руины Харихараллы', null, '3');
INSERT INTO `zones` VALUES ('176', 'w_long_sand_2', '245', '27', '0', 'Долгая коса', null, '3');
INSERT INTO `zones` VALUES ('177', 'w_white_forest_2', '244', '18', '1', 'Белый лес', '148', '2');
INSERT INTO `zones` VALUES ('178', 'e_singing_land_3', '256', '12', '1', 'Поющая земля', '149', '2');
INSERT INTO `zones` VALUES ('179', 'e_tiger_spine_mountains_2', '258', '24', '1', 'Тигриный хребет', '149', '2');
INSERT INTO `zones` VALUES ('180', 'w_cross_plains_2', '257', '20', '1', 'Полуостров Падающих Звезд', null, '2');
INSERT INTO `zones` VALUES ('181', 'e_ynystere_2', '259', '17', '1', 'Инистра', null, '2');
INSERT INTO `zones` VALUES ('182', 'e_white_island', '261', '48', '0', 'Остров Белой Пены', '149', '4');
INSERT INTO `zones` VALUES ('183', 'arche_mall', '260', '49', '1', 'Мираж', null, '0');
INSERT INTO `zones` VALUES ('184', 'instance_cuttingwind_deadmine', '262', '50', '1', 'Копи Пронизывающего Ветра', null, '0');
INSERT INTO `zones` VALUES ('185', 'instance_howling_abyss', '265', '51', '0', 'Воющая бездна', null, null);
INSERT INTO `zones` VALUES ('186', 'instance_cradle_of_destruction', '264', '52', '0', 'Колыбель разрушений', null, null);
INSERT INTO `zones` VALUES ('187', 'w_the_carcass_2', '273', '19', '0', 'Кладбище драконов', null, '4');
INSERT INTO `zones` VALUES ('188', 'e_hasla_2', '272', '23', '0', 'Хазира', null, '2');
INSERT INTO `zones` VALUES ('189', 'instance_violent_maelstrom', '271', '53', '1', 'instance_violent_maelstrom', null, '0');
INSERT INTO `zones` VALUES ('190', 'e_hasla_3', '274', '23', '0', 'Хазира', null, '2');
INSERT INTO `zones` VALUES ('191', 'o_abyss_gate', '276', '54', '0', 'Вход в бездну', null, '8');
INSERT INTO `zones` VALUES ('192', 'instance_nachashgar', '278', '55', '0', 'Начашгар', null, null);
INSERT INTO `zones` VALUES ('193', 'o_land_of_sunlights', '275', '56', '0', 'Солнечное поле', null, '8');
INSERT INTO `zones` VALUES ('194', 'instance_howling_abyss_2', '280', '58', '0', 'Воющая бездна', null, null);
INSERT INTO `zones` VALUES ('195', 's_freedom_island', '283', '59', '1', 'Остров Свободы', null, '2');
INSERT INTO `zones` VALUES ('196', 's_pirate_island', '284', '60', '1', 'Море Бурь', null, '2');
INSERT INTO `zones` VALUES ('197', 'o_shining_shore', '282', '61', '0', 'Сияющий берег', null, null);
INSERT INTO `zones` VALUES ('198', 'o_ruins_of_gold', '281', '57', '0', 'Золотые руины', null, null);
INSERT INTO `zones` VALUES ('199', 'instance_immortal_isle', '285', '62', '0', 'Остров Вечности', null, null);
INSERT INTO `zones` VALUES ('200', 'o_the_great_reeds', '288', '63', '0', 'Земля Тростниковых Зарослей', null, '1');
INSERT INTO `zones` VALUES ('201', 's_silent_sea_8', '289', '36', '1', 'Безмятежное море', null, '2');
INSERT INTO `zones` VALUES ('202', 'instance_immortal_isle_easy', '290', '64', '1', '[Выходное подземелье] Остров Вечности', null, null);
INSERT INTO `zones` VALUES ('203', 'instance_the_liblary_1', '9999', '65', '0', '1-й район Великой библиотеки', null, null);
INSERT INTO `zones` VALUES ('204', 'instance_nachashgar_easy', '292', '66', '1', 'Изменчивый Начашгар', null, null);
INSERT INTO `zones` VALUES ('205', 'o_library_1', '293', '67', '1', 'Великая библиотека', null, null);
SET FOREIGN_KEY_CHECKS=1;
