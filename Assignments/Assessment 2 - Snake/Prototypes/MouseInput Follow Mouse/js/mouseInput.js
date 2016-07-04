/******************************************
*	Constants
******************************************/
const CANVAS_NAME = "gameScreen";
const CANVAS_WIDTH = 500;
const CANVAS_HEIGHT = 500;
const CANVAS_COLOUR = "#FF0000";
const FONT = "30px Arial";
const FONT_COLOUR = "#0000FF";

/******************************************
*	Globals
******************************************/
var canvas;					//Reference to the canvas object (set in SetupCanvas)
var canvasContext;			//Reference to the canvas context (set in SetupCanvas)
var canvasOffset;			//The position relative to the left and top edges of the document

var clickPosStr = "";
var movePosStr = "";
var mousePos = new Array();

function Init() {
	SetupCanvas();
	
	// Set up the handler for the canvas
	$("#" + CANVAS_NAME).click(function(e) {
		ClickHandler(e);
	});
	
	// Set up event handler for mouse move
	$("#" + CANVAS_NAME).mousemove(function(e) {
		MouseMoveEvent(e);
	});
	
}

function ClickHandler(e) {
	// Print the coordinates to the screen
	
	mousePos[0] = e.pageX - canvasOffset.left;
	mousePos[1] = e.pageY - canvasOffset.top;
	
	clickPosStr = "Clicked: " + (e.pageX - canvasOffset.left) + ", " + (e.pageY - canvasOffset.top);
	
	RefreshCanvas();
}

function MouseMoveEvent(e) {
	
	mousePos[0] = e.pageX - canvasOffset.left;
	mousePos[1] = e.pageY - canvasOffset.top;
	
	movePosStr = "Moved: " + (e.pageX - canvasOffset.left) + ", " + (e.pageY - canvasOffset.top);
	RefreshCanvas();
	
}

function SetupCanvas() {

	//Get canvas object and set sizes
	canvas = document.getElementById(CANVAS_NAME);
	canvas.width = CANVAS_WIDTH;
	canvas.height = CANVAS_HEIGHT;
	
	// Clear the canvas using the default colour
	canvasContext=canvas.getContext("2d");
	canvasContext.fillStyle = CANVAS_COLOUR;
	canvasContext.fillRect(0,0,canvas.width,canvas.height);
	
	// Get the canvas offset using jquery
	canvasOffset = $("#" + CANVAS_NAME).offset();
	
	
}

function PrintText(text, x, y, font, fontColour) {

	//ClearRect(x, y - 30, canvasContext.measureText(text).width, 30, "#00FF00");
	
	// Set font and colour
	canvasContext.font = font;
	canvasContext.fillStyle = fontColour;
	canvasContext.fillText(text, x, y);
}

function ClearRect(x, y, w, h, colour) {
	canvasContext.fillStyle = colour;
	canvasContext.fillRect(x, y, x + w, y + h);
}

function ClearCanvas() {
	// Clear the canvas using default colour
	canvasContext.fillStyle = CANVAS_COLOUR;
	canvasContext.fillRect(0, 0, canvas.width,canvas.height);
}

function RefreshCanvas() {
	ClearCanvas();
	PrintText(clickPosStr, 10, 100, FONT, FONT_COLOUR);
	PrintText(movePosStr, 10, 50, FONT, FONT_COLOUR);
	
	canvasContext.fillStyle = "#0000FF";
	canvasContext.fillRect(mousePos[0] - 10, mousePos[1] - 10, 20, 20);
}


