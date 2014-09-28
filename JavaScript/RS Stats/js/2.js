$.ajaxSetup({timeout:3000});
	
		var theDataA2A;
		var reloadTimeA2A = 20000;
		var chartA2A;
		var startPointA2A;
		var part1A2A = false;
		var part2A2A = false;
		var doneA2A = false;
		var localTimezoneA2A;
		var timeOffsetA2A;
		var functionRanA2A = false;
		var failCountA2A = 0;
		var trackingA2A = false;
		var extremesA2A;
		
		$.get("https://dl.dropbox.com/u/133394013/StartPoint.txt",function(data){
			startPointA2A = data;
			var d = new Date();
			var n = d.getTimezoneOffset();
			localTimezoneA2A = "GMT+" + (-n / 60);
			timeOffsetA2A = n * 60 * 1000;
			startPointA2A = startPointA2A - n * 60 * 1000;
			part1A2A = true;
			
			AddLoad();
		});
		
	$.get("https://dl.dropbox.com/u/133394013/PlayerCount.txt",function(data){
		
		theDataA2A = data;
		theDataA2A = theDataA2A.slice(0, -1);
		part2A2A = true;
		AddLoad();
		});
		
		function AddLoad()
		{
		if(part1A2A)
		{
			if(part2A2A)
			{
				DoChart();
				ShowMinMax();
				extremesA2A = chartA2A.xAxis[0].getExtremes();
				setTimeout("ReloadData()", 20000);
			}
		}
	
		}
		
		function DoChart(){
        chartA2A = new HighchartA2As.Chart({
            chartA2A: {
                renderTo: 'container2',
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
                    text: "Time (" + localTimezoneA2A + ")",
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
                            [0, HighchartA2As.getOptions().colors[0]],
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
				pointInterval: 20000,
				pointStart: parseInt(startPointA2A),
				data: JSON.parse("[" + theDataA2A + "]")
            }]
        });
		};


function ReloadData()
{
	console.debug("Refreshing chartA2A...");
	
	setTimeout("TimedOut()", 3500);
	
	document.getElementById("loading").innerHTML="Refreshing chartA2A...";
	document.getElementById("loading").className="loadingStuff";
	
		var ajaxTime= new Date().getTime();
		$.get("https://dl.dropbox.com/u/133394013/PlayerCount.txt",function(data){
		var totalTime = new Date().getTime() - ajaxTime;
			theDataA2A = data;
			theDataA2A = theDataA2A.slice(0, -1);
			chartA2A.series[0].setData(JSON.parse("[" + theDataA2A + "]"), true);
			
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
			setTimeout("ReloadData()", reloadTimeA2A);
			functionRanA2A = true;
			failCountA2A = 0;
			if(trackingA2A)
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
	if (functionRanA2A == false)
	{
		console.warn("Refresh failed, trying again in 5 seconds.");
		document.getElementById("loading").innerHTML="Error refreshing chartA2A.";
		document.getElementById("loading").className="error";
		setTimeout("ReloadData()", 5000);
		failCountA2A += 1;
		console.debug("failCountA2A = " + failCountA2A);
	}
	
	if(failCountA2A > 5)
	{
	document.getElementById("loading").innerHTML="Are you still connected to the internet?";
	document.getElementById("loading").className="error";
	}
	
	functionRanA2A = false;
	
}

function ViewLastHour()
{
var d = new Date();
var n = d.getTime();

chartA2A.xAxis[0].setExtremes((n - 3600000) - timeOffsetA2A, n - timeOffsetA2A + 5 * 60 * 1000);
chartA2A.showResetZoom();
}

function ViewLast24Hours()
{
var d = new Date();
var n = d.getTime();

chartA2A.xAxis[0].setExtremes((n - 24 * 60 * 60 * 1000) - timeOffsetA2A, n - timeOffsetA2A + 15 * 60 * 1000);
chartA2A.showResetZoom();
}

function ResetZoom()
{
var d = new Date();
var n = d.getTime();
extremesA2A = chartA2A.xAxis[0].getExtremes();

chartA2A.xAxis[0].setExtremes(extremesA2A.dataMin - 15 * 60 * 1000, extremesA2A.dataMax + 15 * 60 * 1000);
}

function ToggleTracking()
{
	if(trackingA2A == false)
	{
		trackingA2A = true;
		document.getElementById("btnTracking").innerHTML = "Disable Tracking";
	}
	else
	{
		trackingA2A = false;
		document.getElementById("btnTracking").innerHTML = "Enable Tracking";
	}
}

function TrackData()
{
	extremesA2A = chartA2A.xAxis[0].getExtremes();
	chartA2A.xAxis[0].setExtremes(extremesA2A.min + 20000, extremesA2A.dataMax + 10 * 60 * 1000);
}

function ShowMinMax(total)
{
var playersOnline = chartA2A.yAxis[0].getExtremes();

var theString = "Max Players: " + AddCommas(playersOnline.dataMax) + "<br>Min Players: " + AddCommas(playersOnline.dataMin);
document.getElementById("minMax").innerHTML = theString;

AddCommas(playersOnline.dataMax);

}

function AddCommas(numberToMod)
{
	
	var result;
	var part1A2A;
	var part2A2A;
	var number = numberToMod.toString();

	switch(number.length)
	{
		case 6:
			part1A2A = number.slice(0, 3);
			part2A2A = number.slice(3);
			result = part1A2A + "," + part2A2A;
		break;
		
		case 5:
			part1A2A = number.slice(0, 2);
			part2A2A = number.slice(2);
			result = part1A2A + "," + part2A2A;
		break;
		
		case 4:
			part1A2A = number.slice(0, 1);
			part2A2A = number.slice(1);
			result = part1A2A + "," + part2A2A;
		break;
	
	}
	
	return result;
	
}

function ShowExtremes()
{
	console.info('dataMax: '+ extremesA2A.dataMax);
	console.info('dataMin: '+ extremesA2A.dataMin);
	console.info('max: '+ extremesA2A.max);
	console.info('min: '+ extremesA2A.min);

}

console.info("Script 2 reached the end");