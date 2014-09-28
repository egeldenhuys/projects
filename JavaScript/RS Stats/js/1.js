$.ajaxSetup({timeout:3000});
	
		var theDataA1A;
		var reloadTimeA1A = 20000;
		var chartA1A;
		var startPointA1A;
		var part1A1A = false;
		var part2A1A = false;
		var doneA1A = false;
		var localTimezoneA1A;
		var timeOffsetA1A;
		var functionRanA1A = false;
		var failCountA1A = 0;
		var trackingA1A = false;
		var extremesA1A;
		
		$.get("https://dl.dropbox.com/u/133394013/3/StartPoint.txt",function(data){
			startPointA1A = data;
			var d = new Date();
			var n = d.getTimezoneOffset();
			localTimezoneA1A = "GMT+" + (-n / 60);
			timeOffsetA1A = n * 60 * 1000;
			startPointA1A = startPointA1A - n * 60 * 1000;
			part1A1A = true;
			
			AddLoad();
		});
		
	$.get("https://dl.dropbox.com/u/133394013/3/PlayerCount.txt",function(data){
		
		theDataA1A = data;
		theDataA1A = theDataA1A.slice(0, -1);
		part2A1A = true;
		AddLoad();
		});
		
		function AddLoad()
		{
		if(part1A1A)
		{
			if(part2A1A)
			{
				DoChart();
				ShowMinMax();
				extremesA1A = chartA1A.xAxis[0].getExtremes();
				setTimeout("ReloadData()", 20000);
			}
		}
	
		}
		
		function DoChart(){
        chartA1A = new HighchartA1As.Chart({
            chartA1A: {
                renderTo: 'container1',
                zoomType: 'x',
                spacingRight: 20,
				ignoreHiddenSeries: false
            },
            title: {
                text: 'Runescape Online Player History',
            },
            subtitle: {
                text: document.ontouchstart === undefined ?
                    'Click and drag in the plot area to zoom in' :
                    'Drag your finger over the plot to zoom in'
            },
            xAxis: {
                type: 'datetime',
				maxZoom: 600000, // 10 Minutes
                title: {
                    text: "Time (" + localTimezoneA1A + ")",
                }
            },
            yAxis: {
                title: {
                    text: 'Players Online'
                },
                showFirstLabel: false
            },
            tooltip: {
                shared: true
            },
            legend: {
                enabled: false
            },
            plotOptions: {
                area: {
                    fillColor: {
                        linearGradient: { x1: 0, y1: 0, x2: 0, y2: 1},
                        stops: [
                            [0, HighchartA1As.getOptions().colors[0]],
                            [1, 'rgba(2,0,0,0)']
                        ]
                    },
                    lineWidth: 1,
                    marker: {
                        enabled: false,
						fillColor: "#C92A2A",
						lineColor: "#C92A2A",
                        states: {
                            hover: {
                                enabled: true,
                                radius: 3
                            }
                        }
                    },
                    shadow: false,
                    states: {
                        hover: {
                            lineWidth: 1
                        }
                    },
                    threshold: null,
					connectNulls: true
                }
            },
    
            series: [{
                type: 'area',
                name: 'Players',
				pointInterval: 60000,
				pointStart: parseInt(startPointA1A),
				data: JSON.parse("[" + theDataA1A + "]")
            }]
        });
		};


function ReloadData()
{
	console.debug("Refreshing chartA1A...");
	
	setTimeout("TimedOut()", 3500);
	
	document.getElementById("loading").innerHTML="Refreshing chartA1A...";
	document.getElementById("loading").className="loadingStuff";
	
		var ajaxTime= new Date().getTime();
		$.get("https://dl.dropbox.com/u/133394013/3/PlayerCount.txt",function(data){
		var totalTime = new Date().getTime() - ajaxTime;
			theDataA1A = data;
			theDataA1A = theDataA1A.slice(0, -1);
			chartA1A.series[0].setData(JSON.parse("[" + theDataA1A + "]"), true);
			
			var responseTime;
			
			if(totalTime >= 1000)
			{
			responseTime = (totalTime / 1000) + "s";
			}
			else
			{
			responseTime = totalTime + "ms";
			}
			
			document.getElementById("loading").innerHTML="Chart has been refreshed. (" + responseTime + ")";
			document.getElementById("loading").className="good";
			setTimeout("ReloadData()", reloadTimeA1A);
			functionRanA1A = true;
			failCountA1A = 0;
			if(trackingA1A)
			{
			TrackData();
			}
			ShowMinMax();
			ViewLastHour()
			console.debug("Chart has been successfully refreshed.");
	});
};

