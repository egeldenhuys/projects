<html>
<body>
<head>
<title>
IP Tracking
</title>
</head>

<?php
$action = $_POST["action"];

switch($action)
{
case 'Clear IPs':
    ClearIps('ips.txt');
	break;

case 'Clear Archive':
	ClearIps('Archive.txt');
	break;
	
case 'Add to Archive':
	$archive = fopen("Archive.txt", "a") or exit("Could not open archive.txt");
	$file = fopen("ips.txt", "r") or exit("Could not open ips.txt");

	while(!feof($file))
		{
		fwrite($archive, fgets($file));
		}
	fclose($archive);
	fclose($file);

	ClearIps('ips.txt');
	break;
	
case 'View Archive':
	echo '<form action="view_ips.php" method="post">';
	echo '<input type="submit" name="action" value="Back" />';
	echo '<input type="submit" name="action" value="Clear Archive" />';
    echo '</form>';
	
	DisplayIps("Archive.txt");
	break;

case 'Refresh':
	$page = $_SERVER['PHP_SELF'];
	header("url={$page}");
	
default:
	DisplayButtons();
	DisplayIps("ips.txt");
	break;
}

function ClearIps($fileName)
{
	$file = fopen($fileName, "w") or exit("Unable to open file!");
    fwrite($file,"");
    fclose($file);
	
    DisplayButtons();
	DisplayIps('ips.txt');
}

function DisplayButtons()
{
    echo '<form action="view_ips.php" method="post">';
    echo '<input type="submit" name="action" value="Clear IPs" />';
    echo '<input type="submit" name="action" value="Add to Archive" />';
	echo '<input type="submit" name="action" value="View Archive" />';
	echo '<input type="submit" name="action" value="Refresh" />';
    echo '</form>';
}

Function DisplayIps($fileName)
{
if (file_exists($fileName))
	{
		$file = fopen($fileName, "r") or exit("Error opening " . $fileName);
		//Output a line of the file until the end is reached
		$firstLine = fgets($file);
		
		if ($firstLine == "")
			echo 'There are no IPs to display.';
		else
			echo $firstLine . "<br />";

		while(!feof($file))
			{
			echo fgets($file) . "<br />";
			}

		fclose($file); 
	}
else
	echo 'Could not find ' . $fileName;	
}
?>

</body>
</html>