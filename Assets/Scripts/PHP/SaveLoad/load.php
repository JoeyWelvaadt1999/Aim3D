<?php
	include 'connect.php';
	$result = mysql_query("SELECT * FROM PlayerPosition ORDER BY ID DESC LIMIT 1");
	$txt = "";
	while($row = mysql_fetch_array($result)) {
		$txt .= $row['X'];
		$txt .= "\n";
		$txt .= $row['Y'];
		$txt .= "\n";
		$txt .= $row['Z'];
	}
	
	echo $txt;
?>