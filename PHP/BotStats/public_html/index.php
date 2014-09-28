<html>
<body>

<head>
<meta http-equiv="cache-control" content="public" />
<title>Drop-B0T Statistics</title>
<link rel='icon' href='images/favicons/Raw Salmon.ico' type='image/ico'/>
</head>

<!-- Header Start -->
<table border="0" cellpadding="1" cellspacing="1" style="width: 177px; height: 30px;">
	<tbody>
		<tr>
			<td dir="ltr" style="text-align: center;">
				<big><a href="/index.php">Statistics</a></big></td>
			<td style="text-align: center;">
				<big><a href="/donators.php">Donators</a></big></td>
		</tr>
	</tbody>
</table>
<hr />
<!-- Header End -->

<h2><p>Total Statistics:</p></h2>

<p>Statistics are uploaded every 5 minutes.</p>

<p><span style="font-size:9px;"><a href="/old.html">View old statistics</a></span></p>

<h3><u><p>Drop-B0T 01:</p></u></h3>
<p><b>From: </b>2012-04-29 4:20:00 PM EST<br />
<?php
parseStatistics('Drop_B0T_01.txt', 12);
?>
</p>

<!--
<h3><u><p>Drop-B0T 02:</p></u></h3>
<p><?php
//parseStatistics('Drop_B0T_02.txt', 12);
?></p>
-->

<h3><u><p>Drop-B0T 04:</p></u></h3>
<p><b>From: </b>2012-05-06 1:00:00 PM EST<br />
<?php
parseStatistics('Drop_B0T_04.txt', 12);
?>
</p>

<h3><u><p>Paid-B0T 01:</p></u></h3>
<p><b>From: </b>2012-05-16 6:00:00 PM EST<br />
<p><?php
parseStatistics('Paid_B0T_01.txt', 12);
?></p>

