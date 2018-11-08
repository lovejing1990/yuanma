/*
Navicat MySQL Data Transfer

Source Server         : AAEmu
Source Server Version : 80011
Source Host           : localhost:3306
Source Database       : archeage_world

Target Server Type    : MYSQL
Target Server Version : 80011
File Encoding         : 65001

Date: 2018-10-10 12:29:56
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for npc_nicknames
-- ----------------------------
DROP TABLE IF EXISTS `npc_nicknames`;
CREATE TABLE `npc_nicknames` (
  `id` int(8) NOT NULL,
  `name` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_unicode_ci; 

-- ----------------------------
-- Records of npc_nicknames
-- ----------------------------
INSERT INTO `npc_nicknames` VALUES ('0', 'none');
INSERT INTO `npc_nicknames` VALUES ('1', 'Оружие');
INSERT INTO `npc_nicknames` VALUES ('2', 'Доспехи');
INSERT INTO `npc_nicknames` VALUES ('3', 'Полезные мелочи');
INSERT INTO `npc_nicknames` VALUES ('4', 'Аукцион Содорви в королевстве Полумесяца');
INSERT INTO `npc_nicknames` VALUES ('5', 'Торговец рецептами (планируется удалить)');
INSERT INTO `npc_nicknames` VALUES ('6', 'Торговец усилениями (планируется удалить)');
INSERT INTO `npc_nicknames` VALUES ('7', 'Повар');
INSERT INTO `npc_nicknames` VALUES ('8', 'Лекарь');
INSERT INTO `npc_nicknames` VALUES ('9', 'Агент Миража');
INSERT INTO `npc_nicknames` VALUES ('10', 'Мебель');
INSERT INTO `npc_nicknames` VALUES ('11', 'Саженцы');
INSERT INTO `npc_nicknames` VALUES ('12', 'Ремесленные материалы');
INSERT INTO `npc_nicknames` VALUES ('13', 'Галантерейщик (сменить на nickname 3, планируется удалить)');
INSERT INTO `npc_nicknames` VALUES ('14', 'Закройщица');
INSERT INTO `npc_nicknames` VALUES ('15', 'Торговец инструментами');
INSERT INTO `npc_nicknames` VALUES ('16', 'Торговец судами');
INSERT INTO `npc_nicknames` VALUES ('17', 'Смотритель стойла');
INSERT INTO `npc_nicknames` VALUES ('18', 'Орден Двенадцати');
INSERT INTO `npc_nicknames` VALUES ('19', 'Инструктор боевых навыков (планируется удалить)');
INSERT INTO `npc_nicknames` VALUES ('20', 'Инженер осады');
INSERT INTO `npc_nicknames` VALUES ('21', 'Торговец кораблями G-star (планируется удалить)');
INSERT INTO `npc_nicknames` VALUES ('22', 'Станционный смотритель');
INSERT INTO `npc_nicknames` VALUES ('23', 'Станционный смотритель');
INSERT INTO `npc_nicknames` VALUES ('24', 'Воскрешение');
INSERT INTO `npc_nicknames` VALUES ('25', 'Смотритель вышки');
INSERT INTO `npc_nicknames` VALUES ('26', 'Торговец амулетами');
INSERT INTO `npc_nicknames` VALUES ('27', 'Склад');
INSERT INTO `npc_nicknames` VALUES ('28', 'Регистрация гильдий');
INSERT INTO `npc_nicknames` VALUES ('29', 'Союз Нуи');
INSERT INTO `npc_nicknames` VALUES ('30', 'Харнийская империя');
INSERT INTO `npc_nicknames` VALUES ('31', 'Скот');
INSERT INTO `npc_nicknames` VALUES ('32', 'Торговец деревьями (не используется)');
INSERT INTO `npc_nicknames` VALUES ('33', 'Вербовщик арены');
INSERT INTO `npc_nicknames` VALUES ('34', 'Аукцион');
INSERT INTO `npc_nicknames` VALUES ('35', 'Регистрация пиратских гильдий');
INSERT INTO `npc_nicknames` VALUES ('36', 'Управляющий территорией');
INSERT INTO `npc_nicknames` VALUES ('37', 'Семена');
INSERT INTO `npc_nicknames` VALUES ('38', 'Контрабандист');
INSERT INTO `npc_nicknames` VALUES ('39', 'Скупка товаров');
INSERT INTO `npc_nicknames` VALUES ('40', 'Нейтральные войска');
INSERT INTO `npc_nicknames` VALUES ('41', 'Торговец слезами Нуи');
INSERT INTO `npc_nicknames` VALUES ('42', 'Дельфийские звезды');
INSERT INTO `npc_nicknames` VALUES ('43', 'Пиротехника');
INSERT INTO `npc_nicknames` VALUES ('44', 'Кузнец');
INSERT INTO `npc_nicknames` VALUES ('45', 'Странствующий торговец');
INSERT INTO `npc_nicknames` VALUES ('46', 'Консорциум Синей Соли');
INSERT INTO `npc_nicknames` VALUES ('47', 'Союз Белой соли');
INSERT INTO `npc_nicknames` VALUES ('48', 'Обменный пункт');
INSERT INTO `npc_nicknames` VALUES ('49', 'Общественная ферма');
INSERT INTO `npc_nicknames` VALUES ('50', 'Управляющий территорией Сальфимар');
INSERT INTO `npc_nicknames` VALUES ('51', 'Управляющий территорией Нуимар');
INSERT INTO `npc_nicknames` VALUES ('52', 'Управляющий территорией Сонекмари');
INSERT INTO `npc_nicknames` VALUES ('53', 'Управляющий территорией Земли Покоя');
INSERT INTO `npc_nicknames` VALUES ('54', 'Добродетель империи');
INSERT INTO `npc_nicknames` VALUES ('55', 'Доброволец Меркурия Сальфимар');
INSERT INTO `npc_nicknames` VALUES ('56', 'Доброволец Меркурия Нуимар');
INSERT INTO `npc_nicknames` VALUES ('57', 'Доброволец Меркурия Сокенмари');
INSERT INTO `npc_nicknames` VALUES ('58', 'Доброволец Меркурия Земли Покоя');
INSERT INTO `npc_nicknames` VALUES ('59', 'Доброволец осады Сальфимар');
INSERT INTO `npc_nicknames` VALUES ('60', 'Доброволец осады Нуимар');
INSERT INTO `npc_nicknames` VALUES ('61', 'Доброволец осады Сокенмари');
INSERT INTO `npc_nicknames` VALUES ('62', 'Доброволец осады Земли Покоя');
INSERT INTO `npc_nicknames` VALUES ('63', 'Репетитор восточных языков');
INSERT INTO `npc_nicknames` VALUES ('64', 'Репетитор западных языков');
INSERT INTO `npc_nicknames` VALUES ('65', 'Ночная рассказчица');
INSERT INTO `npc_nicknames` VALUES ('66', 'Учитель');
INSERT INTO `npc_nicknames` VALUES ('68', 'Управляющий территорией Входа в бездну');
INSERT INTO `npc_nicknames` VALUES ('69', 'Доброволец обороны Входа в бездну');
INSERT INTO `npc_nicknames` VALUES ('70', 'Доброволец осады Входа в бездну');
INSERT INTO `npc_nicknames` VALUES ('71', 'Управляющий территорией Солнечного поля');
INSERT INTO `npc_nicknames` VALUES ('72', 'Доброволец обороны Солнечного поля');
INSERT INTO `npc_nicknames` VALUES ('73', 'Доброволец осады Солнечного поля');
INSERT INTO `npc_nicknames` VALUES ('74', 'Красная армия');
INSERT INTO `npc_nicknames` VALUES ('75', 'Синяя армия');
INSERT INTO `npc_nicknames` VALUES ('76', 'Заводчик питомцев');
INSERT INTO `npc_nicknames` VALUES ('77', 'Дельфийские реликвии');
INSERT INTO `npc_nicknames` VALUES ('78', 'Собиратель ярлыков');
INSERT INTO `npc_nicknames` VALUES ('79', 'Работник салона');
INSERT INTO `npc_nicknames` VALUES ('80', 'Продавец костюмов');
INSERT INTO `npc_nicknames` VALUES ('81', 'Заядлый рыбак');
SET FOREIGN_KEY_CHECKS=1;
