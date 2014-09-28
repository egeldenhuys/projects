var zoomLevel = 1;
console.debug("Starting zoomTools.js");

function SetZoom(hours)
{
	console.debug("Setting Zoom to " + hours.toString());
	switch(hours.toString())
	{
	case "+1":
		zoomLevel += 1;
	break;
	
	case "-1":
		zoomLevel -= 1;
	break;
	
	case "1":
		zoomLevel = 1;
	break;
	
	case "24":
		zoomLevel = 24;
	break;
	}
	
	WriteTools();
	UpdateChart();
}

function WriteTools()
{
	console.debug("Writing tools");
	
	var theString = "<button type='button' onclick='SetZoom(-1)'><</button>";
	theString += " " + zoomLevel + " hours ";
	theString += "<button type='button' onclick='SetZoom(\"+1\")'>></button>";
	theString += "<button type='button' onclick='SetZoom(24)'>24</button>";
	theString += "<button type='button' onclick='SetZoom(1)'>1</button>";
	
	document.getElementById("zoomTools").innerHTML = theString;
}

function UpdateChart()
{
	var d = new Date();
	var n = d.getTime();

	chart.xAxis[0].setExtremes((n - 3600000 * zoomLevel) - timeOffset, n - timeOffset + 5 * 60 * 1000);
	chart.showResetZoom();
}