function TimedOut()
{
	if (functionRanA1A == false)
	{
		console.warn("Refresh failed, trying again in 5 seconds.");
		document.getElementById("loading").innerHTML="Error refreshing chartA1A.";
		document.getElementById("loading").className="error";
		setTimeout("ReloadData()", 5000);
		failCountA1A += 1;
		console.debug("failCountA1A = " + failCountA1A);
	}
	
	if(failCountA1A > 5)
	{
	document.getElementById("loading").innerHTML="Are you still connected to the internet?";
	document.getElementById("loading").className="error";
	}
	
	functionRanA1A = false;
	
}

function ViewLastHour()
{
var d = new Date();
var n = d.getTime();

chartA1A.xAxis[0].setExtremes((n - 3600000) - timeOffsetA1A, n - timeOffsetA1A + 5 * 60 * 1000);
chartA1A.showResetZoom();
}

function ViewLast24Hours()
{
var d = new Date();
var n = d.getTime();

chartA1A.xAxis[0].setExtremes((n - 24 * 60 * 60 * 1000) - timeOffsetA1A, n - timeOffsetA1A + 15 * 60 * 1000);
chartA1A.showResetZoom();
}

function ResetZoom()
{
var d = new Date();
var n = d.getTime();
extremesA1A = chartA1A.xAxis[0].getExtremes();

chartA1A.xAxis[0].setExtremes(extremesA1A.dataMin - 15 * 60 * 1000, extremesA1A.dataMax + 15 * 60 * 1000);
}

function ToggleTracking()
{
	if(trackingA1A == false)
	{
		trackingA1A = true;
		document.getElementById("btnTracking").innerHTML = "Disable Tracking";
	}
	else
	{
		trackingA1A = false;
		document.getElementById("btnTracking").innerHTML = "Enable Tracking";
	}
}

function TrackData()
{
	extremesA1A = chartA1A.xAxis[0].getExtremes();
	chartA1A.xAxis[0].setExtremes(extremesA1A.min + 20000, extremesA1A.dataMax + 10 * 60 * 1000);
}

function ShowMinMax(total)
{
var playersOnline = chartA1A.yAxis[0].getExtremes();

var theString = "Max Players: " + AddCommas(playersOnline.dataMax) + "<br>Min Players: " + AddCommas(playersOnline.dataMin);
document.getElementById("minMax").innerHTML = theString;

AddCommas(playersOnline.dataMax);

}

function AddCommas(numberToMod)
{
	
	var result;
	var part1A1A;
	var part2A1A;
	var number = numberToMod.toString();

	switch(number.length)
	{
		case 6:
			part1A1A = number.slice(0, 3);
			part2A1A = number.slice(3);
			result = part1A1A + "," + part2A1A;
		break;
		
		case 5:
			part1A1A = number.slice(0, 2);
			part2A1A = number.slice(2);
			result = part1A1A + "," + part2A1A;
		break;
		
		case 4:
			part1A1A = number.slice(0, 1);
			part2A1A = number.slice(1);
			result = part1A1A + "," + part2A1A;
		break;
	
	}
	
	return result;
	
}

function ShowExtremes()
{
	console.info('dataMax: '+ extremesA1A.dataMax);
	console.info('dataMin: '+ extremesA1A.dataMin);
	console.info('max: '+ extremesA1A.max);
	console.info('min: '+ extremesA1A.min);

}

console.info("Script 1 reached the end");