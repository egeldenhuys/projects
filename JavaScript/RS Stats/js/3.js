$.ajaxSetup({timeout:3000});
	
		var theDataA3A;
		var reloadTimeA3A = 20000;
		var chartA3A;
		var startPointA3A;
		var part1A3A = false;
		var part2A3A = false;
		var doneA3A = false;
		var localTimezoneA3A;
		var timeOffsetA3A;
		var functionRanA3A = false;
		var failCountA3A = 0;
		var trackingA3A = false;
		var extremesA3A;
		
		$.get("https://dl.dropbox.com/u/133394013/StartPoint.txt",function(data){
			startPointA3A = data;
			var d = new Date();
			var n = d.getTimezoneOffset();
			localTimezoneA3A = "GMT+" + (-n / 60);
			timeOffsetA3A = n * 60 * 1000;
			startPointA3A = startPointA3A - n * 60 * 1000;
			part1A3A = true;
			
			AddLoad();
		});
		
	$.get("https://dl.dropbox.com/u/133394013/PlayerCount.txt",function(data){
		
		theDataA3A = data;
		theDataA3A = theDataA3A.slice(0, -1);
		part2A3A = true;
		AddLoad();
		});
		
		function AddLoad()
		{
		if(part1A3A)
		{
			if(part2A3A)
			{
				DoChart();
				ShowMinMax();
				extremesA3A = chartA3A.xAxis[0].getExtremes();
				setTimeout("ReloadData()", 20000);
			}
		}
	
		}
		
		function DoChart(){
        chartA3A = new HighchartA3As.Chart({
            chartA3A: {
                renderTo: 'container3',
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
                    text: "Time (" + localTimezoneA3A + ")",
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
                            [0, HighchartA3As.getOptions().colors[0]],
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
				pointInterval: 5000,
				pointStart: parseInt(startPointA3A),
				data: JSON.parse("[" + theDataA3A + "]")
            }]
        });
		};


function ReloadData()
{
	console.debug("Refreshing chartA3A...");
	
	setTimeout("TimedOut()", 3500);
	
	document.getElementById("loading").innerHTML="Refreshing chartA3A...";
	document.getElementById("loading").className="loadingStuff";
	
		var ajaxTime= new Date().getTime();
		$.get("https://dl.dropbox.com/u/133394013/PlayerCount.txt",function(data){
		var totalTime = new Date().getTime() - ajaxTime;
			theDataA3A = data;
			theDataA3A = theDataA3A.slice(0, -1);
			chartA3A.series[0].setData(JSON.parse("[" + theDataA3A + "]"), true);
			
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
			setTimeout("ReloadData()", reloadTimeA3A);
			functionRanA3A = true;
			failCountA3A = 0;
			if(trackingA3A)
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
	if (functionRanA3A == false)
	{
		console.warn("Refresh failed, trying again in 5 seconds.");
		document.getElementById("loading").innerHTML="Error refreshing chartA3A.";
		document.getElementById("loading").className="error";
		setTimeout("ReloadData()", 5000);
		failCountA3A += 1;
		console.debug("failCountA3A = " + failCountA3A);
	}
	
	if(failCountA3A > 5)
	{
	document.getElementById("loading").innerHTML="Are you still connected to the internet?";
	document.getElementById("loading").className="error";
	}
	
	functionRanA3A = false;
	
}

function ViewLastHour()
{
var d = new Date();
var n = d.getTime();

chartA3A.xAxis[0].setExtremes((n - 3600000) - timeOffsetA3A, n - timeOffsetA3A + 5 * 60 * 1000);
chartA3A.showResetZoom();
}

function ViewLast24Hours()
{
var d = new Date();
var n = d.getTime();

chartA3A.xAxis[0].setExtremes((n - 24 * 60 * 60 * 1000) - timeOffsetA3A, n - timeOffsetA3A + 15 * 60 * 1000);
chartA3A.showResetZoom();
}

function ResetZoom()
{
var d = new Date();
var n = d.getTime();
extremesA3A = chartA3A.xAxis[0].getExtremes();

chartA3A.xAxis[0].setExtremes(extremesA3A.dataMin - 15 * 60 * 1000, extremesA3A.dataMax + 15 * 60 * 1000);
}

function ToggleTracking()
{
	if(trackingA3A == false)
	{
		trackingA3A = true;
		document.getElementById("btnTracking").innerHTML = "Disable Tracking";
	}
	else
	{
		trackingA3A = false;
		document.getElementById("btnTracking").innerHTML = "Enable Tracking";
	}
}

function TrackData()
{
	extremesA3A = chartA3A.xAxis[0].getExtremes();
	chartA3A.xAxis[0].setExtremes(extremesA3A.min + 20000, extremesA3A.dataMax + 10 * 60 * 1000);
}

function ShowMinMax(total)
{
var playersOnline = chartA3A.yAxis[0].getExtremes();

var theString = "Max Players: " + AddCommas(playersOnline.dataMax) + "<br>Min Players: " + AddCommas(playersOnline.dataMin);
document.getElementById("minMax").innerHTML = theString;

AddCommas(playersOnline.dataMax);

}

function AddCommas(numberToMod)
{
	
	var result;
	var part1A3A;
	var part2A3A;
	var number = numberToMod.toString();

	switch(number.length)
	{
		case 6:
			part1A3A = number.slice(0, 3);
			part2A3A = number.slice(3);
			result = part1A3A + "," + part2A3A;
		break;
		
		case 5:
			part1A3A = number.slice(0, 2);
			part2A3A = number.slice(2);
			result = part1A3A + "," + part2A3A;
		break;
		
		case 4:
			part1A3A = number.slice(0, 1);
			part2A3A = number.slice(1);
			result = part1A3A + "," + part2A3A;
		break;
	
	}
	
	return result;
	
}

function ShowExtremes()
{
	console.info('dataMax: '+ extremesA3A.dataMax);
	console.info('dataMin: '+ extremesA3A.dataMin);
	console.info('max: '+ extremesA3A.max);
	console.info('min: '+ extremesA3A.min);

}

console.info("Script 3 reached the end");