<?php
function parseStatistics($fileName, $total)
    {
    if ($_GET["images"] == "")
        {
        $found = 0;
        if (file_exists('upload/' . $fileName))
          {
            $file = fopen('upload/' . $fileName, 'r') or exit('Unable to open file!');
            
            while (!feof($file))
              {
                $text = fgets($file);
                $text = explode('=', $text);
                
                switch ($text[0])
                {
                    case 'Run Time':
                        echo '<img src="/images/icons/Clock.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Run Time: </b>';
                        
                        if (($text[1] / 1000) > 86400)
                            echo gmdate('z \D\a\y\s\, G \H\o\u\r\s\, i \M\i\n\u\t\e\s', ((int) $text[1] / 1000)) . '<br />';
                        else
                            echo gmdate('G \H\o\u\r\s\, i \M\i\n\u\t\e\s', ((int) $text[1] / 1000)) . '<br />';
                        
                        $found += 1;
                        break;
                    
                    case 'Raw Salmon':
                        echo '<img src="/images/icons/' . $text[0] . '.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Raw Salmon: </b>' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Raw Trout':
                        echo '<img src="/images/icons/' . $text[0] . '.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Raw Trout:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Raw Pike':
                        echo '<img src="/images/icons/' . $text[0] . '.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Raw Pike:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Cooked Salmon':
                        echo '<img src="/images/icons/' . $text[0] . '.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Cooked Salmon:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Cooked Trout':
                        echo '<img src="/images/icons/' . $text[0] . '.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Cooked Trout:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Cooked Pike':
                        echo '<img src="/images/icons/' . $text[0] . '.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Cooked Pike:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Burnt Fish':
                        echo '<img src="/images/icons/' . $text[0] . '.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Burnt Fish:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Trades Done':
                        echo '<img src="/images/icons/Trade.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Trades Done:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Price':
                        echo '<img src="/images/icons/Coins.png" alt="' . $text[0] . '" width="16" height="16" />' . '<b>Price of dropped fish:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Last Update':
                        date_default_timezone_set('Australia/Sydney');
                        
                        $now  = time();
                        $last = strtotime($text[1]);
                        $diff = ($now - $last); // Difference in seconds
                        
                        $time=$diff;
                        $seconds = $time%60;
                        $mins = floor($time/60)%60;
                        $hours = floor($time/60/60)%24;
                        $days = floor($time/60/60/24);

                        if ($diff >= 86400)
                            echo '<b>Last Update: </b>' . $days . ' days, ' . $hours . ' hours and ' . $mins . ' minutes ago <br />';
                        elseif ($diff >= 3600)
                            echo '<b>Last Update: </b>' . $hours . ' hours and ' . $mins . ' minutes ago <br />';
                        elseif ($diff < 3600)
                          {
                            echo '<b>Last Update: </b>' . $mins . ' minutes and ' . $seconds . ' seconds ago <br />';
                            $page        = $_SERVER['SCRIPT_NAME'];
                            $refreshTime = (323 - $diff);
                            header("refresh: {$refreshTime}; url={$page}");
                          }
                        
                        $found += 1;
                        break;
                    
                    case 'Status':
                        //8,9
                        if ($diff > 900)
                            echo '<b>Status: </b><span style="color:red">' . "Offline" . '</span> <br /><br />';
                        elseif (strlen($text[1]) == 7)
                            echo '<b>Status: </b><span style="color:green">' . "Online" . '</span> <br /><br />';
                        elseif (strlen($text[1]) == 8)
                            echo '<b>Status: </b><span style="color:red">' . "Offline" . '</span> <br /><br />';
                        
                        $found += 1;
                        break;
                    
                    default:
                        if ($found <> $total)
                            echo 'No Statistics have been uploaded yet.' . '<br />';
                } //$text[0]
                
              } //!feof($file)
            fclose($file);
          } //file_exists('upload/' . $fileName)
        else
          {
            echo 'No Statistics have been uploaded yet.' . '<br />';
          }
        }
        else
        {
        $found = 0;
        if (file_exists('upload/' . $fileName))
          {
            $file = fopen('upload/' . $fileName, 'r') or exit('Unable to open file!');
            
            while (!feof($file))
              {
                $text = fgets($file);
                $text = explode('=', $text);
                
                switch ($text[0])
                {
                    case 'Run Time':
                        echo '<b>Run Time: </b>';
                        
                        if (($text[1] / 1000) > 86400)
                            echo gmdate('z \D\a\y\s\, G \H\o\u\r\s\, i \M\i\n\u\t\e\s', ((int) $text[1] / 1000)) . '<br />';
                        else
                            echo gmdate('G \H\o\u\r\s\, i \M\i\n\u\t\e\s', ((int) $text[1] / 1000)) . '<br />';
                        
                        $found += 1;
                        break;
                    
                    case 'Raw Salmon':
                        echo '<b>Raw Salmon: </b>' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Raw Trout':
                        echo '<b>Raw Trout:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Raw Pike':
                        echo '<b>Raw Pike:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Cooked Salmon':
                        echo '<b>Cooked Salmon:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Cooked Trout':
                        echo '<b>Cooked Trout:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Cooked Pike':
                        echo '<b>Cooked Pike:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Burnt Fish':
                        echo '<b>Burnt Fish:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Trades Done':
                        echo '<b>Trades Done:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Price':
                        echo '<b>Price of dropped fish:</b> ' . Number_format($text[1]) . '<br />';
                        $found += 1;
                        break;
                    
                    case 'Last Update':
                        date_default_timezone_set('Australia/Sydney');
                        
                        $now  = time();
                        $last = strtotime($text[1]);
                        $diff = ($now - $last); // Difference in seconds
                        
                        $time=$diff;
                        $seconds = $time%60;
                        $mins = floor($time/60)%60;
                        $hours = floor($time/60/60)%24;
                        $days = floor($time/60/60/24);

                        if ($diff >= 86400)
                            echo '<b>Last Update: </b>' . $days . ' days, ' . $hours . ' hours and ' . $mins . ' ago <br />';
                        elseif ($diff >= 3600)
                            echo '<b>Last Update: </b>' . $hours . ' hours and ' . $mins . ' minutes ago <br />';
                        elseif ($diff < 3600)
                          {
                            echo '<b>Last Update: </b>' . $mins . ' minutes and ' . $seconds . ' seconds ago <br />';
                            $page        = $_SERVER['SCRIPT_NAME'];
                            $refreshTime = (323 - $diff);
                            header("refresh: {$refreshTime}; url={$page}");
                          }
                        
                        $found += 1;
                        break;
                    
                    case 'Status':
                        //8,9
                        if ($diff > 900)
                            echo '<b>Status: </b><span style="color:red">' . "Offline" . '</span> <br /><br />';
                        elseif (strlen($text[1]) == 7)
                            echo '<b>Status: </b><span style="color:green">' . "Online" . '</span> <br /><br />';
                        elseif (strlen($text[1]) == 8)
                            echo '<b>Status: </b><span style="color:red">' . "Offline" . '</span> <br /><br />';
                        
                        $found += 1;
                        break;
                    
                    default:
                        if ($found <> $total)
                            echo 'No Statistics have been uploaded yet.' . '<br />';
                } //$text[0]
                
              } //!feof($file)
            fclose($file);
          } //file_exists('upload/' . $fileName)
        else
          {
            echo 'No Statistics have been uploaded yet.' . '<br />';
          }
        }
    }
?>

<?php
// outputs e.g. 'Last modified: March 04 1998 20:43:59.'
date_default_timezone_set('Australia/Sydney');
echo '<hr />';
echo '<p style="text-align: center;">';
echo "Last modified: " . date("Y-m-d g:i:s A T", getlastmod());
echo '</p>';
?>

<?
$ip = $_SERVER["REMOTE_ADDR"];

if ($ip != "")
  {
    $hostname = gethostbyaddr($ip);
    date_default_timezone_set('Australia/Sydney');
    $date    = date('F j, Y, g:i:s a');
    $ipfile  = "admin/ips.txt";
    $tempvar = fopen($ipfile, "a");
    fwrite($tempvar, ('[' . $date . '] <span style="color:#229D9F">[S] </span>' . '<a href="http://whatismyipaddress.com/ip/' . $ip . '" target="_blank">' . $ip . '</a>' . ' (' . $hostname . ')' . "\n"));
    fclose($tempvar);
  } //$ip != ""
?>

</body>
</html>