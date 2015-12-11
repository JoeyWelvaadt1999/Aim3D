<?php 
	include 'connect.php';

	$posx = $_POST['PositionX'];
	$posy = $_POST['PositionY'];
	$posz = $_POST['PositionZ'];
	
	mysql_query("INSERT INTO PlayerPosition (`ID`, `X`, `Y`, `Z`) VALUES ('','$posx', '$posy', '$posz') ");
?>