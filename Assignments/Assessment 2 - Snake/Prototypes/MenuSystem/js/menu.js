console.log("Starting Menu Script");

var canvas;
var canvasContext;
var canvasPosition;

/******************************************
*	Constants
******************************************/
const CANVAS_WIDTH = 500;
const CANVAS_HEIGHT = 500;
const FONT = "30px Arial";
const DEFAULT_COLOUR = "#FF0000";

function Init() {
	console.log("Init()");
	//Do the main functionality
	SetupCanvas();
	
	canvas2 = $('#gameScreen');
	
	
var canvasPosition = {
    x: canvas2.offset().left,
    y: canvas2.offset().top
};

canvas2.click(function(e) {
	console.log("Clicked the canvas");
	//PrintText("A" + "B");
	PrintText((e.pageX - canvasPosition.x) + ", " + (e.pageY - canvasPosition.y));
});

}

function SetupCanvas() {
	console.log("SetupCanvas()");
	
	//Get object and setup
	
	canvas = document.getElementById("gameScreen");
	canvas.width = CANVAS_WIDTH;
	canvas.height = CANVAS_HEIGHT;

	canvasContext=canvas.getContext("2d");
	canvasContext.fillStyle = DEFAULT_COLOUR;
	canvasContext.fillRect(0,0,canvas.width,canvas.height);
	
}

// http://www.ibm.com/developerworks/library/wa-games/
//http://api.jquery.com/offset/



function PrintText(text) {
	ClearCanvas();
	canvasContext.font = "30px Arial";
	canvasContext.fillStyle = "#0000FF";
	canvasContext.fillText(text, 100, 100);
}

function ClearCanvas() {
canvasContext.fillStyle = "#FF0000";
canvasContext.fillRect(0, 0, canvas.width,canvas.height);

}

