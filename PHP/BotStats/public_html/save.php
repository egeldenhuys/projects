<?php
$name = $_GET['name'];
$lastUpdate = $_GET['lastupdate'];
$status = $_GET['status'];
$runTime = $_GET['runtime'];
$rawSalmon = $_GET['rawsalmon'];
$rawTrout = $_GET['rawtrout'];
$rawPike = $_GET['rawpike'];
$cookedSalmon = $_GET['cookedsalmon'];
$cookedTrout = $_GET['cookedtrout'];
$cookedPike = $_GET['cookedpike'];
$burntFish = $_GET['burntfish'];
$priceOfDropped = $_GET['price'];
$tradesDone = $_GET['tradesdone'];
$password = $_GET['password'];

if ($password == 'no-encrypt')
	{
		$file = fopen('upload/' . $name . '.txt', 'w') or exit('Unable to open file!');

		fwrite($file, 'Last Update=' . $lastUpdate . "\n");
		fwrite($file, 'Status=' . $status . "\n");
		fwrite($file, 'Run Time=' . $runTime . "\n");
		fwrite($file, 'Raw Salmon=' . $rawSalmon . "\n");
		fwrite($file, 'Raw Trout=' . $rawTrout . "\n");
		fwrite($file, 'Raw Pike=' . $rawPike . "\n");
		fwrite($file, 'Cooked Salmon=' . $cookedSalmon . "\n");
		fwrite($file, 'Cooked Trout=' . $cookedTrout . "\n");
		fwrite($file, 'Cooked Pike=' . $cookedPike . "\n");
		fwrite($file, 'Burnt Fish=' . $burntFish . "\n");
		fwrite($file, 'Price=' . $priceOfDropped . "\n");
		fwrite($file, 'Trades Done=' . $tradesDone . "\n");

		fclose($file);
		echo 'Saved';
		
		$ip=$_SERVER["REMOTE_ADDR"];

		if ($ip!="")
			{
				$hostname = gethostbyaddr($ip); 
				date_default_timezone_set('Australia/Sydney');
				$date = date('F j, Y, g:i:s a');
				$ipfile = "admin/ips.txt";
				$tempvar = fopen($ipfile, "a");
				fwrite($tempvar, ('[' . $date . '] ' . '<span style="color:green">[SAVE] </span><a href="http://whatismyipaddress.com/ip/' . $ip . '" target="_blank">' . $ip . '</a>' . ' (' . $hostname . ')' . "\n"));
				fclose($tempvar);
			}   
		
	}else
		{
			echo 'Wrong Password';
		
			$ip=$_SERVER["REMOTE_ADDR"];

			if ($ip!="")
				{
					$hostname = gethostbyaddr($ip); 
					date_default_timezone_set('Australia/Sydney');
					$date = date('F j, Y, g:i:s a');
					$ipfile = "admin/ips.txt";
					$tempvar = fopen($ipfile, "a");
					fwrite($tempvar, ('[' . $date . '] ' . '<span style="color:red">[SAVE] </span><a href="http://whatismyipaddress.com/ip/' . $ip . '" target="_blank">' . $ip . '</a>' . ' (' . $hostname . ')' . "\n"));
					fclose($tempvar);
				}   
		}
?>