/*
Navicat MySQL Data Transfer

Source Server         : MySql
Source Server Version : 50505
Source Host           : 127.0.0.1:3306
Source Database       : graduation

Target Server Type    : MYSQL
Target Server Version : 50505
File Encoding         : 65001

Date: 2017-06-03 23:09:02
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for address
-- ----------------------------
DROP TABLE IF EXISTS `address`;
CREATE TABLE `address` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `address` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of address
-- ----------------------------

-- ----------------------------
-- Table structure for categories
-- ----------------------------
DROP TABLE IF EXISTS `categories`;
CREATE TABLE `categories` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `category` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of categories
-- ----------------------------

-- ----------------------------
-- Table structure for citizens
-- ----------------------------
DROP TABLE IF EXISTS `citizens`;
CREATE TABLE `citizens` (
  `id` varchar(9) CHARACTER SET ascii NOT NULL,
  `full_name` varchar(255) NOT NULL,
  `birthdate` date NOT NULL,
  `age` int(11) NOT NULL,
  `address_id` int(10) unsigned NOT NULL,
  `street` varchar(50) NOT NULL,
  `pobox` varchar(50) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `citizen_address` (`address_id`),
  CONSTRAINT `citizen_address` FOREIGN KEY (`address_id`) REFERENCES `address` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of citizens
-- ----------------------------

-- ----------------------------
-- Table structure for denied_log
-- ----------------------------
DROP TABLE IF EXISTS `denied_log`;
CREATE TABLE `denied_log` (
  `sid` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL,
  `file_id` int(10) unsigned NOT NULL,
  `time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`sid`),
  KEY `file_denied_log` (`file_id`),
  KEY `users_denied_log` (`user_id`),
  CONSTRAINT `file_denied_log` FOREIGN KEY (`file_id`) REFERENCES `files` (`id`),
  CONSTRAINT `users_denied_log` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of denied_log
-- ----------------------------

-- ----------------------------
-- Table structure for edit_log
-- ----------------------------
DROP TABLE IF EXISTS `edit_log`;
CREATE TABLE `edit_log` (
  `sid` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL,
  `file_id` int(10) unsigned NOT NULL,
  `old_data` varchar(1000) NOT NULL,
  `new_data` varchar(1000) NOT NULL,
  PRIMARY KEY (`sid`),
  KEY `user_edit_log` (`user_id`),
  KEY `file_edit_log` (`file_id`),
  CONSTRAINT `file_edit_log` FOREIGN KEY (`file_id`) REFERENCES `files` (`id`),
  CONSTRAINT `user_edit_log` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of edit_log
-- ----------------------------

-- ----------------------------
-- Table structure for files
-- ----------------------------
DROP TABLE IF EXISTS `files`;
CREATE TABLE `files` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `file_name` varchar(255) NOT NULL,
  `category_id` int(10) unsigned NOT NULL,
  `position_id` int(10) unsigned NOT NULL,
  `see_permission` tinyint(3) unsigned NOT NULL DEFAULT '101',
  `edit_permission` tinyint(3) unsigned DEFAULT '101',
  `state` tinyint(1) NOT NULL,
  `desc` varchar(255) NOT NULL DEFAULT 'There is no Description Avalaible',
  `user_id` int(10) unsigned NOT NULL,
  `added_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `deleted` char(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `position_id` (`position_id`),
  KEY `category_file` (`category_id`),
  KEY `user_file` (`user_id`),
  CONSTRAINT `category_file` FOREIGN KEY (`category_id`) REFERENCES `categories` (`id`),
  CONSTRAINT `position_file` FOREIGN KEY (`position_id`) REFERENCES `positions` (`id`),
  CONSTRAINT `user_file` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of files
-- ----------------------------

-- ----------------------------
-- Table structure for log
-- ----------------------------
DROP TABLE IF EXISTS `log`;
CREATE TABLE `log` (
  `sid` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `file_id` int(10) unsigned NOT NULL,
  `user_id` int(10) unsigned NOT NULL,
  `time` datetime NOT NULL,
  `action` varchar(10) NOT NULL,
  PRIMARY KEY (`sid`),
  KEY `file_log` (`file_id`),
  KEY `users_log` (`user_id`),
  CONSTRAINT `file_log` FOREIGN KEY (`file_id`) REFERENCES `files` (`id`),
  CONSTRAINT `users_log` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of log
-- ----------------------------

-- ----------------------------
-- Table structure for login_log
-- ----------------------------
DROP TABLE IF EXISTS `login_log`;
CREATE TABLE `login_log` (
  `sid` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `user_id` int(10) unsigned NOT NULL,
  `login_time` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `logout_time` datetime DEFAULT NULL,
  PRIMARY KEY (`sid`),
  KEY `users_login_log` (`user_id`),
  CONSTRAINT `users_login_log` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of login_log
-- ----------------------------

-- ----------------------------
-- Table structure for participans
-- ----------------------------
DROP TABLE IF EXISTS `participans`;
CREATE TABLE `participans` (
  `file_id` int(10) unsigned NOT NULL,
  `citized_id` varchar(9) CHARACTER SET ascii NOT NULL,
  `role` varchar(30) NOT NULL,
  KEY `part_file` (`file_id`),
  KEY `part_citizen` (`citized_id`),
  CONSTRAINT `part_citizen` FOREIGN KEY (`citized_id`) REFERENCES `citizens` (`id`),
  CONSTRAINT `part_file` FOREIGN KEY (`file_id`) REFERENCES `files` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of participans
-- ----------------------------

-- ----------------------------
-- Table structure for positions
-- ----------------------------
DROP TABLE IF EXISTS `positions`;
CREATE TABLE `positions` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `x` int(11) NOT NULL,
  `y` int(11) NOT NULL,
  `state` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of positions
-- ----------------------------

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(100) CHARACTER SET ascii NOT NULL,
  `password` varchar(40) CHARACTER SET ascii NOT NULL,
  `email` varchar(100) NOT NULL,
  `admin` char(1) NOT NULL DEFAULT '0',
  `permission` smallint(6) NOT NULL DEFAULT '0',
  `card_id` varchar(9) NOT NULL,
  `birthdate` date NOT NULL,
  `address_id` int(10) unsigned NOT NULL,
  `enabled` char(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE KEY `uni` (`card_id`),
  KEY `users_address` (`address_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES ('1', 'SohaybSaleh', 'e10adc3949ba59abbe56e057f20f883e', 'sohaybsaleh95@gmail.com', '0', '100', '111111111', '1995-12-18', '1', '1');
INSERT INTO `users` VALUES ('2', 'AyaJabir', 'e10adc3949ba59abbe56e057f20f883e', 'sohaybsaleh95@gmail.com', '0', '100', '222222222', '1995-12-18', '1', '1');
INSERT INTO `users` VALUES ('3', 'RaghadNoman', 'e10adc3949ba59abbe56e057f20f883e', 'sohaybsaleh95@gmail.com', '0', '100', '333333333', '1995-12-18', '1', '1');
INSERT INTO `users` VALUES ('4', 'admin', 'e10adc3949ba59abbe56e057f20f883e', 'sohaybsaleh95@gmail.com', '1', '100', '444444444', '1995-12-18', '1', '1');
