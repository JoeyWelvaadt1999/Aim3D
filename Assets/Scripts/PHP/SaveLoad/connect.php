<?php 
	if(!defined("MYSQL_HOST")) define("MYSQL_HOST", "localhost");
	if(!defined("MYSQL_USERNAME")) define("MYSQL_USERNAME", "joeyw38_joey");
	if(!defined("MYSQL_PASSWORD")) define("MYSQL_PASSWORD", "cqqogh2t");
	if(!defined("MYSQL_DATABASE")) define("MYSQL_DATABASE", "joeyw38_aim3d");
	
	mysql_connect(MYSQL_HOST, MYSQL_USERNAME, MYSQL_PASSWORD, MYSQL_DATABASE) or die ("Couldn't connect to host!");
	mysql_select_db(MYSQL_DATABASE) or die ("Couldn't find database");
?>